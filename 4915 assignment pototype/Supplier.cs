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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private async void Supplier_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetSupplierRecordsDataFromApiResponse();
            dataSuppliers.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetSupplierRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetSupplierRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}");
                return CreateEmptySupplierTable();
            }
        }

        private async void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSupplierSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a supplier name keyword to search.");
                return;
            }
            DataTable dt = await FindSupplierRecordsDataFromApiResponse(searchName);
            dataSuppliers.DataSource = dt;
        }

        private async Task<DataTable> FindSupplierRecordsDataFromApiResponse(string supplierName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindSupplierRecordsData?supplierName={supplierName}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptySupplierTable();
                }
            }
            catch (Exception) { return CreateEmptySupplierTable(); }
        }

        private async void btnSupplierClear_Click(object sender, EventArgs e)
        {
            txtSupplierSearch.Clear();
            DataTable dt = await GetSupplierRecordsDataFromApiResponse();
            dataSuppliers.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnSupplierUpdate_Click(object sender, EventArgs e)
        {
            dataSuppliers.EndEdit();
            if (dataSuppliers.DataSource != null) this.BindingContext[dataSuppliers.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataSuppliers.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Integrated Search Fallback

            int rowsUpdated = await UpdateSupplierRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} vendor accounts updated successfully.");
            }
        }

        private async Task<int> UpdateSupplierRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateSupplierRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptySupplierTable();
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

        private DataTable CreateEmptySupplierTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("supplierID", typeof(string));
            dataTable.Columns.Add("supplierName", typeof(string));
            dataTable.Columns.Add("contactName", typeof(string));
            dataTable.Columns.Add("phone", typeof(string));
            dataTable.Columns.Add("address", typeof(string));
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

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplierForm addForm = new AddSupplierForm();
            addForm.ShowDialog();
            // Refresh your supplier DataGridView here
            Supplier_Load(null, null);
        }
    }
}
