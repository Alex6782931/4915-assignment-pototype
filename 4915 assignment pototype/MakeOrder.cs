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

            var orderPayload = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "itemID", selectedItemID },
                { "quantity", quantity.ToString() }
            };

            btnorder.Enabled = false;
            string result = await SubmitOrderToApi(orderPayload);
            btnorder.Enabled = true;

            if (result.StartsWith("SUCCESS"))
            {
                string orderNum = result.Split(':')[1];
                MessageBox.Show($"Order #{orderNum} placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Customize customizeForm = new Customize();
            customizeForm.ShowDialog(); 
        }
    }
}
