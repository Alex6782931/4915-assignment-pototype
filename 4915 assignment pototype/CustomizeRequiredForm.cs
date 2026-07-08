using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class CustomizeRequiredForm : Form
    {
        private DataRow _selectedData;
        private bool _isExistingRecord = false;

        public CustomizeRequiredForm(DataRow row)
        {
            InitializeComponent();
            _selectedData = row;
        }

        private async void CustomizeRequiredForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7146/api/SimpleGetAPI/CheckCustomizeRequired?customizeID={_selectedData["customizeID"]}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    _isExistingRecord = (result == "true");
                }
            }
        }

        private async void btndetermine_Click(object sender, EventArgs e)
        {
            var payload = new Dictionary<string, string>
    {
        { "customizeID", _selectedData["customizeID"].ToString() },
        { "desktopMaterialID", _selectedData["desktopMaterialID"].ToString() },
        { "desktopQty", txtdtqty.Text },
        { "legMaterialID", _selectedData["legMaterialID"].ToString() },
        { "legQty", txtlqty.Text },
        { "price", txtprice.Text },
        { "isExisting", _isExistingRecord.ToString().ToLower() },
        { "type", _selectedData["type"].ToString() },
        { "color", _selectedData["color"].ToString() },
        { "size", _selectedData["size"].ToString() },
        { "des", _selectedData["description"].ToString() },
        { "ispay", _selectedData["ispay"].ToString() },
    };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Sending the request to your backend
                var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/ConfirmCustomizeOrder", content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the string response (SUCCESS or the error message)
                    string result = await response.Content.ReadAsStringAsync();

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Order processed successfully.");
                        this.Close();
                    }
                    else
                    {
                        // Displays the specific inventory error message from the backend
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to connect to the server.");
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e) { this.Hide(); }
    }
}