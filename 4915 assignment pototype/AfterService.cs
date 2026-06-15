using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _4915_assignment_pototype
{
    public partial class AfterService : Form
    {
        public AfterService()
        {
            InitializeComponent();
        }

        private void dataAS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void AfterService_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetCustomerDataFromApiResponse();
            dataAS.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> GetCustomerDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]); // Adjust the base address as needed
                    HttpResponseMessage response = await client.GetAsync("https://localhost:7146/api/SimpleGetAPI/GetCustomerData");


                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        // Replace the JsonConvert line with this line:
                        DataTable dataTable = System.Text.Json.JsonSerializer.Deserialize<DataTable>(jsonString);


                        return dataTable;
                    }
                    else
                    {
                        // Log the status code and reason
                        string error = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                        throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                MessageBox.Show($"Request error: {e.Message}");
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw ex;
            }
        }

        private async void btnASsearch_Click(object sender, EventArgs e)
        {
            string searchName = txtbASsearch.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a customer name to search.");
                return;
            }

            // Call the specific search method
            DataTable dt = await FindCustomerDataFromApiResponse(searchName);

            // Bind results to your DataGrid view
            dataAS.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> FindCustomerDataFromApiResponse(string customerName)
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

        private async void btnASupdate_click(object sender, EventArgs e)
        {
            DataTable dtUpdated = (DataTable)dataAS.DataSource;
            dtUpdated = dtUpdated.GetChanges();

            if (dtUpdated != null)
            {
                int rowsUpdated = await UpdateCustomerDataToAPI(dtUpdated);
                if (rowsUpdated > 0)
                {
                    dtUpdated.AcceptChanges();
                    dataAS.DataSource = dtUpdated.Copy();
                }
                MessageBox.Show($"{rowsUpdated} rows updated successfully.");
            }
        }

        private async Task<int> UpdateCustomerDataToAPI(DataTable dtUpdated)
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
                    HttpResponseMessage response = await client.PostAsync("/api/SimpleGetAPI/UpdateCustomerData", content);

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
