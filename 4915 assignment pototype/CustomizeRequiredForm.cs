using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Data;

namespace _4915_assignment_pototype
{
    public partial class CustomizeRequiredForm : Form
    {
        private DataRow _selectedData;

        public CustomizeRequiredForm(DataRow row)
        {
            InitializeComponent();
            _selectedData = row;
        }
        private void btnback_Click(object sender, EventArgs e) {
            this.Hide();
        }
        private void CustomizeRequiredForm_Load(object sender, EventArgs e)
        {
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
                { "color", _selectedData["color"].ToString() },
                { "size", _selectedData["size"].ToString() },
                { "description", _selectedData["description"].ToString() }
                /* 
                // FUTURE IMAGE FEATURE:
                { "fileBase64", base64String } 
                */
            };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/ConfirmCustomizeOrder", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Order determined successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to process order.");
                }
            }
        }
    }
}