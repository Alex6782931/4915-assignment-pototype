using System;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class RawMaterialProcurements : Form
    {
        private string _itemID;

        public RawMaterialProcurements(string itemID)
        {
            InitializeComponent();
            _itemID = itemID;
            LoadSuppliers();
        }

        private async void LoadSuppliers()
        {
            using (HttpClient client = new HttpClient())
            {
                // Ensure this endpoint exists in your SimpleGetAPIController
                string json = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetSupplierRecordsData");

                DataTable dt = ParseJsonToDataTable(json);
                cmbSuppliers.DataSource = dt;
                cmbSuppliers.DisplayMember = "supplierName"; // Show name
                cmbSuppliers.ValueMember = "supplierID";     // Store ID
            }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                var root = doc.RootElement;
                if (root.GetArrayLength() > 0)
                {
                    foreach (JsonProperty prop in root[0].EnumerateObject())
                        dt.Columns.Add(prop.Name);

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

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            int supplierID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            int qty = (int)numQty.Value;

            // Calculate expected delivery: Today + 30 days
            DateTime expectedDelivery = DateTime.Now.AddDays(30);

            using (HttpClient client = new HttpClient())
            {
                // Use the passed _itemID (rawMaterialID)
                string url = $"https://localhost:7146/api/SimpleGetAPI/CreateProcurement?" +
                             $"supplierID={supplierID}&rawMaterialID={_itemID}&quantityOrdered={qty}" +
                             $"&expectedDelivery={expectedDelivery:yyyy-MM-dd}";

                var response = await client.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Procurement created! Expected delivery: {expectedDelivery:yyyy-MM-dd}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create procurement.");
                }
            }
        }
    }
}