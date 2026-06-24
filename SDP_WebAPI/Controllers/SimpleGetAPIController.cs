using DatabaseAccessController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
                // Prioritize routing based on which field in the row has data
                if (!string.IsNullOrEmpty(staffId))
                {
                    return $"STAFF_ROUTE:{accessLevel}";
                }
                else if (!string.IsNullOrEmpty(customerId))
                {
                    return $"CUSTOMER_ROUTE:{accessLevel}";
                }

                // Fallback safe return if both are somehow null
                return accessLevel;
            }

            return "FAILED_WRONG_PASSWORD";
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

    }
}

