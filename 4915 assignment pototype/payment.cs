using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class payment : Form
    {
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        public payment(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        private async void payment_Load(object sender, EventArgs e)
        {
            await LoadCustomerPaymentFromApi();
        }

        private void btnPback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnPmodify_Click_1(object sender, EventArgs e)
        {
            string cardNumber = txtbPcardnum.Text.Trim();
            string expiredDay = txtbexpireddate.Text.Trim();
            string cvv = txtbcvv.Text.Trim();

            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiredDay) || string.IsNullOrEmpty(cvv))
            {
                MessageBox.Show("All payment fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paymentData = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "cardNumber", cardNumber },
                { "expiredDay", expiredDay },
                { "cvv", cvv }
            };

            bool success = await UpdateCustomerPaymentViaApi(paymentData);

            if (success)
            {
                MessageBox.Show("Payment information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCustomerPaymentFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{baseApiUrl}/GetCustomerPayment?customerNumber={currentCustomerNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement root = doc.RootElement;

                            txtbPcardnum.Text = root.TryGetProperty("cardNumber", out var c) && c.ValueKind != JsonValueKind.Null ? c.GetString() : "";
                            txtbexpireddate.Text = root.TryGetProperty("expiredDay", out var eDay) && eDay.ValueKind != JsonValueKind.Null ? eDay.GetString() : "";
                            txtbcvv.Text = root.TryGetProperty("cvv", out var cv) && cv.ValueKind != JsonValueKind.Null ? cv.GetString() : "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer payment details not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network initialization fault: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> UpdateCustomerPaymentViaApi(Dictionary<string, string> paymentPayload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(paymentPayload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/UpdateCustomerPayment";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result == "SUCCESS";
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network communication error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
}
