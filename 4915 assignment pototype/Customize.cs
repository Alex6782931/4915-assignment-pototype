using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Customize : Form
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7146/") };
        private int currentCustomerID = 103;

        public Customize()
        {
            InitializeComponent();
            PopulateCustomizationOptions();
        }

        private void PopulateCustomizationOptions()
        {
            txtColor.MaxLength = 30;

            // Desktop Material options
            cmbDesktopMaterial.Items.AddRange(new string[] { "Solid Wood", "MDF Veneer", "Tempered Glass", "Marble", "Laminate" });
            cmbDesktopMaterial.SelectedIndex = 0;

            // Leg Material options
            cmbLegMaterial.Items.AddRange(new string[] { "Stainless Steel", "Powder Coated Iron", "Solid Oak Legs", "Aluminum" });
            cmbLegMaterial.SelectedIndex = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtSize.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please fill out Furniture Type, Size, and Color fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var payload = new Dictionary<string, string>
            {
                { "customerID", currentCustomerID.ToString() },
                { "type", txtType.Text },
                { "color", txtColor.Text },
                { "size", txtSize.Text },
                { "desktopMaterialName", cmbDesktopMaterial.SelectedItem.ToString() },
                { "legMaterialName", cmbLegMaterial.SelectedItem.ToString() },
                { "description", txtDescription.Text }
            };

            try
            {
                string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);
                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/SimpleGetAPI/SubmitCustomizeOrder", content);

                if (response.IsSuccessStatusCode)
                {
                    string resultText = await response.Content.ReadAsStringAsync();

                    if (resultText.StartsWith("SUCCESS"))
                    {
                        string newOrderId = resultText.Split(':')[1];
                        MessageBox.Show($"Customization saved successfully!\nYour Customization ID is: {newOrderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form MakeOrderForm = Application.OpenForms["MakeOrder"];
                        if (MakeOrderForm != null) MakeOrderForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"API Processing Failed: {resultText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"HTTP Request Failed: {response.StatusCode}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to communicate with Server API: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form MakeOrderForm = Application.OpenForms["MakeOrder"];
            if (MakeOrderForm != null) MakeOrderForm.Show();
            this.Close();
        }
    }
}
