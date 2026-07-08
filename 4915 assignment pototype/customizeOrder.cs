using _4915_assignment_pototype.staff;
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
            DataTable dt = await GetCustomizeOrderFromApi();
            dt.DefaultView.RowFilter = "status IN ('processing', 'determined', 'edited')";
            datacustomize.DataSource = dt.DefaultView;
        }

        private async Task<DataTable> GetCustomizeOrderFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Ensure the URL matches your API endpoint
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetCustomizeRecordsData");
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
                DataGridViewRow selectedRow = datacustomize.SelectedRows[0];

                if (selectedRow.Cells["customizeID"].Value == null ||
                    string.IsNullOrWhiteSpace(selectedRow.Cells["customizeID"].Value.ToString()))
                {
                    MessageBox.Show("You selected an empty record.");
                    return;
                }

                DataRowView rowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow fullRow = rowView.Row;

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
            dataTable.Columns.Add("newPrice");
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

            Form mainForm = Application.OpenForms["staffMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }

            // Close the current table form cleanly
            this.Close();
        }

        private async void btnreject_Click(object sender, EventArgs e)
        {
            if (datacustomize.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datacustomize.SelectedRows[0];

                // Validate that the selected record is not empty
                if (selectedRow.Cells["customizeID"].Value == null ||
                    string.IsNullOrWhiteSpace(selectedRow.Cells["customizeID"].Value.ToString()))
                {
                    MessageBox.Show("You selected an empty record.");
                    return; // Stop execution
                }

                // Add confirmation warning
                DialogResult result = MessageBox.Show("Are you sure you want to reject this customize order?",
                                                      "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string customizeID = selectedRow.Cells["customizeID"].Value.ToString();
                    var payload = new Dictionary<string, string> { { "customizeID", customizeID } };
                    string jsonPayload = JsonSerializer.Serialize(payload);

                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");
                        var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/RejectCustomizeOrder", content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Order rejected successfully.");
                            DataTable dt = await GetCustomizeOrderFromApi();
                            datacustomize.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Failed to reject the order.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to reject.");
            }
        }

        private void btncustomizesearch_Click(object sender, EventArgs e)
        {
            string searchId = txtbcustomizeSsearch.Text.Trim(); // Assuming you have a TextBox named txtSearch

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter a Customer ID to search.");
                return;
            }

            // Filter the existing DataTable bound to the grid
            if (datacustomize.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"customerID LIKE '%{searchId}%'";
                datacustomize.DataSource = dv;
            }
        }

        private async void btncustomixeclear_Click(object sender, EventArgs e)
        {
            txtbcustomizeSsearch.Clear(); // Clear the search textbox

            // Reload original data from API to remove any applied filters
            DataTable dt = await GetCustomizeOrderFromApi();
            datacustomize.DataSource = dt;
        }
    }
}
