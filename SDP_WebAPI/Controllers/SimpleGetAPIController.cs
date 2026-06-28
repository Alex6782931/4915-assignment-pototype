using DatabaseAccessController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SDP_EntityModels;
using System;
using System.Data;
using System.Text.Json;

namespace SDP_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleGetAPIController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SimpleGetAPIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //LOGIN
        [HttpPost("VerifyLogin")]
        public string VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetUserAccountData(username);

            // If username is not found in database records, return a fail tag
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                return "FAILED_USER_NOT_FOUND";
            }

            DataRow userRow = dtResult.Rows[0];
            string dbPassword = userRow["passwordHash"]?.ToString();
            string accessLevel = userRow["accessLevel"]?.ToString();

            // Check which profile ID contains data to determine the user type
            string staffId = dtResult.Columns.Contains("staffID") ? userRow["staffID"]?.ToString() : null;
            string customerId = dtResult.Columns.Contains("customerID") ? userRow["customerID"]?.ToString() : null;

            // Verify if typed text matches the active database row parameters
            if (dbPassword == password)
            {
                if (!string.IsNullOrEmpty(staffId))
                {
                    return $"STAFF_ROUTE:{accessLevel},{staffId}";
                }
                else if (!string.IsNullOrEmpty(customerId))
                {
                    return $"CUSTOMER_ROUTE:{accessLevel},{customerId}";
                }

                // Fallback safe return if both IDs are somehow null but password is right
                return $"UNKNOWN_ROUTE:{accessLevel},";
            }

            return "FAILED_WRONG_PASSWORD";
        }


        //REGISTER
        [HttpPost("VerifyRegister")]
        public string VerifyRegister([FromQuery] string username,
                             [FromQuery] string password,
                             [FromQuery] string firstname,
                             [FromQuery] string lastname,
                             [FromQuery] string phone,
                             [FromQuery] string city = "Unknown",
                             [FromQuery] string country = "Unknown")
        {
            string connString = _configuration["ConnectionStrings"];

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();

                // 1. 验证用户名是否已被 user_accounts 表占用
                string sqlCheck = "SELECT COUNT(*) FROM user_accounts WHERE username = @username;";
                using (MySql.Data.MySqlClient.MySqlCommand cmdCheck = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@username", username);
                    long userCount = Convert.ToInt64(cmdCheck.ExecuteScalar());
                    if (userCount > 0)
                    {
                        return "FAILED_USER_EXISTS";
                    }
                }

                // 使用数据库事务保证两张表写入完整性
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 2. 因为主键 customerNumber 不是 AUTO_INCREMENT，手动计算当前的最新编号
                        int newCustomerNumber = 1;
                        string sqlMaxId = "SELECT MAX(customerNumber) FROM customer;";
                        using (MySql.Data.MySqlClient.MySqlCommand cmdMaxId = new MySql.Data.MySqlClient.MySqlCommand(sqlMaxId, conn, transaction))
                        {
                            object maxResult = cmdMaxId.ExecuteScalar();
                            if (maxResult != null && maxResult != DBNull.Value)
                            {
                                newCustomerNumber = Convert.ToInt32(maxResult) + 1;
                            }
                        }

                        // 3. 第一步：先创建 Customer 记录
                        string sqlInsertCustomer = @"INSERT INTO customer 
                    (customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1, addressLine2, city, state, postalCode, country, staffID, creditLimit) 
                    VALUES 
                    (@customerNumber, @customerName, @contactLastName, @contactFirstName, @phone, NULL, NULL, @city, NULL, NULL, @country, NULL, NULL);";

                        using (MySql.Data.MySqlClient.MySqlCommand cmdCust = new MySql.Data.MySqlClient.MySqlCommand(sqlInsertCustomer, conn, transaction))
                        {
                            cmdCust.Parameters.AddWithValue("@customerNumber", newCustomerNumber);
                            cmdCust.Parameters.AddWithValue("@customerName", firstname + " " + lastname);
                            cmdCust.Parameters.AddWithValue("@contactLastName", lastname);
                            cmdCust.Parameters.AddWithValue("@contactFirstName", firstname);
                            cmdCust.Parameters.AddWithValue("@phone", phone);
                            cmdCust.Parameters.AddWithValue("@city", city);
                            cmdCust.Parameters.AddWithValue("@country", country);

                            cmdCust.ExecuteNonQuery();
                        }

                        // 4. 第二步：使用刚才生成的 newCustomerNumber 创建 user_accounts 记录
                        string sqlInsertAccount = @"INSERT INTO user_accounts (username, passwordHash, staffID, customerID, accessLevel) 
                                            VALUES (@username, @passwordHash, NULL, @customerID, 'Customer');";

                        using (MySql.Data.MySqlClient.MySqlCommand cmdAcc = new MySql.Data.MySqlClient.MySqlCommand(sqlInsertAccount, conn, transaction))
                        {
                            cmdAcc.Parameters.AddWithValue("@username", username);
                            cmdAcc.Parameters.AddWithValue("@passwordHash", password);
                            cmdAcc.Parameters.AddWithValue("@customerID", newCustomerNumber); // 与客户表完美关联

                            cmdAcc.ExecuteNonQuery();
                        }

                        // 提交事务，让数据落库
                        transaction.Commit();

                        return $"SUCCESS_REGISTERED:{firstname},{newCustomerNumber}";
                    }
                    catch (Exception ex)
                    {
                        // 如果任何一个环节报错（比如某项约束冲突），全面回滚，确保不会在表里留下脏数据
                        transaction.Rollback();
                        return $"FAILED_SERVER_ERROR:{ex.Message}";
                    }
                }
            }
        }

        //CUSTOMER TABLE

        [HttpGet("GetCustomerData")]
        public string GetCustomerData()
        {
            string connString = _configuration["ConnectionStrings"];

            // Explicitly uses GetCompanyData file to run the table query
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllCustomerData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    dict[col.ColumnName] = row[col].ToString();
                }
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindCustomerData")]
        public string FindCustomerData([FromQuery] string customerName)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllCustomerData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                // FIXED: Using lowercase 'customerName' matching your schema exactly
                string currentName = row["customerName"]?.ToString() ?? "";

                if (currentName.IndexOf(customerName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns)
                    {
                        dict[col.ColumnName] = row[col].ToString();
                    }
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateCustomerData")]
        public int UpdateCustomerData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                // Native self-contained MySQL command runner skips old data adapter constraints
                using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                {
                    conn.Open();

                    // 1. Process Modified Customer Rows
                    if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                    {
                        var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                        if (modifiedRows != null)
                        {
                            foreach (var row in modifiedRows)
                            {
                                // FIXED: Uses 'customer' table name and includes 'staffID' column updates securely
                                string sqlUpdate = $@"UPDATE customer SET 
                            customerName = '{row["customerName"]?.Replace("'", "''")}',
                            contactLastName = '{row["contactLastName"]?.Replace("'", "''")}',
                            contactFirstName = '{row["contactFirstName"]?.Replace("'", "''")}',
                            phone = '{row["phone"]?.Replace("'", "''")}',
                            addressLine1 = '{row["addressLine1"]?.Replace("'", "''")}',
                            city = '{row["city"]?.Replace("'", "''")}',
                            country = '{row["country"]?.Replace("'", "''")}',
                            staffID = {(string.IsNullOrEmpty(row["staffID"]) ? "NULL" : $"'{row["staffID"]}'")}
                            WHERE customerNumber = {row["customerNumber"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Customer Sync Error: " + ex.Message);
                return 0;
            }
        }
        // --- FIXED ENDPOINT: 獲取指定客戶的歷史訂單 ---
        // URL: GET https://localhost:7146/api/SimpleGetAPI/GetOrderHistory?customerNumber=103
        [HttpGet("GetOrderHistory")]
        public string GetOrderHistory([FromQuery] int customerNumber)
        {
            string connString = _configuration["ConnectionStrings"];

            // 使用 AS 別名對接前端：orderStatus 對應 status，totalAmount 對應 comments (用作顯示總金額)
            string query = "SELECT orderNumber, orderDate, orderStatus AS status, totalAmount AS comments " +
                           "FROM orders WHERE customerNumber = @custNum ORDER BY orderDate DESC";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            var list = new List<Dictionary<string, string>>();
                            foreach (DataRow row in dt.Rows)
                            {
                                var dict = new Dictionary<string, string>();
                                foreach (DataColumn col in dt.Columns)
                                {
                                    dict[col.ColumnName] = row[col]?.ToString() ?? "";
                                }
                                list.Add(dict);
                            }
                            return JsonSerializer.Serialize(list);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }

        // --- FIXED ENDPOINT: 搜尋指定客戶的特定訂單號碼或狀態 ---
        // URL: GET https://localhost:7146/api/SimpleGetAPI/SearchOrderHistory?customerNumber=103&keyword=Shipped
        [HttpGet("SearchOrderHistory")]
        public string SearchOrderHistory([FromQuery] int customerNumber, [FromQuery] string keyword)
        {
            string connString = _configuration["ConnectionStrings"];

            // 使用 AS 別名對接前端，並調整搜尋欄位為 orderStatus
            string query = "SELECT orderNumber, orderDate, orderStatus AS status, totalAmount AS comments " +
                           "FROM orders " +
                           "WHERE customerNumber = @custNum AND (orderNumber LIKE @keyword OR orderStatus LIKE @keyword) " +
                           "ORDER BY orderDate DESC";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            var list = new List<Dictionary<string, string>>();
                            foreach (DataRow row in dt.Rows)
                            {
                                var dict = new Dictionary<string, string>();
                                foreach (DataColumn col in dt.Columns)
                                {
                                    dict[col.ColumnName] = row[col]?.ToString() ?? "";
                                }
                                list.Add(dict);
                            }
                            return JsonSerializer.Serialize(list);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }



        //AFTER SERVICE RECORDS TABLE

        [HttpGet("GetAfterServiceRecordsData")]
        public string GetAfterServiceRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];

            // Explicitly using your SQL data loader class file
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAfterServiceRecordsData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    dict[col.ColumnName] = row[col].ToString();
                }
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindAfterServiceRecordsData")]
        public string FindAfterServiceRecordsData([FromQuery] string orderNumber)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAfterServiceRecordsData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                // FIX: Look up the column dynamically by name, ignoring potential case mismatches
                string currentOrderNumber = "";
                if (dtResult.Columns.Contains("orderNumber")) currentOrderNumber = row["orderNumber"]?.ToString() ?? "";
                else if (dtResult.Columns.Contains("ordernumber")) currentOrderNumber = row["ordernumber"]?.ToString() ?? "";

                // Strip spaces and compare directly
                if (currentOrderNumber.Trim() == orderNumber.Trim())
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns)
                    {
                        dict[col.ColumnName] = row[col].ToString();
                    }
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateAfterServiceRecordsData")]
        public int UpdateAfterServiceRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        // Native self-contained MySQL command runner bypasses GetData wrapper limitations
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE after_service_records SET 
                            reason = '{row["reason"]?.Replace("'", "''")}',
                            resolutionStatus = '{row["resolutionStatus"]?.Replace("'", "''")}'
                            WHERE caseID = {row["caseID"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery(); // Safely executes updates without expecting data rows back
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Update Processing Failure: " + ex.Message);
                return 0;
            }
        }

        //ORDER TABLE

        [HttpGet("GetOrderRecordsData")]
        public string GetOrderRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllOrderData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindOrderRecordsData")]
        public string FindOrderRecordsData([FromQuery] string orderNumber)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllOrderData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                if (row["orderNumber"]?.ToString().Trim() == orderNumber.Trim())
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateOrderRecordsData")]
        public int UpdateOrderRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE orders SET 
                            orderStatus = '{row["orderStatus"]}',
                            totalAmount = {row["totalAmount"]}
                            WHERE orderNumber = {row["orderNumber"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //INVENTORY TABLE

        [HttpGet("GetInventoryRecordsData")]
        public string GetInventoryRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllInventoryData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindInventoryRecordsData")]
        public string FindInventoryRecordsData([FromQuery] string itemName)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllInventoryData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentItemName = row["itemName"]?.ToString() ?? "";
                if (currentItemName.IndexOf(itemName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateInventoryRecordsData")]
        public int UpdateInventoryRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE inventory SET 
                            quantityInStock = {row["quantityInStock"]},
                            location = '{row["location"]?.Replace("'", "''")}'
                            WHERE itemID = '{row["itemID"]}';";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //PROCURMENT TABLE

        [HttpGet("GetProcurementRecordsData")]
        public string GetProcurementRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllProcurementData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindProcurementRecordsData")]
        public string FindProcurementRecordsData([FromQuery] string rawMaterialID)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllProcurementData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentMatID = row["rawMaterialID"]?.ToString() ?? "";
                if (currentMatID.IndexOf(rawMaterialID, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateProcurementRecordsData")]
        public int UpdateProcurementRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE procurements SET 
                            quantityOrdered = {row["quantityOrdered"]},
                            status = '{row["status"]}'
                            WHERE procurementID = {row["procurementID"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //STAFF TABLE

        [HttpGet("GetStaffRecordsData")]
        public string GetStaffRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllStaffData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindStaffRecordsData")]
        public string FindStaffRecordsData([FromQuery] string fullName)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllStaffData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentStaffName = row["fullName"]?.ToString() ?? "";
                if (currentStaffName.IndexOf(fullName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateStaffRecordsData")]
        public int UpdateStaffRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE staff SET 
                            fullName = '{row["fullName"]?.Replace("'", "''")}',
                            role = '{row["role"]?.Replace("'", "''")}',
                            department = '{row["department"]?.Replace("'", "''")}',
                            email = '{row["email"]?.Replace("'", "''")}'
                            WHERE staffID = '{row["staffID"]}';";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //LOGISTICS TABLE

        [HttpGet("GetLogisticsRecordsData")]
        public string GetLogisticsRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllLogisticsData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindLogisticsRecordsData")]
        public string FindLogisticsRecordsData([FromQuery] string deliveryNoteID)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllLogisticsData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentNoteID = row["deliveryNoteID"]?.ToString() ?? "";
                if (currentNoteID.Trim() == deliveryNoteID.Trim())
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateLogisticsRecordsData")]
        public int UpdateLogisticsRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE logistics_shipments SET 
                            driverName = '{row["driverName"]?.Replace("'", "''")}',
                            replySlipReceived = '{row["replySlipReceived"]}',
                            conditionReport = '{row["conditionReport"]?.Replace("'", "''")}'
                            WHERE deliveryNoteID = {row["deliveryNoteID"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //PRODUCTION TABLE

        [HttpGet("GetProductionRecordsData")]
        public string GetProductionRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllProductionData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindProductionRecordsData")]
        public string FindProductionRecordsData([FromQuery] string targetItemID)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllProductionData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentItem = row["targetItemID"]?.ToString() ?? "";
                if (currentItem.IndexOf(targetItemID, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                    list.Add(dict);
                }
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateProductionRecordsData")]
        public int UpdateProductionRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE production_requests SET 
                            quantityRequested = {row["quantityRequested"]},
                            status = '{row["status"]}'
                            WHERE requestID = {row["requestID"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }

        //SUPPLIER TABLE

        [HttpGet("GetSupplierRecordsData")]
        public string GetSupplierRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllProcurementData(); // We will use your existing database worker instance

            // Fallback query override to pull supplier list safely
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);
            DataTable dtSuppliers = db.GetData("SELECT * FROM suppliers");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtSuppliers.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtSuppliers.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindSupplierRecordsData")]
        public string FindSupplierRecordsData([FromQuery] string supplierName)
        {
            string connString = _configuration["ConnectionStrings"];
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);
            DataTable dtResult = db.GetData($"SELECT * FROM suppliers WHERE supplierName LIKE '%{supplierName.Replace("'", "''")}%'");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("UpdateSupplierRecordsData")]
        public int UpdateSupplierRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                string sqlUpdate = $@"UPDATE suppliers SET 
                            supplierName = '{row["supplierName"]?.Replace("'", "''")}',
                            contactName = '{row["contactName"]?.Replace("'", "''")}',
                            phone = '{row["phone"]?.Replace("'", "''")}',
                            address = '{row["address"]?.Replace("'", "''")}'
                            WHERE supplierID = {row["supplierID"]};";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }
        // --- NEW ENDPOINT: GET CUSTOMER ADDRESS ---
        // URL Path: GET https://localhost:7146/api/SimpleGetAPI/GetCustomerAddress?customerNumber=103
        [HttpGet("GetCustomerAddress")]
        public string GetCustomerAddress([FromQuery] int customerNumber)
        {
            string connString = _configuration["ConnectionStrings"];
            string query = "SELECT floor, building, street, city, country FROM customer WHERE customerNumber = @custNum";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var result = new Dictionary<string, string>
                                {
                                    { "floor", reader["floor"] != DBNull.Value ? reader["floor"].ToString() : "" },
                                    { "building", reader["building"] != DBNull.Value ? reader["building"].ToString() : "" },
                                    { "street", reader["street"] != DBNull.Value ? reader["street"].ToString() : "" },
                                    { "city", reader["city"].ToString() },
                                    { "country", reader["country"].ToString() }
                                };
                                return JsonSerializer.Serialize(result);
                            }
                        }
                    }
                    return "FAILED_NOT_FOUND";
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }

        // --- NEW ENDPOINT: UPDATE CUSTOMER ADDRESS ---
        // URL Path: POST https://localhost:7146/api/SimpleGetAPI/UpdateCustomerAddress
        [HttpPost("UpdateCustomerAddress")]
        public string UpdateCustomerAddress([FromBody] Dictionary<string, string> payload)
        {
            if (payload == null || !payload.ContainsKey("customerNumber") || !int.TryParse(payload["customerNumber"], out int customerNumber))
            {
                return "FAILED_INVALID_PAYLOAD";
            }

            string connString = _configuration["ConnectionStrings"];
            string query = "UPDATE customer SET floor = @floor, building = @building, street = @street, city = @city, country = @country WHERE customerNumber = @custNum";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        string floor = payload.GetValueOrDefault("floor")?.Trim();
                        string building = payload.GetValueOrDefault("building")?.Trim();
                        string street = payload.GetValueOrDefault("street")?.Trim();
                        string city = payload.GetValueOrDefault("city")?.Trim();
                        string country = payload.GetValueOrDefault("country")?.Trim();

                        if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
                        {
                            return "FAILED_MANDATORY_FIELDS_MISSING";
                        }

                        cmd.Parameters.AddWithValue("@floor", string.IsNullOrEmpty(floor) ? DBNull.Value : (object)floor);
                        cmd.Parameters.AddWithValue("@building", string.IsNullOrEmpty(building) ? DBNull.Value : (object)building);
                        cmd.Parameters.AddWithValue("@street", string.IsNullOrEmpty(street) ? DBNull.Value : (object)street);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@country", country);
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "SUCCESS" : "FAILED_NO_ROWS_AFFECTED";
                    }
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }
        // --- NEW ENDPOINT: GET CUSTOMER PAYMENT ---
        // URL 路徑: GET https://localhost:7146/api/SimpleGetAPI/GetCustomerPayment?customerNumber=103
        [HttpGet("GetCustomerPayment")]
        public string GetCustomerPayment([FromQuery] int customerNumber)
        {
            string connString = _configuration["ConnectionStrings"];
            string query = "SELECT cardNumber, expiredDay, cvv FROM customer WHERE customerNumber = @custNum";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var result = new Dictionary<string, string>
                                {
                                    { "cardNumber", reader["cardNumber"] != DBNull.Value ? reader["cardNumber"].ToString() : "" },
                                    { "expiredDay", reader["expiredDay"] != DBNull.Value ? reader["expiredDay"].ToString() : "" },
                                    { "cvv", reader["cvv"] != DBNull.Value ? reader["cvv"].ToString() : "" }
                                };
                                return JsonSerializer.Serialize(result);
                            }
                        }
                    }
                    return "FAILED_NOT_FOUND";
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }

        // --- NEW ENDPOINT: UPDATE CUSTOMER PAYMENT ---
        // URL 路徑: POST https://localhost:7146/api/SimpleGetAPI/UpdateCustomerPayment
        [HttpPost("UpdateCustomerPayment")]
        public string UpdateCustomerPayment([FromBody] Dictionary<string, string> payload)
        {
            if (payload == null || !payload.ContainsKey("customerNumber") || !int.TryParse(payload["customerNumber"], out int customerNumber))
            {
                return "FAILED_INVALID_PAYLOAD";
            }

            string connString = _configuration["ConnectionStrings"];
            string query = "UPDATE customer SET cardNumber = @card, expiredDay = @expired, cvv = @cvv WHERE customerNumber = @custNum";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        string cardNumber = payload.GetValueOrDefault("cardNumber")?.Trim();
                        string expiredDay = payload.GetValueOrDefault("expiredDay")?.Trim();
                        string cvv = payload.GetValueOrDefault("cvv")?.Trim();

                        // 驗證必要欄位是否遺漏
                        if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiredDay) || string.IsNullOrEmpty(cvv))
                        {
                            return "FAILED_MANDATORY_FIELDS_MISSING";
                        }

                        cmd.Parameters.AddWithValue("@card", cardNumber);
                        cmd.Parameters.AddWithValue("@expired", expiredDay);
                        cmd.Parameters.AddWithValue("@cvv", cvv);
                        cmd.Parameters.AddWithValue("@custNum", customerNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0 ? "SUCCESS" : "FAILED_NO_ROWS_AFFECTED";
                    }
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }


        //USER_SUPPLIER TABLE

        [HttpGet("GetUserAccountRecordsData")]
        public string GetUserAccountRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);

            // Added customerID to query selection string
            DataTable dtResult = db.GetData("SELECT username, passwordHash, staffID, customerID, accessLevel FROM user_accounts");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("FindUserAccountRecordsData")]
        public string FindUserAccountRecordsData([FromQuery] string username)
        {
            string connString = _configuration["ConnectionStrings"];
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);

            // Added customerID to query selection string
            DataTable dtResult = db.GetData($"SELECT username, passwordHash, staffID, customerID, accessLevel FROM user_accounts WHERE username LIKE '%{username.Replace("'", "''")}%'");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }
        [HttpPost("UpdateUserAccountRecordsData")]
        public int UpdateUserAccountRecordsData([FromBody] SDP_EntityModels.JsonDataTable json)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                int totalProcessedRows = 0;

                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
                        {
                            conn.Open();
                            foreach (var row in modifiedRows)
                            {
                                // Handle the Staff foreign key context cleanly (Avoid putting explicit empty string '' if null)
                                string staffIdRaw = row.ContainsKey("staffID") ? row["staffID"] : null;
                                string staffSqlValue = string.IsNullOrEmpty(staffIdRaw) ? "NULL" : $"'{staffIdRaw.Replace("'", "''")}'";

                                // Handle the Customer foreign key context cleanly (Avoid putting explicit empty string '' if null)
                                string customerIdRaw = row.ContainsKey("customerID") ? row["customerID"] : null;
                                string customerSqlValue = string.IsNullOrEmpty(customerIdRaw) ? "NULL" : $"'{customerIdRaw.Replace("'", "''")}'";

                                // Modified SQL layout structure to integrate staffID updates and customerID updates securely
                                string sqlUpdate = $@"UPDATE user_accounts SET 
                            passwordHash = '{row["passwordHash"]?.Replace("'", "''")}',
                            staffID = {staffSqlValue},
                            customerID = {customerSqlValue},
                            accessLevel = '{row["accessLevel"]?.Replace("'", "''")}'
                            WHERE username = '{row["username"]?.Replace("'", "''")}';";

                                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                totalProcessedRows++;
                            }
                        }
                    }
                }
                return totalProcessedRows;
            }
            catch (Exception) { return 0; }
        }
        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder([FromBody] CancelOrderRequest request)
        {
            if (request == null || request.OrderNumber <= 0)
            {
                return BadRequest("Invalid order verification structure.");
            }

            try
            {
                string connString = _configuration["ConnectionStrings"];

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    await conn.OpenAsync();

                    // Step 1: Query database state to assert data invariants
                    string statusCheckQuery = "SELECT orderStatus FROM orders WHERE orderNumber = @orderNumber;";
                    string currentStatus = null;

                    using (MySqlCommand checkCmd = new MySqlCommand(statusCheckQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@orderNumber", request.OrderNumber);
                        object result = await checkCmd.ExecuteScalarAsync();

                        if (result == null)
                        {
                            return NotFound("The specified order number does not exist.");
                        }
                        currentStatus = result.ToString();
                    }

                    // Step 2: Validate against business state workflows 
                    if (currentStatus == "Cancelled")
                    {
                        return BadRequest("This order has already been cancelled.");
                    }

                    if (currentStatus == "Shipped")
                    {
                        return BadRequest("This order has already been shipped and cannot be cancelled.");
                    }

                    // Step 3: Run target safe mutation
                    string updateQuery = "UPDATE orders SET orderStatus = 'Cancelled' WHERE orderNumber = @orderNumber;";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@orderNumber", request.OrderNumber);
                        await updateCmd.ExecuteNonQueryAsync();
                    }
                }

                return Ok("Order successfully cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cancel Order Error: " + ex.Message);
                return StatusCode(500, $"An error occurred during mutation: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) matching the anonymous payload serialized by the frontend.
    /// </summary>
    public class CancelOrderRequest
    {
        // System.Text.Json uses case-insensitive matching by default, 
        // mapping 'orderNumber' from frontend to this property.
        public int OrderNumber { get; set; }
    }

}


