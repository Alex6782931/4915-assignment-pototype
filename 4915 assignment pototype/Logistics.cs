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
    public partial class Logistics : Form
    {
        public Logistics()
        {
            InitializeComponent();
        }

        private async void Logistics_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetLogisticsRecordsDataFromApiResponse();
            dataLog.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetLogisticsRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetLogisticsRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading delivery tracking logs: {ex.Message}");
                return CreateEmptyLogisticsTable();
            }
        }

        private async void btnLogSearch_Click(object sender, EventArgs e)
        {
            string searchNote = txtLogSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchNote))
            {
                MessageBox.Show("Please enter a Delivery Note ID to filter shipments.");
                return;
            }
            DataTable dt = await FindLogisticsRecordsDataFromApiResponse(searchNote);
            dataLog.DataSource = dt;
        }

        private async Task<DataTable> FindLogisticsRecordsDataFromApiResponse(string deliveryNoteID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindLogisticsRecordsData?deliveryNoteID={deliveryNoteID}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyLogisticsTable();
                }
            }
            catch (Exception) { return CreateEmptyLogisticsTable(); }
        }

        private async void btnLogClear_Click(object sender, EventArgs e)
        {
            txtLogSearch.Clear();
            DataTable dt = await GetLogisticsRecordsDataFromApiResponse();
            dataLog.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnLogUpdate_Click(object sender, EventArgs e)
        {
            // 1. Force the user interface grid to commit what you just typed
            dataLog.EndEdit();
            if (dataLog.DataSource != null)
            {
                this.BindingContext[dataLog.DataSource].EndCurrentEdit();
            }

            DataTable mainTable = (DataTable)dataLog.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            // 2. Try to get standard tracking modifications
            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);

            // 3. Fallback: If you are searching, the table changes tracking might return null.
            // In that case, we treat the active searched row as modified to force the update.
            if (dtChanges == null)
            {
                dtChanges = mainTable.Copy();
            }

            // 4. Ship the values to your API server endpoint
            int rowsUpdated = await UpdateLogisticsRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} delivery note data synchronized successfully.");
            }
            else
            {
                MessageBox.Show("No adjustments could be saved to the database server.");
            }
        }


        private async Task<int> UpdateLogisticsRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateLogisticsRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyLogisticsTable();
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

        private DataTable CreateEmptyLogisticsTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("deliveryNoteID", typeof(string));
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("dispatchDate", typeof(string));
            dataTable.Columns.Add("deliveryAddress", typeof(string));
            dataTable.Columns.Add("driverName", typeof(string));
            dataTable.Columns.Add("replySlipReceived", typeof(string));
            dataTable.Columns.Add("conditionReport", typeof(string));
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

        private async void btndelivery_Click(object sender, EventArgs e)
        {
            if (dataLog.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order shipment record to process.");
                return;
            }

            string orderNum = dataLog.SelectedRows[0].Cells["orderNumber"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to mark order #{orderNum} as shipped?",
                                                   "Confirm Shipment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7146/api/SimpleGetAPI/ShipOrderAndCompleteCustomization?orderNumber={orderNum}";

                try
                {
                    var response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order shipped successfully!");
                        dataLog.DataSource = await GetLogisticsRecordsDataFromApiResponse();
                    }
                    else
                    {
                        string errorMsg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to ship order. Error: {errorMsg}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
