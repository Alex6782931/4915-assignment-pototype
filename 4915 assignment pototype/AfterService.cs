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
    public partial class AfterService : Form
    {
        public AfterService()
        {
            InitializeComponent();
        }

        private async void AfterService_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetAfterServiceRecordsDataFromApiResponse();
            dataAS.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetAfterServiceRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetAfterServiceRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading: {ex.Message}");
                return CreateEmptyAfterServiceTable();
            }
        }

        private async void btnASsearch_Click(object sender, EventArgs e)
        {
            string searchNum = txtbASsearch.Text.Trim();

            if (string.IsNullOrEmpty(searchNum))
            {
                MessageBox.Show("Please enter an order number to search.");
                return;
            }

            DataTable dt = await FindAfterServiceRecordsDataFromApiResponse(searchNum);
            dataAS.DataSource = dt;
            dt.AcceptChanges();
        }

        private async Task<DataTable> FindAfterServiceRecordsDataFromApiResponse(string orderNumber)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindAfterServiceRecordsData?orderNumber={orderNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }

                    MessageBox.Show($"Server returned error: {response.StatusCode}");
                    return CreateEmptyAfterServiceTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}");
                return CreateEmptyAfterServiceTable();
            }
        }

        private async void btnASupdate_click(object sender, EventArgs e)
        {
            dataAS.EndEdit();
            if (dataAS.DataSource != null) this.BindingContext[dataAS.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataAS.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateAfterServiceRecordsDataToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} service logs updated successfully.");
            }
        }


        private async Task<int> UpdateAfterServiceRecordsDataToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

                    DataTable dtAdded = dtUpdated.GetChanges(DataRowState.Added);
                    string jsonAdded = ConvertTableToJson(dtAdded, jsonOptions, false);

                    DataTable dtModified = dtUpdated.GetChanges(DataRowState.Modified);
                    string jsonModified = ConvertTableToJson(dtModified, jsonOptions, false);

                    DataTable dtDeleted = dtUpdated.GetChanges(DataRowState.Deleted);
                    string jsonDeleted = ConvertTableToJson(dtDeleted, jsonOptions, true);

                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = jsonAdded,
                        dtModified = jsonModified,
                        dtDeleted = jsonDeleted
                    };

                    string jsonString = JsonSerializer.Serialize(jsonDT);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateAfterServiceRecordsData", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return int.Parse(await response.Content.ReadAsStringAsync());
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update processing error: {ex.Message}");
                return 0;
            }
        }

        // HELPER METHOD 1: Safely Parse JSON Arrays to DataTables without Crashing
        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyAfterServiceTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name))
                            {
                                newRow[property.Name] = property.Value.ToString();
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        // HELPER METHOD 2: Formats default table grid design structure dynamically
        private DataTable CreateEmptyAfterServiceTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("caseID", typeof(string));
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("requestDate", typeof(string));
            dataTable.Columns.Add("requestType", typeof(string));
            dataTable.Columns.Add("reason", typeof(string));
            dataTable.Columns.Add("resolutionStatus", typeof(string));
            return dataTable;
        }

        // HELPER METHOD 3: Safe generic data cell parsing logic
        private string ConvertTableToJson(DataTable dt, JsonSerializerOptions options, bool isDeleted)
        {
            if (dt == null || dt.Rows.Count == 0) return "[]";
            var list = new List<Dictionary<string, string>>();
            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, string>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = (isDeleted ? row[col.ColumnName, DataRowVersion.Original] : row[col.ColumnName])?.ToString() ?? "";
                }
                list.Add(dict);
            }
            return JsonSerializer.Serialize(list, options);
        }

        private async void btnASclear_Click(object sender, EventArgs e)
        {
            txtbASsearch.Clear();

            DataTable dt = await GetAfterServiceRecordsDataFromApiResponse();

            dataAS.DataSource = dt;
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
