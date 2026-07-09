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
    public partial class AddSupplierForm : Form
    {
        public AddSupplierForm()
        {
            InitializeComponent();
        }

        private async void btnSubmitSupplier_Click(object sender, EventArgs e)
        {
            var newSupplier = new
            {
                SupplierName = txtSupplierName.Text,
                ContactPerson = txtContact.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            using (HttpClient client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(newSupplier);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Post to the new API endpoint
                var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/AddSupplier", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Supplier added successfully!");
                    this.DialogResult = DialogResult.OK; // Signals success to the main form
                    this.Close();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to add supplier. Error: " + error);
                }
            }
        }
    }
}
