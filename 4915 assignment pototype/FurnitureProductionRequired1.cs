using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class FurnitureProductionRequired1 : Form
    {
        private string _itemID;

        public FurnitureProductionRequired1(string itemID)
        {
            InitializeComponent();
            _itemID = itemID;
            LoadMaterials();
        }

        private async void LoadMaterials()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetInventoryRecordsData");
                    DataTable dt = ParseJsonToDataTable(json);


                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "itemID LIKE 'RM%'";

                    cmbMaterials.DataSource = dv;
                    cmbMaterials.DisplayMember = "itemName";
                    cmbMaterials.ValueMember = "itemID";

                    // Force refresh the UI
                    cmbMaterials.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbMaterials.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid raw material.");
                return;
            }

            String target = _itemID; // The Furniture ID passed to this form
            string rawMaterialID = cmbMaterials.SelectedValue.ToString(); // The RM ID from ComboBox
            string qty = numQty.Value.ToString();

            using (HttpClient client = new HttpClient())
            {
                // Ensure this matches the controller parameters: targetItemID, rawMaterialID, quantityRequested
                string url = $"https://localhost:7146/api/SimpleGetAPI/CreateProductionRequest?targetItemID={target}&rawMaterialID={rawMaterialID}&quantityRequested={qty}";

                var response = await client.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Production Request Created successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create request. Please check your inputs.");
                }
            }
        }

        // Make sure this matches the helper method in your other forms
        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            // Assuming JSON is a list of objects like [{"itemID":"RM001", "itemName":"Wood"}]
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.Array)
                {
                    // Create columns based on first item
                    if (root.GetArrayLength() > 0)
                    {
                        foreach (JsonProperty prop in root[0].EnumerateObject())
                            dt.Columns.Add(prop.Name);
                    }
                    // Add rows
                    foreach (JsonElement element in root.EnumerateArray())
                    {
                        DataRow dr = dt.NewRow();
                        foreach (JsonProperty prop in element.EnumerateObject())
                            dr[prop.Name] = prop.Value.ToString();
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }
    }
}