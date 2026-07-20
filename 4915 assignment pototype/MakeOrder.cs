using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class MakeOrder : Form
    {
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        public MakeOrder(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            if (mainForm != null) mainForm.Show();
            this.Close();
        }

        private async void btnorder_Click_1(object sender, EventArgs e)
        {
            string selectedItemID = GetSelectedItemID();
            if (string.IsNullOrEmpty(selectedItemID))
            {
                MessageBox.Show("Please select a product first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtcount.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid product count (positive integer).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItemName = GetItemNameByID(selectedItemID);
            double unitPrice = await GetItemPriceFromApi(selectedItemID);
            double totalAmount = unitPrice * quantity;

            string confirmMessage = $"Order Summary:\n" +
                                   $"-------------------------\n" +
                                   $"Item Name: {selectedItemName}\n" +
                                   $"Quantity: {quantity}\n" +
                                   $"Unit Price: ${unitPrice:N2}\n" +
                                   $"Total Amount: ${totalAmount:N2}\n\n" +
                                   $"Are you sure you want to proceed with the payment?";

            DialogResult dialogResult = MessageBox.Show(
                confirmMessage,
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );


            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            btnorder.Enabled = false;
            bool isProfileValid = await CheckPaymentAndAddressProfile();
            if (!isProfileValid)
            {
                btnorder.Enabled = true;
                return;
            }
                var orderPayload = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "itemID", selectedItemID },
                { "quantity", quantity.ToString() }
            };

                string result = await SubmitOrderToApi(orderPayload);
                btnorder.Enabled = true;

                if (result.StartsWith("SUCCESS"))
                {
                    string orderNum = result.Split(':')[1];
                    MessageBox.Show($"Payment completed successfully!\nOrder #{orderNum} placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcount.Clear();
                }
                else if (result.StartsWith("FAILED_INSUFFICIENT_STOCK"))
                {
                    string availableStock = result.Split('=')[1];
                    MessageBox.Show($"Order failed. Insufficient stock! Current available stock is {availableStock}.", "Stock Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Order compilation failed: {result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        private string GetItemNameByID(string itemID)
        {
            switch (itemID)
            {
                case "FG001": return "Ergonomic Office Chair";
                case "FG002": return "Mahogany Dining Table";
                case "FG003": return "3-Seater Velvet Sofa";
                case "FG004": return "Minimalist Study Desk";
                case "FG005": return "Modular Bookcase Rack";
                default: return "Unknown Furniture Item";
            }
        }

         
        private async Task<double> GetItemPriceFromApi(string itemID)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    string url = $"{baseApiUrl}/GetItemPrice?itemID={itemID}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string priceStr = await response.Content.ReadAsStringAsync();
                        if (double.TryParse(priceStr, out double price))
                        {
                            return price;
                        }
                    }
                    return 0.0;
                }
            }
            catch
            {
                return 0.0; 
            }
        }

        private async Task<bool> CheckPaymentAndAddressProfile()
        {
            var paymentPayload = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() }
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(paymentPayload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

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
                                "Payment Gateway Alert:\n\nYour profile is incomplete! Please ensure your Address (Line1, City, Country) and Payment Details (Card Number, Expiry Day, CVV) are configured.\n\nReturning to Main Menu to update your info...",
                                "Account Information Missing",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            Form mainForm = Application.OpenForms["CustomerMain"];
                            if (mainForm != null) mainForm.Show();

                            this.Close();
                            return false;
                        }
                        else
                        {
                            MessageBox.Show($"Payment processing error: {result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Network Error: Server replied with HTTP {response.StatusCode}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to the payment gateway: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string GetSelectedItemID()
        {
            if (rbtn6.Checked) return "FG001";
            if (rbtn7.Checked) return "FG002";
            if (rbtn8.Checked) return "FG003";
            if (rbtn9.Checked) return "FG004";
            if (rbtn10.Checked) return "FG005";
            return null;
        }

        private async Task<string> SubmitOrderToApi(Dictionary<string, string> payload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(payload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/SubmitOrder";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    return $"ERROR: HTTP {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"ERROR:{ex.Message}";
            }
        }
        private void btncustomize_Click(object sender, EventArgs e)
        {
            Customize customizeForm = new Customize(currentCustomerNumber.ToString());
            customizeForm.ShowDialog();
        }
    }
}
