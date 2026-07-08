using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _4915_assignment_pototype
{
    public partial class Customize : Form
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7146/") };
        private string currentCustomerID;
        private string _customizeID;
       


        public Customize(string cusid)
        {
            InitializeComponent();
            _ = LoadInventoryData(); // Fire and forget
            currentCustomerID = cusid;
        }
        public Customize(string cusid, string customizeID)
        {
            InitializeComponent();
            _ = LoadInventoryData(); // Fire and forget
            currentCustomerID = cusid;
            _customizeID = customizeID;

        }

        private async Task LoadInventoryData()
        {
            try
            {
                string json = await client.GetStringAsync("api/SimpleGetAPI/GetInventoryRecordsData");
                DataTable dt = ParseJsonToDataTable(json);

                // Create a DataView to filter the data
                DataView dv = dt.DefaultView;

                // Filter: Only show items where itemID starts with 'RM'
                dv.RowFilter = "itemID LIKE 'RM%'";

                // Bind the filtered view to the ComboBoxes
                ConfigureComboBox(cmbDesktopMaterial, dv.ToTable());
                ConfigureComboBox(cmbLegMaterial, dv.ToTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading materials: " + ex.Message);
            }
        }

        public void btnBack_Click(object sender, EventArgs e) { 
        this.Close();
        }

        private void ConfigureComboBox(ComboBox cmb, DataTable dt)
        {
            // Bind the filtered table directly
            cmb.DataSource = dt;
            cmb.DisplayMember = "itemName";
            cmb.ValueMember = "itemID";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Get selected IDs and Names from ComboBox
            string dID = cmbDesktopMaterial.SelectedValue.ToString();
            string dName = cmbDesktopMaterial.Text;
            string lID = cmbLegMaterial.SelectedValue.ToString();
            string lName = cmbLegMaterial.Text;

            var data = new
            {
                customizeID = _customizeID, 
                customerID = currentCustomerID,
                type = txtType.Text,
                color = txtColor.Text,
                size = txtSize.Text,
                desktopMaterialID = dID,
                desktopMaterialName = dName,
                legMaterialID = lID,
                legMaterialName = lName,
                description = txtDescription.Text,
                
            };

            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/SimpleGetAPI/SaveCustomization", content);
            if (response.IsSuccessStatusCode) { 
            MessageBox.Show("Customization saved!");
            this.Close(); }
            else{
                MessageBox.Show("Failed to save.");}
        }

        private DataTable ParseJsonToDataTable(string json)
        {
            DataTable dt = new DataTable();
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                foreach (JsonElement el in doc.RootElement.EnumerateArray())
                {
                    DataRow row = dt.NewRow();
                    foreach (JsonProperty prop in el.EnumerateObject())
                    {
                        if (!dt.Columns.Contains(prop.Name)) dt.Columns.Add(prop.Name);
                        row[prop.Name] = prop.Value.ToString();
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
    }
}