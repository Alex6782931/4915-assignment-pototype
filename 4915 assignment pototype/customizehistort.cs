using System;
using System.Data;
using System.Net.Http;
using System.Text;
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
            dt.Columns.Add("ispay");

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
            if (dataCustomizeC.SelectedRows.Count == 0) return;

            var row = dataCustomizeC.SelectedRows[0];
            string custID = row.Cells["customizeID"].Value.ToString();
            string furnitureType = row.Cells["type"].Value?.ToString();
            double price = Convert.ToDouble(row.Cells["price"].Value);
            object newPriceObj = row.Cells["newPrice"].Value;

            string currentIsPay = row.Cells["ispay"].Value?.ToString();
            if (currentIsPay != null && currentIsPay.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This customization request has already been paid and accepted!", "Payment Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string currentStatus = row.Cells["status"].Value?.ToString();
            if (currentStatus != null && currentStatus.Equals("accepted", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "This customization request has already been accepted and processed into a production order. You cannot accept it again.",
                    "Order Already Accepted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;  
            }

            double finalPrice = price;
            double diff = 0.0;
            bool isPriceIncreased = false;

            if (newPriceObj != DBNull.Value && !string.IsNullOrEmpty(newPriceObj.ToString()))
            {
                double newPrice = Convert.ToDouble(newPriceObj);
                finalPrice = newPrice;
                if (newPrice > price)
                {
                    diff = newPrice - price;
                    isPriceIncreased = true;
                }
            }

            string confirmMessage = $"Customization Order Summary:\n" +
                                   $"-------------------------\n" +
                                   $"Furniture Type: {furnitureType}\n" +
                                   $"Original Base Price: ${price:N2}\n" +
                                   $"Final Determined Price: ${finalPrice:N2}\n";

            if (isPriceIncreased)
            {
                confirmMessage += $"Additional Payment Required: ${diff:N2}\n";
            }
            else if (finalPrice < price)
            {
                confirmMessage += $"Refund Amount to be Processed: ${price - finalPrice:N2}\n";
            }

            confirmMessage += $"\nAre you sure you want to accept this configuration and complete the payment process?";

            DialogResult dialogResult = MessageBox.Show(
                confirmMessage,
                "Ensure Accept Customization",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }


            btnaccept.Enabled = false;

            bool isProfileValid = await CheckPaymentAndAddressProfileForCustomize();
            if (!isProfileValid)
            {
                btnaccept.Enabled = true;
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (isPriceIncreased)
                    {
                        MessageBox.Show($"Additional payment of ${diff:N2} processed successfully via your card.", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (finalPrice < price)
                    {
                        MessageBox.Show($"Refund of ${price - finalPrice:N2} has been processed back to your card account.", "Refund Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    string url = $"{baseApiUrl}/AcceptAndCreateOrder?customizeID={custID}";
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultText = await response.Content.ReadAsStringAsync();

                        if (resultText.StartsWith("SUCCESS"))
                        {
                            string formalOrderNum = "N/A";
                            if (resultText.Contains(":"))
                            {
                                formalOrderNum = resultText.Split(':')[1];
                            }

                            row.Cells["ispay"].Value = "Yes";

                            MessageBox.Show($"Success!\n\nStatus updated to 'accepted' and Payment marked as 'Yes'.\nFormal Production Order #{formalOrderNum} has been automatically generated into the system.", "Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            await LoadData();
                        }
                        else
                        {
                            MessageBox.Show($"API Transaction Failed: {resultText}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Network Error: Server replied HTTP {response.StatusCode}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Exception occurred: {ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnaccept.Enabled = true;
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
            if (dataCustomizeC.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a customization record from the list before attempting to edit.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // FIX 1 & 2: Access the row index [0] correctly
            var selectedRow = dataCustomizeC.SelectedRows[0];
            string currentStatus = selectedRow.Cells["status"].Value?.ToString();

            if (currentStatus != null && currentStatus.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "If the status is done, it is not required to edit the customize order.",
                    "Action Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // FIX 3: Use the variable you just defined
            string customizeID = selectedRow.Cells["customizeID"].Value.ToString();

            // Ensure the Customize constructor matches these arguments
            Customize c = new Customize(customizeID, customizeID);
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
        private async Task<bool> CheckPaymentAndAddressProfileForCustomize()
        {
            var paymentPayload = new Dictionary<string, string>
    {
        { "customerNumber", this.customid }
    };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(paymentPayload);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/ConfirmPayment";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        if (result.StartsWith("SUCCESS_PAYMENT_COMPLETED"))
                        {
                            return true; 
                        }
                        else if (result == "FAILED_MISSING_PROFILE_DETAILS")
                        {
                            MessageBox.Show(
                                "Payment Gateway Intercept:\n\nYour profile details are incomplete! You cannot accept this customization until an address and active credit card details are configured.\n\nReturning to Main Menu now...",
                                "Account Profile Incomplete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                             
                            Form mainForm = Application.OpenForms["CustomerMain"];
                            if (mainForm != null) mainForm.Show();

                            this.Close();  
                            return false;
                        }
                    }
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Gateway communication loss. Cannot verify profile data integrity.", "Network Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
