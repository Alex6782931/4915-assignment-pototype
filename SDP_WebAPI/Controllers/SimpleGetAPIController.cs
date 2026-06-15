using DatabaseAccessController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SDP_EntityModels;
using System;
using System.Data;
using System.Text.Json;
using SDP_EntityModels;

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

        [HttpGet("GetCustomerData")]
        public string GetCustomerData()
        {
            string connString = _configuration["ConnectionStrings"];

            // Calls your database project file
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllCustomerData();

            // Converts to a safe dictionary layout for System.Text.Json
            var list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    dict[col.ColumnName] = row[col].ToString();
                }
                list.Add(dict);
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

                // Instantiate your core helper class to run command updates
                DatabaseAccessController.DatabaseController dbController = new DatabaseAccessController.DatabaseController(connString);

                // 1. PROCESS MODIFIED ROWS
                if (!string.IsNullOrEmpty(json.dtModified) && json.dtModified != "[]")
                {
                    var modifiedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtModified, options);
                    if (modifiedRows != null)
                    {
                        foreach (var row in modifiedRows)
                        {
                            string sqlUpdate = $@"UPDATE customers SET 
                        customerName = '{row["customerName"]?.Replace("'", "''")}',
                        contactLastName = '{row["contactLastName"]?.Replace("'", "''")}',
                        contactFirstName = '{row["contactFirstName"]?.Replace("'", "''")}',
                        phone = '{row["phone"]?.Replace("'", "''")}',
                        addressLine1 = '{row["addressLine1"]?.Replace("'", "''")}',
                        city = '{row["city"]?.Replace("'", "''")}',
                        country = '{row["country"]?.Replace("'", "''")}'
                        WHERE customerNumber = {row["customerNumber"]};";

                            dbController.GetData(sqlUpdate);
                            totalProcessedRows++;
                        }
                    }
                }

                // 2. PROCESS ADDED ROWS
                if (!string.IsNullOrEmpty(json.dtAdded) && json.dtAdded != "[]")
                {
                    var addedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtAdded, options);
                    if (addedRows != null)
                    {
                        foreach (var row in addedRows)
                        {
                            string sqlInsert = $@"INSERT INTO customers 
                        (customerNumber, customerName, contactLastName, contactFirstName, phone, addressLine1, city, country) 
                        VALUES 
                        ({row["customerNumber"]}, 
                         '{row["customerName"]?.Replace("'", "''")}', 
                         '{row["contactLastName"]?.Replace("'", "''")}', 
                         '{row["contactFirstName"]?.Replace("'", "''")}', 
                         '{row["phone"]?.Replace("'", "''")}', 
                         '{row["addressLine1"]?.Replace("'", "''")}', 
                         '{row["city"]?.Replace("'", "''")}', 
                         '{row["country"]?.Replace("'", "''")}');";

                            dbController.GetData(sqlInsert);
                            totalProcessedRows++;
                        }
                    }
                }

                // 3. PROCESS DELETED ROWS
                if (!string.IsNullOrEmpty(json.dtDeleted) && json.dtDeleted != "[]")
                {
                    var deletedRows = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json.dtDeleted, options);
                    if (deletedRows != null)
                    {
                        foreach (var row in deletedRows)
                        {
                            string sqlDelete = $"DELETE FROM customers WHERE customerNumber = {row["customerNumber"]};";
                            dbController.GetData(sqlDelete);
                            totalProcessedRows++;
                        }
                    }
                }

                return totalProcessedRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("API Database Update Error: " + ex.Message);
                return 0;
            }
        }



        [HttpGet("FindCustomerData")]
        public string FindCustomerData([FromQuery] string customerName)
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);

            // 1. We assume you have a search method in GetCompanyData.cs. 
            // If your assignment requires a general table filter, call it here:
            DataTable dtResult = dboGetCompanyData.GetAllCustomerData();

            // 2. Filter the matching rows manually using Linq to ensure System.Text.Json compatibility
            var list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                string currentName = row["contactFirstName"]?.ToString() ?? ""; // Change "CustomerName" to your exact DB column name!

                // Match string case-insensitively
                if (currentName.IndexOf(customerName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var dict = new System.Collections.Generic.Dictionary<string, object>();
                    foreach (DataColumn col in dtResult.Columns)
                    {
                        dict[col.ColumnName] = row[col].ToString();
                    }
                    list.Add(dict);
                }
            }

            return System.Text.Json.JsonSerializer.Serialize(list);
        }


        [HttpGet("GetOrderData")]
        public string GetOrderData()
        {
            string connString = _configuration["ConnectionStrings"];
            GetCompanyData dboGetCompanyData = new GetCompanyData(connString);
            DataTable dtResult = dboGetCompanyData.GetAllOrderData();

            // Converts to a safe dictionary layout for System.Text.Json
            var list = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
            foreach (DataRow row in dtResult.Rows)
            {
                var dict = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn col in dtResult.Columns)
                {
                    dict[col.ColumnName] = row[col].ToString();
                }
                list.Add(dict);
            }

            return System.Text.Json.JsonSerializer.Serialize(list);
        }
    }
}

