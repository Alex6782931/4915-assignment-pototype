using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Address : Form
    {
        // Points to your application API server port base URL
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        // Constructor accepting the targeted user reference key ID
        public Address(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        // Trigger safe fetch during form initialization lifecycle
        private async void Address_Load(object sender, EventArgs e)
        {
            await LoadCustomerAddressFromApi();
        }

        private void btnAback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnAmodify_Click(object sender, EventArgs e)
        {
            // 1. Collect inputs cleanly
            string floor = txtbAfloor.Text.Trim();
            string building = txtbAbuilding.Text.Trim();
            string street = txtbAstreet.Text.Trim();
            string city = txtbAcity.Text.Trim();
            string country = txtbcountry.Text.Trim();

            // 2. Validate essential fields
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                MessageBox.Show("City and Country are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Serialize inputs into a payload dictionary matching your payload style
            var addressData = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "floor", floor },
                { "building", building },
                { "street", street },
                { "city", city },
                { "country", country }
            };

            // 4. Send network modification command asynchronously 
            bool success = await UpdateCustomerAddressViaApi(addressData);

            if (success)
            {
                MessageBox.Show("Address updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper API Method: GET existing customer address details
        private async Task LoadCustomerAddressFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{baseApiUrl}/GetCustomerAddress?customerNumber={currentCustomerNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement root = doc.RootElement;

                            // Map individual properties safely into the screen text field boxes
                            txtbAfloor.Text = root.TryGetProperty("floor", out var f) && f.ValueKind != JsonValueKind.Null ? f.GetString() : "";
                            txtbAbuilding.Text = root.TryGetProperty("building", out var b) && b.ValueKind != JsonValueKind.Null ? b.GetString() : "";
                            txtbAstreet.Text = root.TryGetProperty("street", out var s) && s.ValueKind != JsonValueKind.Null ? s.GetString() : "";
                            txtbAcity.Text = root.TryGetProperty("city", out var c) ? c.GetString() : "";
                            txtbcountry.Text = root.TryGetProperty("country", out var co) ? co.GetString() : "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer profile address records not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network initialization fault: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper API Method: POST updated address back to server architecture
        private async Task<bool> UpdateCustomerAddressViaApi(Dictionary<string, string> addressPayload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(addressPayload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/UpdateCustomerAddress";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    return response.IsSuccessStatusCode;
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
