using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http; 
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Cancel : Form
    {
        private string _currentCustomerNumber;

        public Cancel(string customerNumber)
        {
            InitializeComponent();
            _currentCustomerNumber = customerNumber; 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            if (mainForm != null) mainForm.Show(); 
            this.Close();
        }

        private async void Cancel_Load(object sender, EventArgs e)
        {
            await RefreshOrderGrid();  
        }

       
        private async Task RefreshOrderGrid()
        {
            DataTable dt = await GetOrderRecordsDataFromApiResponse();

            if (dt != null)
            {
                dt.AcceptChanges();

                DataView dv = new DataView(dt);
                dv.RowFilter = $"customerNumber = '{_currentCustomerNumber}'";

                dataOrder.DataSource = dv; 
            }
            else
            {
                dataOrder.DataSource = CreateEmptyOrderTable();
            }

            if (dataOrder.Columns.Contains("customerNumber"))
            {
                dataOrder.Columns["customerNumber"].Visible = false;
            }
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

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            try
            {
                var jsonDocument = JsonDocument.Parse(jsonString);
                var rootElement = jsonDocument.RootElement;
                if (rootElement.ValueKind == JsonValueKind.Array)
                {
                    DataTable dataTable = new DataTable();
                    if (rootElement.GetArrayLength() > 0)
                    {
                        foreach (var property in rootElement[0].EnumerateObject())
                        {
                            dataTable.Columns.Add(property.Name);
                        }
                    }
                    foreach (var item in rootElement.EnumerateArray())
                    {
                        DataRow row = dataTable.NewRow();
                        foreach (var property in item.EnumerateObject())
                        {
                            row[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(row);
                    }
                    return dataTable;
                }
                else
                {
                    MessageBox.Show("Unexpected JSON format.");
                    return CreateEmptyOrderTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}");
                return CreateEmptyOrderTable();
            }
        }

        private DataTable CreateEmptyOrderTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("customerNumber", typeof(string));
            dataTable.Columns.Add("orderDate", typeof(string));
            dataTable.Columns.Add("orderStatus", typeof(string));
            return dataTable;
        }

        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (dataOrder.CurrentRow == null)
            {
                MessageBox.Show("Please select an order from the list first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderNumber = dataOrder.CurrentRow.Cells["orderNumber"].Value?.ToString();
            string currentStatus = dataOrder.CurrentRow.Cells["orderStatus"].Value?.ToString();

            if (string.IsNullOrEmpty(orderNumber))
            {
                MessageBox.Show("Failed to retrieve the selected order number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(orderNumber, out int parsedOrderNumber))
            {
                MessageBox.Show("The selected order number format is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This order has already been cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentStatus == "Shipped")
            {
                MessageBox.Show("This order has already been shipped and cannot be cancelled.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to cancel order number: {orderNumber}?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                var payload = new { orderNumber = parsedOrderNumber };
                string jsonString = JsonSerializer.Serialize(payload);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7146/api/SimpleGetAPI/CancelOrder", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Order cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await RefreshOrderGrid();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to cancel order. Server response: {response.StatusCode}\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Network error. Failed to connect to the server: {httpEx.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the cancellation process: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
