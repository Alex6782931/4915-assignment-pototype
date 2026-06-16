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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private async void Inventory_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetInventoryRecordsDataFromApiResponse();
            dataInv.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }
        private async Task<DataTable> GetInventoryRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetInventoryRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stocks: {ex.Message}");
                return CreateEmptyInventoryTable();
            }
        }

        private async void btnInvSearch_Click(object sender, EventArgs e)
        {
            string searchItem = txtInvSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchItem))
            {
                MessageBox.Show("Please enter an item name keyword to search.");
                return;
            }
            DataTable dt = await FindInventoryRecordsDataFromApiResponse(searchItem);
            dataInv.DataSource = dt;
        }

        private async Task<DataTable> FindInventoryRecordsDataFromApiResponse(string itemName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindInventoryRecordsData?itemName={itemName}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyInventoryTable();
                }
            }
            catch (Exception) { return CreateEmptyInventoryTable(); }
        }

        private async void btnInvClear_Click(object sender, EventArgs e)
        {
            txtInvSearch.Clear();
            DataTable dt = await GetInventoryRecordsDataFromApiResponse();
            dataInv.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnInvUpdate_Click(object sender, EventArgs e)
        {
            dataInv.EndEdit();
            if (dataInv.DataSource != null) this.BindingContext[dataInv.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataInv.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateInventoryRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} stock counts updated successfully.");
            }
        }


        private async Task<int> UpdateInventoryRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateInventoryRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyInventoryTable();
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

        private DataTable CreateEmptyInventoryTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("itemID", typeof(string));
            dataTable.Columns.Add("itemName", typeof(string));
            dataTable.Columns.Add("itemType", typeof(string));
            dataTable.Columns.Add("quantityInStock", typeof(string));
            dataTable.Columns.Add("unit", typeof(string));
            dataTable.Columns.Add("location", typeof(string));
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
