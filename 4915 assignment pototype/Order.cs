using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private async void Order_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetOrderDataFromApiResponse();
            dataOrder.DataSource = dt;
        }

        private async Task<DataTable> GetOrderDataFromApiResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetOrderData");
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    DataTable dataTable = new DataTable();
                    bool columnsCreated = false;
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        if (!columnsCreated)
                        {
                            foreach (JsonProperty property in rowElement.EnumerateObject())
                            {
                                dataTable.Columns.Add(property.Name, typeof(string));
                            }
                            columnsCreated = true;
                        }
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            newRow[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(newRow);
                    }
                    return dataTable;
                }
            }
        }

        private async void btnOsearch_Click(object sender, EventArgs e)
        {
            string searchName = dataOrder.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a customer name to search.");
                return;
            }

            // Call the specific search method
            DataTable dt = await FindOrderDataFromApiResponse(searchName);

            // Bind results to your DataGrid view
            dataOrder.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> FindOrderDataFromApiResponse(string customerName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);

                    // Your assignment instruction: Pass customerName as a query string parameter
                    HttpResponseMessage response = await client.GetAsync($"/api/SimpleGetAPI/FindCustomerData?customerName={customerName}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        // Uses the Newtonsoft library you downloaded in Part C
                        DataTable dataTable = System.Text.Json.JsonSerializer.Deserialize<DataTable>(jsonString);

                        return dataTable;
                    }
                    else
                    {
                        MessageBox.Show($"Server returned error: {response.StatusCode}");
                        return new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}");
                return new DataTable();
            }
        }

        private async void btnOupdate_click(object sender, EventArgs e)
        {
            DataTable dtUpdated = (DataTable)dataOrder.DataSource;
            dtUpdated = dtUpdated.GetChanges();

            if (dtUpdated != null)
            {
                int rowsUpdated = await UpdateOrderDataToAPI(dtUpdated);
                if (rowsUpdated > 0)
                {
                    dtUpdated.AcceptChanges();
                    dataOrder.DataSource = dtUpdated.Copy();
                }
                MessageBox.Show($"{rowsUpdated} rows updated successfully.");
            }
        }

        private async Task<int> UpdateOrderDataToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);

                    // Configure built-in options to format json beautifully (replaces Formatting.Indented)
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

                    // 1. Serialize Added (New) Rows
                    DataTable dtAdded = dtUpdated.GetChanges(DataRowState.Added);
                    string jsonAdded = dtAdded != null ? JsonSerializer.Serialize(dtAdded, jsonOptions) : "[]";

                    // 2. Serialize Modified Rows
                    DataTable dtModified = dtUpdated.GetChanges(DataRowState.Modified);
                    string jsonModified = dtModified != null ? JsonSerializer.Serialize(dtModified, jsonOptions) : "[]";

                    // 3. Handle Deleted Rows Safely
                    // Note: Directly serializing a deleted DataTable throws errors because rows are missing.
                    // We create a clean temporary table to store the original values before they were deleted.
                    string jsonDeleted = "[]";
                    DataTable dtDeleted = dtUpdated.GetChanges(DataRowState.Deleted);

                    if (dtDeleted != null)
                    {
                        DataTable dtDeletedBackup = dtDeleted.Clone(); // Copy schema structure
                        foreach (DataRow row in dtDeleted.Rows)
                        {
                            DataRow newRow = dtDeletedBackup.NewRow();
                            // Loop through columns to extract original values safely
                            foreach (DataColumn col in dtDeleted.Columns)
                            {
                                newRow[col.ColumnName] = row[col.ColumnName, DataRowVersion.Original];
                            }
                            dtDeletedBackup.Rows.Add(newRow);
                        }
                        jsonDeleted = JsonSerializer.Serialize(dtDeletedBackup, jsonOptions);
                    }

                    // 4. Populate your custom Entity Model
                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = jsonAdded,
                        dtModified = jsonModified,
                        dtDeleted = jsonDeleted
                    };

                    // Serialize the entire entity wrapper object to a JSON string
                    string jsonString = JsonSerializer.Serialize(jsonDT);

                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Send POST request to the Web API
                    HttpResponseMessage response = await client.PostAsync("/api/SimpleGetAPI/UpdateOrderData", content);

                    // Ensure the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        int rowsUpdated = int.Parse(responseString);
                        return rowsUpdated;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return 0;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
