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
    public partial class customizeOrder : Form
    {
        public customizeOrder()
        {
            InitializeComponent();
        }

        private async void customizeOrder_Load(object sender, EventArgs e)
        {

        }

        private async Task<DataTable> GetCustomizeOrderFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Ensure the URL matches your API endpoint
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/Customize/GetCustomizeRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customization orders: {ex.Message}");
                return new DataTable();
            }
        }
        private void btncustomizedeter_Click(object sender, EventArgs e)
        {
            if (datacustomize.SelectedRows.Count > 0)
            {
                // 1. Get the DataRow bound to the selected row
                DataGridViewRow selectedRow = datacustomize.SelectedRows[0];
                DataRowView rowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow fullRow = rowView.Row;

                // 2. Pass the entire row to the constructor
                CustomizeRequiredForm reqForm = new CustomizeRequiredForm(fullRow);
                reqForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order from the list.");
            }
        }

        private async void customizeOrder_Load_1(object sender, EventArgs e)
        {
            // Load initial data when the form opens
            DataTable dt = await GetCustomizeOrderFromApi();
            datacustomize.DataSource = dt;
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = new DataTable();
            // Define columns matching your Customize table
            dataTable.Columns.Add("customizeID");
            dataTable.Columns.Add("customerID");
            dataTable.Columns.Add("type");
            dataTable.Columns.Add("color");
            dataTable.Columns.Add("size");
            dataTable.Columns.Add("desktopMaterialID");
            dataTable.Columns.Add("desktopMaterialName");
            dataTable.Columns.Add("legMaterialID");
            dataTable.Columns.Add("legMaterialName");
            dataTable.Columns.Add("description");
            dataTable.Columns.Add("price");
            dataTable.Columns.Add("status");

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                {
                    DataRow newRow = dataTable.NewRow();
                    foreach (JsonProperty property in rowElement.EnumerateObject())
                    {
                        if (dataTable.Columns.Contains(property.Name))
                            newRow[property.Name] = property.Value.ToString();
                    }
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnreject_Click(object sender, EventArgs e)
        {
            if (datacustomize.SelectedRows.Count > 0)
            {
                string customizeID = datacustomize.SelectedRows[0].Cells["customizeID"].Value.ToString();

                var payload = new Dictionary<string, string> { { "customizeID", customizeID } };
                string jsonPayload = JsonSerializer.Serialize(payload);

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/RejectCustomizeOrder", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Order rejected successfully.");
                        // Refresh the grid
                        DataTable dt = await GetCustomizeOrderFromApi();
                        datacustomize.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Failed to reject the order.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to reject.");
            }
        }
    }
}
