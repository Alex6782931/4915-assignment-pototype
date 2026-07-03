using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class CustomizeRequiredForm : Form
    {

        private DataRow _selectedData;

        public CustomizeRequiredForm(DataRow row)
        {
            InitializeComponent();
            _selectedData = row;

            // Now you can access all data, e.g., 
            // txtPrice.Text = _selectedData["price"].ToString();
        }
        private void CustomizeRequiredForm_Load(object sender, EventArgs e)
        {

        }

        private async void btndetermine_Click(object sender, EventArgs e)
        {
            var payload = new
            {
                customizeID = _selectedData["customizeID"].ToString(),
                dID = _selectedData["desktopMaterialID"].ToString(),
                dQty = txtdtqty.Text, // Map your input
                lID = _selectedData["legMaterialID"].ToString(),
                lQty = txtlqty.Text,     // Map your input
                color = _selectedData["color"].ToString(),
                size = _selectedData["size"].ToString(),
                desc = _selectedData["description"].ToString()
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
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
