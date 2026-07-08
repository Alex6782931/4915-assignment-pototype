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
    public partial class Procurement : Form
    {
        public Procurement()
        {
            InitializeComponent();
        }

        private async void Procurement_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetProcurementRecordsDataFromApiResponse();
            dataProc.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetProcurementRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetProcurementRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading procurements: {ex.Message}");
                return CreateEmptyProcurementTable();
            }
        }

        private async void btnProcSearch_Click(object sender, EventArgs e)
        {
            string searchMaterial = txtProcSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchMaterial))
            {
                MessageBox.Show("Please enter a Raw Material ID (e.g., RM001) to search.");
                return;
            }
            DataTable dt = await FindProcurementRecordsDataFromApiResponse(searchMaterial);
            dataProc.DataSource = dt;
        }

        private async Task<DataTable> FindProcurementRecordsDataFromApiResponse(string rawMaterialID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindProcurementRecordsData?rawMaterialID={rawMaterialID}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyProcurementTable();
                }
            }
            catch (Exception) { return CreateEmptyProcurementTable(); }
        }

        private async void btnProcClear_Click(object sender, EventArgs e)
        {
            txtProcSearch.Clear();
            DataTable dt = await GetProcurementRecordsDataFromApiResponse();
            dataProc.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnProcUpdate_Click(object sender, EventArgs e)
        {
            dataProc.EndEdit();
            if (dataProc.DataSource != null) this.BindingContext[dataProc.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataProc.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateProcurementRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} procurement rows updated successfully.");
            }
        }


        private async Task<int> UpdateProcurementRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateProcurementRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyProcurementTable();
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

        private DataTable CreateEmptyProcurementTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("procurementID", typeof(string));
            dataTable.Columns.Add("orderDate", typeof(string));
            dataTable.Columns.Add("supplierID", typeof(string));
            dataTable.Columns.Add("rawMaterialID", typeof(string));
            dataTable.Columns.Add("quantityOrdered", typeof(string));
            dataTable.Columns.Add("expectedDelivery", typeof(string));
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

        private async void btnprdone_Click(object sender, EventArgs e)
        {
            if (dataProc.SelectedRows.Count > 0)
            {
                string procID = dataProc.SelectedRows[0].Cells["procurementID"].Value.ToString();

                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/UpdateProcurementToDelivered?procurementID={procID}";

                    try
                    {
                        var response = await client.PostAsync(url, null);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Procurement marked as Delivered and Inventory updated!");

                            // Refresh the grid to show the updated status
                            DataTable dt = await GetProcurementRecordsDataFromApiResponse();
                            dataProc.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update status. Please check the connection.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a procurement record first.");
            }
        }



    }
}
