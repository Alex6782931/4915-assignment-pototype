using System;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Customize : Form
    {
        public Customize()
        {
            InitializeComponent();
            PopulateCustomizationOptions();
        }

        // Fills the Dropdowns with options
        private void PopulateCustomizationOptions()
        {
            // Color options
            cmbColor.Items.AddRange(new string[] { "Natural Oak", "Walnut", "Matte Black", "Glossy White", "Charcoal Gray" });
            cmbColor.SelectedIndex = 0;

            // Desktop Material options
            cmbDesktopMaterial.Items.AddRange(new string[] { "Solid Wood", "MDF Veneer", "Tempered Glass", "Marble", "Laminate" });
            cmbDesktopMaterial.SelectedIndex = 0;

            // Leg Material options
            cmbLegMaterial.Items.AddRange(new string[] { "Stainless Steel", "Powder Coated Iron", "Solid Oak Legs", "Aluminum" });
            cmbLegMaterial.SelectedIndex = 0;
        }

        // Logic when user clicks Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Simple validation check
            if (string.IsNullOrWhiteSpace(txtType.Text) || string.IsNullOrWhiteSpace(txtSize.Text))
            {
                MessageBox.Show("Please fill out both the Furniture Type and Size fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capture data into local variables
            string furnitureType = txtType.Text;
            string size = txtSize.Text;
            string selectedColor = cmbColor.SelectedItem.ToString();
            string desktopMaterial = cmbDesktopMaterial.SelectedItem.ToString();
            string legMaterial = cmbLegMaterial.SelectedItem.ToString();
            string description = txtDescription.Text;

            // Output confirmation window
            string message = $"Furniture Saved Successfully!\n\n" +
                             $"Type: {furnitureType}\n" +
                             $"Size: {size}\n" +
                             $"Color: {selectedColor}\n" +
                             $"Desktop Material: {desktopMaterial}\n" +
                             $"Leg Material: {legMaterial}\n" +
                             $"Description: {description}";

            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Pass these variables to your Database handler or Cart system here
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form MakeOrderForm = Application.OpenForms["MakeOrder"];
            if (MakeOrderForm != null) MakeOrderForm.Show();
            this.Close();
        }
    }
}
