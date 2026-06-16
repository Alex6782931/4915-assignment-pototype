using _4915_assignment_pototype.staff;
using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
        }

        private async void Production_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetProductionRecordsDataFromApiResponse();
            dataProd.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetProductionRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetProductionRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading production: {ex.Message}");
                return CreateEmptyProductionTable();
            }
        }

        private async void btnProdSearch_Click(object sender, EventArgs e)
        {
            string searchItem = txtProdSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchItem))
            {
                MessageBox.Show("Please enter a Finished Item ID (e.g. FG001) to search.");
                return;
            }
            DataTable dt = await FindProductionRecordsDataFromApiResponse(searchItem);
            dataProd.DataSource = dt;
        }

        private async Task<DataTable> FindProductionRecordsDataFromApiResponse(string targetItemID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindProductionRecordsData?targetItemID={targetItemID}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyProductionTable();
                }
            }
            catch (Exception) { return CreateEmptyProductionTable(); }
        }

        private async void btnProdClear_Click(object sender, EventArgs e)
        {
            txtProdSearch.Clear();
            DataTable dt = await GetProductionRecordsDataFromApiResponse();
            dataProd.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnProdUpdate_Click(object sender, EventArgs e)
        {
            dataProd.EndEdit();
            if (dataProd.DataSource != null) this.BindingContext[dataProd.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataProd.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Your search mode fallback feature!

            int rowsUpdated = await UpdateProductionRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} production requests updated successfully.");
            }
        }

        private async Task<int> UpdateProductionRecordsToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    var listModified = new List<Dictionary<string, string>>();

                    foreach (DataRow row in dtUpdated.Rows)
                    {
                        var dict = new Dictionary<string, string>();
                        foreach (DataColumn col in dtUpdated.Columns) dict[col.ColumnName] = row[col]?.ToString() ?? "";
                        listModified.Add(dict);
                    }

                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = "[]",
                        dtModified = JsonSerializer.Serialize(listModified, jsonOptions),
                        dtDeleted = "[]"
                    };

                    string jsonString = JsonSerializer.Serialize(jsonDT);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateProductionRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyProductionTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name)) newRow[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        private DataTable CreateEmptyProductionTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("requestID", typeof(string));
            dataTable.Columns.Add("requestDate", typeof(string));
            dataTable.Columns.Add("targetItemID", typeof(string));
            dataTable.Columns.Add("rawMaterialID", typeof(string));
            dataTable.Columns.Add("quantityRequested", typeof(string));
            dataTable.Columns.Add("status", typeof(string));
            return dataTable;
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
