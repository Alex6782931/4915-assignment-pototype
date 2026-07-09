using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class customizehistort : Form
    {
        private DataTable _originalTable;
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private string customid;

        public customizehistort(string customid) {
            InitializeComponent();
            this.customid = customid;
        }
        private void dataCustomizeC_SelectionChanged(object sender, EventArgs e)
        {
            if (dataCustomizeC.SelectedRows.Count > 0)
            {
                // Safely get the status
                string currentStatus = dataCustomizeC.SelectedRows[0].Cells["status"].Value?.ToString() ?? "";
                UpdateButtonStates(currentStatus);
            }
            else
            {
                // Disable buttons if nothing is selected
                btnedit.Enabled = false;
                btnaccept.Enabled = false;
            }
        }

        private void UpdateButtonStates(string currentStatus)
        {
            try
            {
                // 1. Define states
                bool isDetermined = currentStatus.Equals("determined", StringComparison.OrdinalIgnoreCase);
                bool isRejected = currentStatus.Equals("rejected", StringComparison.OrdinalIgnoreCase);
                bool isProcessing = currentStatus.Equals("processing", StringComparison.OrdinalIgnoreCase);
                bool isEdited = currentStatus.Equals("edited", StringComparison.OrdinalIgnoreCase);

                // 2. LOGIC:
                // btnaccept is ONLY enabled when status is "determined"
                btnaccept.Enabled = isDetermined;

                // btnedit is enabled for rejected, processing, edited, and determined status
                btnedit.Enabled = (isRejected || isProcessing || isEdited || isDetermined);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating buttons: " + ex.Message);
            }
        }


        private async Task LoadData()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync($"{baseApiUrl}/GetCustomizeHistory");
                _originalTable = ParseJsonToDataTable(json);
                // Ensure your DataGridView is named appropriately
                dataCustomizeC.DataSource = _originalTable;
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();
            if (_originalTable != null) _originalTable.DefaultView.RowFilter = string.Empty;
            LoadData();
        }


        private DataTable ParseJsonToDataTable(string json)
        {
            DataTable dt = new DataTable();
            // Columns derived directly from your CREATE TABLE Customize definition
            dt.Columns.Add("customizeID");
            dt.Columns.Add("customerID");
            dt.Columns.Add("type");
            dt.Columns.Add("color");
            dt.Columns.Add("size");
            dt.Columns.Add("desktopMaterialID");
            dt.Columns.Add("desktopMaterialName");
            dt.Columns.Add("legMaterialID");
            dt.Columns.Add("legMaterialName");
            dt.Columns.Add("description");
            dt.Columns.Add("price");
            dt.Columns.Add("newPrice");
            dt.Columns.Add("status");

            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                foreach (JsonElement el in doc.RootElement.EnumerateArray())
                {
                    DataRow row = dt.NewRow();
                    foreach (JsonProperty prop in el.EnumerateObject())
                    {
                        if (dt.Columns.Contains(prop.Name)) row[prop.Name] = prop.Value.ToString();
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        private async void btnaccept_Click(object sender, EventArgs e)
        {
            var row = dataCustomizeC.SelectedRows[0];
            string custID = row.Cells["customizeID"].Value.ToString();
            double price = Convert.ToDouble(row.Cells["price"].Value);
            object newPriceObj = row.Cells["newPrice"].Value;

            if (newPriceObj == DBNull.Value || string.IsNullOrEmpty(newPriceObj.ToString()))
            {
                MessageBox.Show("Order accepted.");
                await CallUpdateApi(custID, "accepted");
            }
            else
            {
                double newPrice = Convert.ToDouble(newPriceObj);
                if (newPrice > price)
                {
                    // Show Payment Form for (newPrice - price)
                    double diff = newPrice - price;
                    // PaymentForm payForm = new PaymentForm(diff, custID);
                    // payForm.ShowDialog();
                }
                else if (newPrice < price)
                {
                    MessageBox.Show($"Refund processed: {price - newPrice}");
                    await CallUpdateApi(custID, "accepted");
                }
            }
        }


        private async Task CallRejectApi(Dictionary<string, string> payload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Serialize the payload to JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(payload);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Post to the new API endpoint
                    string url = $"{baseApiUrl}/RejectCustomizeOrder";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order rejected and stock restored successfully.");
                        await LoadData(); // Refresh grid
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to reject order: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}");
            }
        }

        private async void btnedit_Click(object sender, EventArgs e)
        {
            var row = dataCustomizeC.SelectedRows[0];
            string customize = row.Cells["customizeID"].Value.ToString();
            Customize c = new Customize(customid, customize);
            c.ShowDialog();
            LoadData();
        }

        private async Task CallUpdateApi(string id, string status)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Ensure this URL matches your API controller route
                    string url = $"{baseApiUrl}/UpdateCustomizeStatus?customizeID={id}&newStatus={status}";

                    HttpResponseMessage response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Status updated to {status} successfully.");
                        await LoadData(); // Refresh the grid to show new status
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update status: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API Error: {ex.Message}");
            }
        }



        private async void customizehistort_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnCSearch_Click_1(object sender, EventArgs e)
        {
            if (_originalTable == null) return;
            string filter = txtsearch.Text.Trim();

            // Filters based on the 'status' enum and 'description' text column from your table
            _originalTable.DefaultView.RowFilter = $"status LIKE '%{filter}%' OR description LIKE '%{filter}%'";
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
