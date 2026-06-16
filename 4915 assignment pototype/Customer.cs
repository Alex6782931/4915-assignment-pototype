using _4915_assignment_pototype.staff;
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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        private async void Customer_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetCustomerDataFromApiResponse();
            dataCust.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> GetCustomerDataFromApiResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetCustomerData");
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


        private async void btnCustsearch_Click(object sender, EventArgs e)
        {

            string searchName = txtbCustsearch.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a customer name to search.");
                return;
            }

            // Call the specific search method
            DataTable dt = await FindCustomerDataFromApiResponse(searchName);

            // Bind results to your DataGrid view
            dataCust.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> FindCustomerDataFromApiResponse(string customerName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindCustomerData?customerName={customerName}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

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


        private async void btnCustupdate_Click(object sender, EventArgs e)
        {
            dataCust.EndEdit();
            if (dataCust.DataSource != null) this.BindingContext[dataCust.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataCust.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateCustomerDataToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} customer records updated successfully.");
            }
        }



        private async Task<int> UpdateCustomerDataToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

                    // 1. Serialize Added Rows Safely
                    DataTable dtAdded = dtUpdated.GetChanges(DataRowState.Added);
                    string jsonAdded = "[]";
                    if (dtAdded != null)
                    {
                        var listAdded = new List<Dictionary<string, string>>();
                        foreach (DataRow row in dtAdded.Rows)
                        {
                            var dict = new Dictionary<string, string>();
                            foreach (DataColumn col in dtAdded.Columns) dict[col.ColumnName] = row[col]?.ToString() ?? "";
                            listAdded.Add(dict);
                        }
                        jsonAdded = JsonSerializer.Serialize(listAdded, jsonOptions);
                    }

                    // 2. Serialize Modified Rows Safely
                    DataTable dtModified = dtUpdated.GetChanges(DataRowState.Modified);
                    string jsonModified = "[]";
                    if (dtModified != null)
                    {
                        var listModified = new List<Dictionary<string, string>>();
                        foreach (DataRow row in dtModified.Rows)
                        {
                            var dict = new Dictionary<string, string>();
                            foreach (DataColumn col in dtModified.Columns) dict[col.ColumnName] = row[col]?.ToString() ?? "";
                            listModified.Add(dict);
                        }
                        jsonModified = JsonSerializer.Serialize(listModified, jsonOptions);
                    }

                    // 3. Serialize Deleted Rows Safely
                    DataTable dtDeleted = dtUpdated.GetChanges(DataRowState.Deleted);
                    string jsonDeleted = "[]";
                    if (dtDeleted != null)
                    {
                        var listDeleted = new List<Dictionary<string, string>>();
                        foreach (DataRow row in dtDeleted.Rows)
                        {
                            var dict = new Dictionary<string, string>();
                            foreach (DataColumn col in dtDeleted.Columns) dict[col.ColumnName] = row[col, DataRowVersion.Original]?.ToString() ?? "";
                            listDeleted.Add(dict);
                        }
                        jsonDeleted = JsonSerializer.Serialize(listDeleted, jsonOptions);
                    }

                    // 4. Build the wrapper model and ship it over the network
                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = jsonAdded,
                        dtModified = jsonModified,
                        dtDeleted = jsonDeleted
                    };

                    string jsonString = JsonSerializer.Serialize(jsonDT);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Direct link to the API backend destination endpoint
                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateCustomerData", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        int rowsUpdated = int.Parse(responseString);
                        return rowsUpdated;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return 0;
            }
        }

        private async void btnCustReset_Click(object sender, EventArgs e)
        {
            txtbCustsearch.Clear();

            DataTable dt = await GetCustomerDataFromApiResponse();

            dataCust.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Find the hidden main menu that is already running and bring it back to the screen
            Form mainForm = Application.OpenForms["staffMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }

            // Close the current table form cleanly
            this.Close();
        }

    }
}
