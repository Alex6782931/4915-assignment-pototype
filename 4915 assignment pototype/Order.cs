using _4915_assignment_pototype.staff;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _4915_assignment_pototype
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private async void order_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetOrderRecordsDataFromApiResponse();
            dataOrders.DataSource = dt;
            if (dt != null) dt.AcceptChanges();

            CheckForPendingOrders();
        }

        private async Task<DataTable> GetOrderRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetOrderRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
                return CreateEmptyOrderTable();
            }
        }

        private async void btnOrderSearch_Click(object sender, EventArgs e)
        {
            string searchNum = txtOrderSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchNum))
            {
                MessageBox.Show("Please enter an order number to search.");
                return;
            }
            DataTable dt = await FindOrderRecordsDataFromApiResponse(searchNum);
            dataOrders.DataSource = dt;
        }

        private async Task<DataTable> FindOrderRecordsDataFromApiResponse(string orderNumber)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindOrderRecordsData?orderNumber={orderNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyOrderTable();
                }
            }
            catch (Exception) { return CreateEmptyOrderTable(); }
        }

        private async void btnOrderClear_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Clear();
            DataTable dt = await GetOrderRecordsDataFromApiResponse();
            dataOrders.DataSource = dt;
            if (dt != null) dt.AcceptChanges();


        }

        private async void btnOrderUpdate_Click(object sender, EventArgs e)
        {
            dataOrders.EndEdit();
            if (dataOrders.DataSource != null) this.BindingContext[dataOrders.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataOrders.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateOrderRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} orders updated successfully.");

                CheckForPendingOrders();
            }
        }


        private async Task<int> UpdateOrderRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateOrderRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyOrderTable();
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

        private DataTable CreateEmptyOrderTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("orderDate", typeof(string));
            dataTable.Columns.Add("customerNumber", typeof(string));
            dataTable.Columns.Add("totalAmount", typeof(string));
            dataTable.Columns.Add("orderStatus", typeof(string));
            dataTable.Columns.Add("CustomizeRequiredID", typeof(string));
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
        private void CheckForPendingOrders()
        {
            DataTable mainTable = dataOrders.DataSource as DataTable;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            // Count how many orders have a "Pending" status
            int pendingCount = mainTable.AsEnumerable()
                .Count(row => string.Equals(row.Field<string>("orderStatus"), "Pending", StringComparison.OrdinalIgnoreCase));

            if (pendingCount > 0)
            {
                MessageBox.Show($"There are {pendingCount} pending order(s) requiring attention.",
                                "Pending Orders Reminder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private async void btnCancelOrder_Click(object sender, EventArgs e)
        {
            // 1. Validate Selection
            if (dataOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.");
                return;
            }

            DataGridViewRow selectedRow = dataOrders.SelectedRows[0];
            string orderNum = selectedRow.Cells["orderNumber"].Value?.ToString();
            string status = selectedRow.Cells["orderStatus"].Value?.ToString();

            // 2. Enforce the "Processing" condition
            if (!string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only orders with 'Pending' status can be cancelled.",
                                "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Extract customizeRequiredID safely
            // Check if column exists, if not, use string.Empty
            string customID = "";
            if (dataOrders.Columns.Contains("customizeRequiredID") && selectedRow.Cells["customizeRequiredID"].Value != null)
            {
                customID = selectedRow.Cells["customizeRequiredID"].Value.ToString();
            }

            // 4. Confirmation
            DialogResult result = MessageBox.Show($"Are you sure you want to cancel order #{orderNum}?",
                                                  "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (HttpClient client = new HttpClient())
                {
                    // The API handles null/empty string as a "Standard Order" automatically
                    string url = $"https://localhost:7146/api/SimpleGetAPI/CancelOrderAndRestoreStock?orderNumber={orderNum}&customizeRequiredID={customID}";

                    try
                    {
                        var response = await client.PostAsync(url, null);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Order has been cancelled and inventory restored.");
                            dataOrders.DataSource = await GetOrderRecordsDataFromApiResponse();
                        }
                        else
                        {
                            string error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Failed to cancel order: {error}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Connection error: {ex.Message}");
                    }
                }
            }
        }

        private async void btndelivery_Click(object sender, EventArgs e)
        {
            if (dataOrders.SelectedRows.Count == 0) return;

            // Retrieve values from the selected row
            string orderNum = dataOrders.SelectedRows[0].Cells["orderNumber"].Value.ToString();
            // Assuming the column name in your DataGridView is 'customizeRequiredID'
            string reqID = dataOrders.SelectedRows[0].Cells["customizeRequiredID"].Value?.ToString();

            if (string.IsNullOrEmpty(reqID))
            {
                MessageBox.Show("This order does not have a linked customization requirement.");
                return;
            }

            if (MessageBox.Show($"Confirm shipment for order #{orderNum}?", "Ship", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (HttpClient client = new HttpClient())
            {
                // Pass both parameters in the query string
                string url = $"https://localhost:7146/api/SimpleGetAPI/ShipOrderAndCompleteCustomization?orderNumber={orderNum}&customizeRequiredID={reqID}";

                var response = await client.PostAsync(url, null);
                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Order shipped and customization marked as done!");
                    dataOrders.DataSource = await GetOrderRecordsDataFromApiResponse();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }




    }
}