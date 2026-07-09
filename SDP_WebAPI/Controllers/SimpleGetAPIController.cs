using DatabaseAccessController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SDP_EntityModels;
using System;
using System.Data;
using System.Text.Json;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

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
        // URL: GET https://localhost:7146/api/SimpleGetAPI/GetItemPrice?itemID=FG001
        [HttpGet("GetItemPrice")]
        public string GetItemPrice([FromQuery] string itemID)
        {
            double price = 0.0;
            switch (itemID)
            {
                case "FG001": price = 1500.00; break; // Ergonomic Office Chair
                case "FG002": price = 5000.00; break; // Mahogany Dining Table
                case "FG003": price = 4450.00; break; // 3-Seater Velvet Sofa
                case "FG004": price = 1250.00; break; // Minimalist Study Desk
                case "FG005": price = 1550.00; break; // Modular Bookcase Rack
                default: price = 0.0; break;
            }
            return price.ToString();
        }

        // URL: POST https://localhost:7146/api/SimpleGetAPI/SubmitOrder
        [HttpPost("SubmitOrder")]
        public string SubmitOrder([FromBody] Dictionary<string, string> payload)
        {
            if (payload == null ||
                !payload.ContainsKey("customerNumber") ||
                !payload.ContainsKey("itemID") ||
                !payload.ContainsKey("quantity"))
            {
                return "FAILED_INVALID_PAYLOAD";
            }

            int customerNumber = int.Parse(payload["customerNumber"]);
            string itemID = payload["itemID"];
            int quantity = int.Parse(payload["quantity"]);

            double unitPrice = 0.0;
            switch (itemID)
            {
                case "FG001": unitPrice = 1500.00; break;
                case "FG002": unitPrice = 5000.00; break;
                case "FG003": unitPrice = 4450.00; break;
                case "FG004": unitPrice = 1250.00; break;
                case "FG005": unitPrice = 1550.00; break;
            }
            double totalAmount = unitPrice * quantity;
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string connString = _configuration["ConnectionStrings"];

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlCheckStock = "SELECT quantityInStock FROM inventory WHERE itemID = @itemID FOR UPDATE;";
                        int currentStock = 0;
                        using (MySqlCommand cmdCheck = new MySqlCommand(sqlCheckStock, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@itemID", itemID);
                            object stockObj = cmdCheck.ExecuteScalar();
                            if (stockObj == null) return "FAILED_ITEM_NOT_FOUND";
                            currentStock = Convert.ToInt32(stockObj);
                        }

                        if (currentStock < quantity)
                        {
                            return $"FAILED_INSUFFICIENT_STOCK:Available={currentStock}";
                        }

                        string sqlOrder = "INSERT INTO `orders` (`orderDate`, `customerNumber`, `totalAmount`, `orderStatus`) " +
                                          "VALUES (@orderDate, @custNum, @totalAmount, 'Pending'); SELECT LAST_INSERT_ID();";
                        long newOrderNumber = 0;
                        using (MySqlCommand cmdOrder = new MySqlCommand(sqlOrder, conn, trans))
                        {
                            cmdOrder.Parameters.AddWithValue("@orderDate", currentDate);
                            cmdOrder.Parameters.AddWithValue("@custNum", customerNumber);
                            cmdOrder.Parameters.AddWithValue("@totalAmount", totalAmount);
                            newOrderNumber = Convert.ToInt64(cmdOrder.ExecuteScalar());
                        }

                        string sqlDetails = "INSERT INTO `order_details` (`orderNumber`, `itemID`, `quantity`, `unitPrice`) " +
                                            "VALUES (@orderNum, @itemID, @quantity, @unitPrice);";
                        using (MySqlCommand cmdDetails = new MySqlCommand(sqlDetails, conn, trans))
                        {
                            cmdDetails.Parameters.AddWithValue("@orderNum", newOrderNumber);
                            cmdDetails.Parameters.AddWithValue("@itemID", itemID);
                            cmdDetails.Parameters.AddWithValue("@quantity", quantity);
                            cmdDetails.Parameters.AddWithValue("@unitPrice", unitPrice);
                            cmdDetails.Parameters.AddWithValue("@totalAmount", totalAmount);
                            cmdDetails.ExecuteNonQuery();
                        }

                        string sqlUpdateStock = "UPDATE inventory SET quantityInStock = quantityInStock - @quantity WHERE itemID = @itemID;";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdateStock, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@quantity", quantity);
                            cmdUpdate.Parameters.AddWithValue("@itemID", itemID);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return $"SUCCESS:{newOrderNumber}";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return $"ERROR:{ex.Message}";
                    }
                }
            }
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

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
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

                        // Removed state and postalCode to match the schema from samplecompany (1) (2).sql
                        string sqlInsertCustomer = @"INSERT INTO customer 
            (customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1, addressLine2, city, country, staffID, creditLimit) 
            VALUES 
            (@customerNumber, @customerName, @contactLastName, @contactFirstName, @phone, 'Unknown', NULL, @city, @country, NULL, NULL);";

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

                        string sqlInsertAccount = @"INSERT INTO user_accounts (username, passwordHash, staffID, customerID, accessLevel) 
                                    VALUES (@username, @passwordHash, NULL, @customerID, 'Customer');";

                        using (MySql.Data.MySqlClient.MySqlCommand cmdAcc = new MySql.Data.MySqlClient.MySqlCommand(sqlInsertAccount, conn, transaction))
                        {
                            cmdAcc.Parameters.AddWithValue("@username", username);
                            cmdAcc.Parameters.AddWithValue("@passwordHash", password);
                            cmdAcc.Parameters.AddWithValue("@customerID", newCustomerNumber);

                            cmdAcc.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        return $"SUCCESS_REGISTERED:{firstname},{newCustomerNumber}";
                    }
                    catch (Exception ex)
                    {
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
        // URL: GET https://localhost:7146/api/SimpleGetAPI/GetOrderHistory?customerNumber=103
        [HttpGet("GetOrderHistory")]
        public string GetOrderHistory([FromQuery] int customerNumber)
        {
            string connString = _configuration["ConnectionStrings"];

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

        // URL: GET https://localhost:7146/api/SimpleGetAPI/SearchOrderHistory?customerNumber=103&keyword=Shipped
        [HttpGet("SearchOrderHistory")]
        public string SearchOrderHistory([FromQuery] int customerNumber, [FromQuery] string keyword)
        {
            string connString = _configuration["ConnectionStrings"];

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
                                // Handle potential NULL or empty values for the new foreign key
                                string customID = (string.IsNullOrEmpty(row["customizeRequiredID"]) || row["customizeRequiredID"] == "NULL")
                                                  ? "NULL" : row["customizeRequiredID"];

                                string sqlUpdate = $@"UPDATE orders SET 
                            orderStatus = '{row["orderStatus"]}',
                            totalAmount = {row["totalAmount"]},
                            customizeRequiredID = {customID}
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
            catch (Exception ex) { return 0; }
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

        [HttpPost("AddStaff")]
        public IActionResult AddStaff([FromBody] StaffRequest request)
        {
            string connString = _configuration["ConnectionStrings"];
            var dbo = new GetCompanyData(connString);

            int result = dbo.AddNewStaff(request.StaffID, request.FullName, request.Role, request.Department, request.Email);

            return result > 0 ? Ok("Staff added successfully.") : BadRequest("Failed to add staff.");
        }

        // Add this class at the bottom of the controller
        public class StaffRequest
        {
            public string StaffID { get; set; }
            public string FullName { get; set; }
            public string Role { get; set; }
            public string Department { get; set; }
            public string Email { get; set; }
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

        [HttpPost("AddSupplier")]
        public string AddSupplier([FromBody] Dictionary<string, string> payload)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                string sqlInsert = @"INSERT INTO suppliers (supplierName, contactName, phone, address) 
                             VALUES (@name, @contact, @phone, @address);";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", payload["SupplierName"]);
                        cmd.Parameters.AddWithValue("@contact", payload["ContactPerson"]);
                        cmd.Parameters.AddWithValue("@phone", payload["Phone"]);
                        cmd.Parameters.AddWithValue("@address", payload["Address"]);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return $"ERROR:{ex.Message}";
            }
        }

        public class SupplierRequest
        {
            // SupplierID is removed from here   
            public string SupplierName { get; set; }
            public string ContactName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
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


        /// <summary>
        /// Data Transfer Object (DTO) matching the anonymous payload serialized by the frontend.
        /// </summary>
        public class CancelOrderRequest
        {
            // System.Text.Json uses case-insensitive matching by default, 
            // mapping 'orderNumber' from frontend to this property.
            public int OrderNumber { get; set; }
        }


        [HttpGet("GetCustomerName/{customerId}")]
        public IActionResult GetCustomerName(int customerId)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);

            string sqlCmd = $"SELECT customerName FROM customer WHERE customerNumber = {customerId}";
            DataTable dt = dboGetCompanyData.GetData(sqlCmd);

            if (dt != null && dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["customerName"]?.ToString() ?? "Customer";
                return Ok(new { customerName = name });
            }

            return NotFound("Customer not found");
        }


        [HttpPost("ChangePassword")]
        public string ChangePassword([FromQuery] string customerId, [FromQuery] string oldPassword, [FromQuery] string newPassword)
        {
            string connString = _configuration["ConnectionStrings"];

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();

                string sqlCheck = "SELECT passwordHash FROM user_accounts WHERE customerID = @customerID;";
                using (MySql.Data.MySqlClient.MySqlCommand cmdCheck = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@customerID", customerId);
                    object result = cmdCheck.ExecuteScalar();

                    if (result == null)
                    {
                        return "FAILED_USER_NOT_FOUND";
                    }

                    string storedPassword = result.ToString();
                    if (storedPassword != oldPassword)
                    {
                        return "FAILED_OLD_PASSWORD_INVALID";
                    }
                }

                string sqlUpdate = "UPDATE user_accounts SET passwordHash = @newPassword WHERE customerID = @customerID;";
                using (MySql.Data.MySqlClient.MySqlCommand cmdUpdate = new MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@newPassword", newPassword);
                    cmdUpdate.Parameters.AddWithValue("@customerID", customerId);

                    int rows = cmdUpdate.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "SUCCESS_PASSWORD_UPDATED";
                    }

                    return "FAILED_UPDATE";
                }
            }
        }
        //CUSTOMIZE
        [HttpGet("GetCustomizeRecordsData")]
        public string GetCustomizeRecordsData()
        {
            string connString = _configuration["ConnectionStrings"];
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);

            // Fetching all columns from the Customize table
            DataTable dtResult = db.GetData("SELECT customizeID, customerID, type, color, size, desktopMaterialID, desktopMaterialName, legMaterialID, legMaterialName, description, file, price, newPrice,status,ispay FROM Customize");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpGet("CheckCustomizeRequired")]
        public bool CheckCustomizeRequired(int customizeID)
        {
            string connString = _configuration["ConnectionStrings"];
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                // Check if the record exists for the provided ID
                string query = "SELECT COUNT(*) FROM CustomizeRequired WHERE customizeID = @cID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cID", customizeID);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        [HttpGet("FindCustomizeRecordsData")]
        public string FindCustomizeRecordsData([FromQuery] string customizeID)
        {
            string connString = _configuration["ConnectionStrings"];
            DatabaseAccessController.DatabaseController db = new DatabaseAccessController.DatabaseController(connString);

            // Using customizeID for filtering
            DataTable dtResult = db.GetData($"SELECT customizeID, customerID, type, color, size, desktopMaterialID, desktopMaterialName, legMaterialID, legMaterialName, description, file, price,status FROM Customize WHERE customizeID = '{customizeID.Replace("'", "''")}'");

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns) dict[col.ColumnName] = row[col].ToString();
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }

        [HttpPost("RejectCustomizeOrder")]
        public IActionResult RejectCustomizeOrder([FromBody] Dictionary<string, string> payload)
        {
            if (payload.ContainsKey("customizeID") && int.TryParse(payload["customizeID"], out int id))
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                // 1. Fetch material usage from CustomizeRequired BEFORE deleting it
                string getSql = $"SELECT desktopMaterialID, desktopQty, legMaterialID, legQty FROM CustomizeRequired WHERE customizeID = {id}";
                DataTable dt = db.GetData(getSql);

                if (dt.Rows.Count > 0)
                {
                    string dID = dt.Rows[0]["desktopMaterialID"].ToString();
                    int dQty = Convert.ToInt32(dt.Rows[0]["desktopQty"]);
                    string lID = dt.Rows[0]["legMaterialID"].ToString();
                    int lQty = Convert.ToInt32(dt.Rows[0]["legQty"]);

                    // 2. Add the quantities back to inventory
                    db.BatchUpdate($"UPDATE inventory SET quantityInStock = quantityInStock + {dQty} WHERE itemID = '{dID}'");
                    db.BatchUpdate($"UPDATE inventory SET quantityInStock = quantityInStock + {lQty} WHERE itemID = '{lID}'");

                    // 3. Now delete the CustomizeRequired record
                    GetCompanyData dbo = new GetCompanyData(connString);
                    dbo.DeleteCustomizeRequired(id);
                }

                // 4. Update the status of the Customize record to rejected
                GetCompanyData dboStatus = new GetCompanyData(connString);
                int result = dboStatus.UpdateCustomizeStatus(id, "rejected");

                return result > 0 ? Ok("Order rejected and stock restored.") : BadRequest("Status update failed.");
            }
            return BadRequest("Invalid customizeID.");
        }

        [HttpPost("ConfirmCustomizeOrder")]
        public string ConfirmCustomizeOrder([FromBody] Dictionary<string, string> payload)
        {
            string priceCol;
            string ispay = payload["ispay"];
            string connString = _configuration["ConnectionStrings"];
            bool isExisting = bool.Parse(payload["isExisting"]);
            if (ispay == "yes")
            {
                 priceCol = isExisting ? "newPrice" : "price";
            }
            else {
                 priceCol = "price";
            }
                string status = "determined";

            int cID = int.Parse(payload["customizeID"]);
            int dQty = int.Parse(payload["desktopQty"]);
            int lQty = int.Parse(payload["legQty"]);
            string dMat = payload["desktopMaterialID"];
            string lMat = payload["legMaterialID"];
            string description = payload["des"];

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // Inventory Check Function
                bool IsStockAvailable(string itemId, int requestedQty, out string errorMsg)
                {
                    errorMsg = "";
                    string checkSql = "SELECT quantityInStock FROM inventory WHERE itemID = @id";
                    int currentStock = 0;

                    using (MySqlCommand cmd = new MySqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", itemId);
                        var result = cmd.ExecuteScalar();
                        currentStock = result != null ? Convert.ToInt32(result) : 0;
                    }

                    if (isExisting)
                    {
                        string getOldQtySql = @"SELECT IF(desktopMaterialID = @id, desktopQty, legQty) 
                                        FROM CustomizeRequired WHERE customizeID = @cID 
                                        AND (desktopMaterialID = @id OR legMaterialID = @id)";
                        using (MySqlCommand cmd = new MySqlCommand(getOldQtySql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", itemId);
                            cmd.Parameters.AddWithValue("@cID", cID);
                            var oldQty = cmd.ExecuteScalar();
                            if (oldQty != null) currentStock += Convert.ToInt32(oldQty);
                        }
                    }

                    if (currentStock < requestedQty)
                    {
                        errorMsg = $"Insufficient stock for material ID: {itemId}. Available: {currentStock}, Requested: {requestedQty}.";
                        return false;
                    }
                    return true;
                }

                // Validate both
                if (!IsStockAvailable(dMat, dQty, out string dErr)) return dErr;
                if (!IsStockAvailable(lMat, lQty, out string lErr)) return lErr;

                // Transaction
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (isExisting)
                        {
                            string revertSql = @"UPDATE inventory i JOIN CustomizeRequired cr ON i.itemID = cr.desktopMaterialID OR i.itemID = cr.legMaterialID 
                                         SET i.quantityInStock = i.quantityInStock + IF(i.itemID = cr.desktopMaterialID, cr.desktopQty, cr.legQty) 
                                         WHERE cr.customizeID = @cID";
                            using (MySqlCommand cmd = new MySqlCommand(revertSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@cID", cID);
                                cmd.ExecuteNonQuery();
                            }

                            string updateReqSql = @"UPDATE CustomizeRequired SET desktopMaterialID = @dMat, desktopQty = @dQty, legMaterialID = @lMat, legQty = @lQty, type = @type, size = @size, color = @color ,description = @description WHERE customizeID = @cID";
                            using (MySqlCommand cmd = new MySqlCommand(updateReqSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@dMat", dMat);
                                cmd.Parameters.AddWithValue("@dQty", dQty);
                                cmd.Parameters.AddWithValue("@lMat", lMat);
                                cmd.Parameters.AddWithValue("@lQty", lQty);
                                cmd.Parameters.AddWithValue("@type", payload["type"]);
                                cmd.Parameters.AddWithValue("@size", payload["size"]);
                                cmd.Parameters.AddWithValue("@color", payload["color"]);
                                cmd.Parameters.AddWithValue("@description", description);
                                cmd.Parameters.AddWithValue("@cID", cID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertSql = @"INSERT INTO CustomizeRequired (customizeID, desktopMaterialID, desktopQty, legMaterialID, legQty, type, size, color) 
                                         VALUES (@cID, @dMat, @dQty, @lMat, @lQty, @type, @size, @color)";
                            using (MySqlCommand cmd = new MySqlCommand(insertSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@cID", cID);
                                cmd.Parameters.AddWithValue("@dMat", dMat);
                                cmd.Parameters.AddWithValue("@dQty", dQty);
                                cmd.Parameters.AddWithValue("@lMat", lMat);
                                cmd.Parameters.AddWithValue("@lQty", lQty);
                                cmd.Parameters.AddWithValue("@type", payload["type"]);
                                cmd.Parameters.AddWithValue("@size", payload["size"]);
                                cmd.Parameters.AddWithValue("@color", payload["color"]);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        string deductSql = "UPDATE inventory SET quantityInStock = quantityInStock - @qty WHERE itemID = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deductSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", dQty);
                            cmd.Parameters.AddWithValue("@id", dMat);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters["@qty"].Value = lQty;
                            cmd.Parameters["@id"].Value = lMat;
                            cmd.ExecuteNonQuery();
                        }

                        string updateCustSql = $"UPDATE Customize SET status = @status, {priceCol} = @price WHERE customizeID = @cID";
                        using (MySqlCommand cmd = new MySqlCommand(updateCustSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@price", double.Parse(payload["price"]));
                            cmd.Parameters.AddWithValue("@cID", cID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return "SUCCESS";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "ERROR: " + ex.Message;
                    }
                }
            }
        }

        [HttpGet("FindCustomizeRequiredData")]
        public IActionResult FindCustomizeRequiredData([FromQuery] string searchTerm)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                GetCompanyData dbo = new GetCompanyData(connString);
                DataTable dt = dbo.GetAllCustomizeRequiredData();

                // Convert DataTable rows into a list of dictionaries
                var rows = dt.AsEnumerable().Where(row =>
                    row["customizeID"].ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    row["description"]?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true
                ).Select(row => {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        dict[col.ColumnName] = row[col];
                    }
                    return dict;
                }).ToList();

                return Ok(rows); // Now returning a list of dictionaries, which is serializable
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetCustomizeRequiredData")]
        public string GetCustomizeRequiredData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dbo = new GetCompanyData(connString);
            DataTable dt = dbo.GetAllCustomizeRequiredData();

            // Convert DataTable to a clean List of Dictionaries
            var list = new List<Dictionary<string, string>>();
            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, string>();
                foreach (DataColumn col in dt.Columns)
                {
                    // Use .ToString() to ensure only values are serialized, not the Type
                    dict[col.ColumnName] = row[col]?.ToString() ?? "";
                }
                list.Add(dict);
            }

            // Serialize the list of dictionaries instead of the DataTable
            return JsonSerializer.Serialize(list);
        }


        [HttpPost("SaveCustomization")]
        public IActionResult SaveCustomization([FromBody] JsonElement data)
        {
            string connString = _configuration["ConnectionStrings"];
            var db = new DatabaseController(connString);

            // Safely extract properties
            string cID = data.TryGetProperty("customizeID", out var cid) ? cid.GetString() : null;
            string customerID = data.GetProperty("customerID").GetString();
            string type = data.GetProperty("type").GetString();
            string color = data.GetProperty("color").GetString();
            string size = data.GetProperty("size").GetString();
            string dID = data.GetProperty("desktopMaterialID").ToString();
            string lID = data.GetProperty("legMaterialID").ToString();
            string desc = data.GetProperty("description").GetString();
            string dName = data.GetProperty("desktopMaterialName").GetString();
            string lName = data.GetProperty("legMaterialName").GetString();

            string sql;

            // Use TryParse to ensure the ID is a valid number for the database INT column
            if (int.TryParse(cID, out int validCID) && validCID > 0)
            {
                // UPDATE Logic
                sql = $@"UPDATE Customize SET 
                 type = '{type.Replace("'", "''")}', 
                 color = '{color.Replace("'", "''")}', 
                 size = '{size.Replace("'", "''")}', 
                 desktopMaterialID = '{dID.Replace("'", "''")}', 
                 desktopMaterialName = '{dName.Replace("'", "''")}', 
                 legMaterialID = '{lID.Replace("'", "''")}', 
                 legMaterialName = '{lName.Replace("'", "''")}', 
                 description = '{desc.Replace("'", "''")}', 
                 status = 'edited' 
                 WHERE customizeID = {validCID}";
            }
            else
            {
                // INSERT Logic (if ID is null or 0)
                sql = $@"INSERT INTO Customize (customerID, type, color, size, desktopMaterialID, desktopMaterialName, legMaterialID, legMaterialName, description, status,ispay) 
                 VALUES ('{customerID}', '{type.Replace("'", "''")}', '{color.Replace("'", "''")}', '{size.Replace("'", "''")}', 
                         '{dID.Replace("'", "''")}', '{dName.Replace("'", "''")}', '{lID.Replace("'", "''")}', 
                         '{lName.Replace("'", "''")}', '{desc.Replace("'", "''")}', 'processing','no')";
            }

            int rowsAffected = db.BatchUpdate(sql);

            if (rowsAffected > 0)
                return Ok("SUCCESS");
            else
                return BadRequest("Database operation failed or no rows affected.");
        }


        [HttpPost("ShipOrderAndCompleteCustomization")]
        public IActionResult ShipOrderAndCompleteCustomization([FromQuery] int orderNumber, [FromQuery] int customizeRequiredID)
        {
            string connString = _configuration["ConnectionStrings"];
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Validation: Fetch statuses
                        string validateSql = @"
                    SELECT o.orderStatus AS oStatus, c.status AS cStatus, c.customizeID
                    FROM orders o
                    LEFT JOIN Customize c ON o.customizeRequiredID = c.customizeID
                    WHERE o.orderNumber = @orderNum AND o.customizeRequiredID = @reqID";

                        int foundCustomizeID = -1;
                        using (MySqlCommand cmdCheck = new MySqlCommand(validateSql, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@orderNum", orderNumber);
                            cmdCheck.Parameters.AddWithValue("@reqID", customizeRequiredID);
                            using (var reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string oStatus = reader["oStatus"].ToString();
                                    string cStatus = reader["cStatus"] != DBNull.Value ? reader["cStatus"].ToString() : "N/A";
                                    foundCustomizeID = reader["customizeID"] != DBNull.Value ? Convert.ToInt32(reader["customizeID"]) : -1;

                                    if (!string.Equals(oStatus, "Processing", StringComparison.OrdinalIgnoreCase))
                                        throw new Exception($"Cannot ship: Order status is '{oStatus}' (Must be 'Processing').");

                                    if (cStatus != "accepted" && cStatus != "N/A")
                                        throw new Exception($"Cannot ship: Customization status is '{cStatus}' (Must be 'accepted').");
                                }
                                else { throw new Exception("Order or Customization record not found."); }
                            }
                        }

                        // 2. Update Order to 'Shipped'
                        string updateOrderSql = "UPDATE orders SET orderStatus = 'Shipped' WHERE orderNumber = @orderNum";
                        using (MySqlCommand cmdOrder = new MySqlCommand(updateOrderSql, conn, trans))
                        {
                            cmdOrder.Parameters.AddWithValue("@orderNum", orderNumber);
                            cmdOrder.ExecuteNonQuery();
                        }

                        // 3. Update Customize record to 'done' (if a valid record was found)
                        if (foundCustomizeID != -1)
                        {
                            string updateCustSql = "UPDATE Customize SET status = 'done' WHERE customizeID = @cID";
                            using (MySqlCommand cmdCust = new MySqlCommand(updateCustSql, conn, trans))
                            {
                                cmdCust.Parameters.AddWithValue("@cID", foundCustomizeID);
                                cmdCust.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return Ok("SUCCESS");
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return BadRequest(ex.Message);
                    }
                }
            }
        }

        [HttpGet("GetCustomizeHistory")]
        public string GetCustomizeHistory()
        {
            string connString = _configuration["ConnectionStrings"];
            // Using your existing GetCompanyData class structure
            GetCompanyData dbo = new GetCompanyData(connString);
            DataTable dt = dbo.GetCustomizeRecordsData();

            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    // Specifically mapping the columns from your CREATE TABLE statement
                    dict[col.ColumnName] = row[col].ToString();
                }
                list.Add(dict);
            }
            return System.Text.Json.JsonSerializer.Serialize(list);
        }


        [HttpPost("UpdateCustomizeStatus")]
        public IActionResult UpdateCustomizeStatus([FromQuery] string customizeID, [FromQuery] string newStatus)
        {
            string connString = _configuration["ConnectionStrings"];
            var db = new DatabaseAccessController.DatabaseController(connString);
            db.BatchUpdate($"UPDATE Customize SET status = '{newStatus}' WHERE customizeID = {customizeID}");
            return Ok();
        }






        //Production And purchasing

        [HttpPost("CreateProductionRequest")]
        public IActionResult CreateProductionRequest(
    [FromQuery] string targetItemID,
    [FromQuery] string rawMaterialID,
    [FromQuery] int quantityRequested)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                // Uses your schema: requestDate, targetItemID, rawMaterialID, quantityRequested, status
                string sql = $@"INSERT INTO production_requests 
                        (requestDate, targetItemID, rawMaterialID, quantityRequested, status) 
                        VALUES ('{DateTime.Now:yyyy-MM-dd}', '{targetItemID}', '{rawMaterialID}', {quantityRequested}, 'Allocated')";

                int result = db.BatchUpdate(sql);
                return result > 0 ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateProcurement")]
        public IActionResult CreateProcurement(
    [FromQuery] int supplierID,
    [FromQuery] string rawMaterialID,
    [FromQuery] int quantityOrdered,
    [FromQuery] DateTime expectedDelivery)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                // SQL using current date for orderDate and defaulting status to 'Ordered'
                string sql = $@"INSERT INTO procurements 
                        (orderDate, supplierID, rawMaterialID, quantityOrdered, expectedDelivery, status) 
                        VALUES ('{DateTime.Now:yyyy-MM-dd}', {supplierID}, '{rawMaterialID}', {quantityOrdered}, '{expectedDelivery:yyyy-MM-dd}', 'Ordered')";

                int result = db.BatchUpdate(sql);
                return result > 0 ? Ok(new { message = "Procurement created successfully." }) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateProductionToFulfilled")]
        public IActionResult UpdateProductionToFulfilled([FromQuery] int requestID)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                // 1. Fetch data
                string getSql = $"SELECT targetItemID, quantityRequested FROM production_requests WHERE requestID = {requestID}";
                DataTable dt = db.GetData(getSql);

                if (dt.Rows.Count > 0)
                {
                    string itemID = dt.Rows[0]["targetItemID"].ToString();
                    int qty = Convert.ToInt32(dt.Rows[0]["quantityRequested"]);

                    // 2. Combine updates in one string for the MySQL driver to handle in one execution context
                    string sql = $@"UPDATE inventory SET quantityInStock = quantityInStock + {qty} WHERE itemID = '{itemID}';
                            UPDATE production_requests SET status = 'Fulfilled' WHERE requestID = {requestID};";

                    int result = db.BatchUpdate(sql); // Ensure your DatabaseController handles semicolon-separated statements
                    return result > 0 ? Ok() : StatusCode(500, "Update failed");
                }
                return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("UpdateProcurementToDelivered")]
        public IActionResult UpdateProcurementToDelivered([FromQuery] int procurementID)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                // 1. Get rawMaterialID and quantityOrdered for the selected procurement
                string getSql = $"SELECT rawMaterialID, quantityOrdered FROM procurements WHERE procurementID = {procurementID}";
                DataTable dt = db.GetData(getSql);

                if (dt.Rows.Count > 0)
                {
                    string itemID = dt.Rows[0]["rawMaterialID"].ToString();
                    int qty = Convert.ToInt32(dt.Rows[0]["quantityOrdered"]);

                    // 2. Perform the update
                    // Note: Ensure your DatabaseController can handle multiple statements or execute sequentially
                    string invSql = $"UPDATE inventory SET quantityInStock = quantityInStock + {qty} WHERE itemID = '{itemID}'";
                    string statusSql = $"UPDATE procurements SET status = 'Delivered' WHERE procurementID = {procurementID}";

                    db.BatchUpdate(invSql);
                    db.BatchUpdate(statusSql);

                    return Ok(new { message = "Procurement marked as delivered and stock updated." });
                }
                return NotFound("Procurement record not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //cancel order
        [HttpPost("CancelOrderAndRestoreStock")]
        public IActionResult CancelOrderAndRestoreStock([FromQuery] int orderNumber, [FromQuery] string? customizeRequiredID)
        {
            try
            {
                string connString = _configuration["ConnectionStrings"];
                var db = new DatabaseAccessController.DatabaseController(connString);

                if (!string.IsNullOrEmpty(customizeRequiredID))
                {
                    // Scenario 1: It is a custom order
                    string getSql = $"SELECT desktopMaterialID, desktopQty, legMaterialID, legQty FROM CustomizeRequired WHERE requirementID = '{customizeRequiredID}'";
                    DataTable dt = db.GetData(getSql);

                    if (dt.Rows.Count > 0)
                    {
                        string dID = dt.Rows[0]["desktopMaterialID"].ToString();
                        int dQty = Convert.ToInt32(dt.Rows[0]["desktopQty"]);
                        string lID = dt.Rows[0]["legMaterialID"].ToString();
                        int lQty = Convert.ToInt32(dt.Rows[0]["legQty"]);

                        db.BatchUpdate($"UPDATE inventory SET quantityInStock = quantityInStock + {dQty} WHERE itemID = '{dID}'");
                        db.BatchUpdate($"UPDATE inventory SET quantityInStock = quantityInStock + {lQty} WHERE itemID = '{lID}'");
                    }
                }
                else
                {
                    // Scenario 2: Standard order
                    string getSql = $"SELECT itemID, quantity FROM order_details WHERE orderNumber = {orderNumber}";
                    DataTable dt = db.GetData(getSql);

                    foreach (DataRow row in dt.Rows)
                    {
                        string itemID = row["itemID"].ToString();
                        int qty = Convert.ToInt32(row["quantity"]);
                        db.BatchUpdate($"UPDATE inventory SET quantityInStock = quantityInStock + {qty} WHERE itemID = '{itemID}'");
                    }
                }

                // Final step: Update status
                db.BatchUpdate($"UPDATE orders SET orderStatus = 'Cancelled' WHERE orderNumber = {orderNumber}");

                return Ok(new { message = "Order cancelled and inventory restored." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // URL: POST https://localhost:7146/api/SimpleGetAPI/ConfirmPayment
        [HttpPost("ConfirmPayment")]
        public string ConfirmPayment([FromBody] Dictionary<string, string> payload)
        {
            if (payload == null || !payload.ContainsKey("customerNumber"))
            {
                return "FAILED_INVALID_PAYLOAD";
            }

            int customerNumber = int.Parse(payload["customerNumber"]);
            string connString = _configuration["ConnectionStrings"];

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. 嚴格對應您的 customer 資料表欄位進行查詢
                    string sqlCheckProfile = @"SELECT addressLine1, city, country, cardNumber, expiredDay, cvv 
                                               FROM customer 
                                               WHERE customerNumber = @custNum;";

                    using (MySqlCommand cmdCheck = new MySqlCommand(sqlCheckProfile, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@custNum", customerNumber);
                        using (MySqlDataReader reader = cmdCheck.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                return "FAILED_USER_NOT_FOUND";
                            }

                            // 2. 讀取並檢查地址相關欄位 (addressLine1, city, country 均不可為空)
                            string addressLine1 = reader["addressLine1"]?.ToString();
                            string city = reader["city"]?.ToString();
                            string country = reader["country"]?.ToString();

                            // 3. 讀取並檢查付款相關欄位 (cardNumber, expiredDay, cvv)
                            string cardNumber = reader["cardNumber"]?.ToString();
                            string expiredDay = reader["expiredDay"]?.ToString();
                            string cvv = reader["cvv"]?.ToString();

                            // 4. 核心商務邏輯判斷：任一欄位為空或空白，即代表資料不齊全
                            if (string.IsNullOrWhiteSpace(addressLine1) ||
                                string.IsNullOrWhiteSpace(city) ||
                                string.IsNullOrWhiteSpace(country) ||
                                string.IsNullOrWhiteSpace(cardNumber) ||
                                string.IsNullOrWhiteSpace(expiredDay) ||
                                string.IsNullOrWhiteSpace(cvv))
                            {
                                return "FAILED_MISSING_PROFILE_DETAILS";
                            }
                        }
                    }

                    // 5. 通過檢查，在此處可以執行您的實際扣款或更新訂單狀態邏輯
                    // (例如將該客戶的 Pending 訂單改為 Paid)

                    return "SUCCESS_PAYMENT_COMPLETED";
                }
                catch (Exception ex)
                {
                    return $"ERROR:{ex.Message}";
                }
            }
        }

        [HttpPost("AcceptAndCreateOrder")]
        public string AcceptAndCreateOrder([FromQuery] string customizeID)
        {
            if (string.IsNullOrEmpty(customizeID)) return "FAILED_INVALID_ID";

            string connString = _configuration["ConnectionStrings"];
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Retrieve Customize details
                        string sqlSelect = "SELECT customerID, price, newPrice FROM Customize WHERE customizeID = @id FOR UPDATE;";
                        int customerID = 0;
                        double finalPrice = 0.0;

                        using (MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn, trans))
                        {
                            cmdSelect.Parameters.AddWithValue("@id", customizeID);
                            using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                            {
                                if (!reader.Read()) return "FAILED_CUSTOMIZE_NOT_FOUND";
                                customerID = Convert.ToInt32(reader["customerID"]);
                                object newPriceObj = reader["newPrice"];
                                finalPrice = (newPriceObj == DBNull.Value || string.IsNullOrEmpty(newPriceObj.ToString()))
                                             ? Convert.ToDouble(reader["price"])
                                             : Convert.ToDouble(newPriceObj);
                            }
                        }

                        // 2. MODIFIED: Find the existing requirementID instead of inserting a new one
                        string sqlFindReq = "SELECT requirementID FROM CustomizeRequired WHERE customizeID = @id LIMIT 1;";
                        long requirementID = 0;
                        using (MySqlCommand cmdFind = new MySqlCommand(sqlFindReq, conn, trans))
                        {
                            cmdFind.Parameters.AddWithValue("@id", customizeID);
                            object result = cmdFind.ExecuteScalar();
                            if (result == null) return "FAILED_REQUIREMENT_NOT_FOUND";
                            requirementID = Convert.ToInt64(result);
                        }

                        // 3. Create the order using the existing requirementID
                        string sqlInsertOrder = @"INSERT INTO `orders` 
                  (`orderDate`, `customerNumber`, `totalAmount`, `orderStatus`, `customizeRequiredID`) 
                  VALUES (@orderDate, @custNum, @totalAmount, 'Processing', @reqID);
                  SELECT LAST_INSERT_ID();";

                        long newOrderNumber = 0;
                        using (MySqlCommand cmdOrder = new MySqlCommand(sqlInsertOrder, conn, trans))
                        {
                            cmdOrder.Parameters.AddWithValue("@orderDate", currentDate);
                            cmdOrder.Parameters.AddWithValue("@custNum", customerID);
                            cmdOrder.Parameters.AddWithValue("@totalAmount", finalPrice);
                            cmdOrder.Parameters.AddWithValue("@reqID", requirementID);
                            newOrderNumber = Convert.ToInt64(cmdOrder.ExecuteScalar());
                        }

                        // 4. Update Customize status
                        string sqlUpdateStatus = "UPDATE Customize SET status = 'accepted', ispay = 'Yes' WHERE customizeID = @id;";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdateStatus, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@id", customizeID);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return $"SUCCESS:{newOrderNumber}";
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return $"ERROR:{ex.Message}";
                    }
                }
            }
        }












    }
}


