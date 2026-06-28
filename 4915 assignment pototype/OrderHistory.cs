using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class OrderHistory : Form
    {
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        public OrderHistory(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        private async void OrderHistory_Load(object sender, EventArgs e)
        {
            await LoadOrderHistoryData();
        }

        private void btnOHback_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Close();
        }

        private async void btnOHsearch_Click(object sender, EventArgs e)
        {
            string keyword = txtbOHsearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                await LoadOrderHistoryData();
                return;
            }

            await SearchOrderHistoryData(keyword);
        }

        private async Task LoadOrderHistoryData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{baseApiUrl}/GetOrderHistory?customerNumber={currentCustomerNumber}";
                    string jsonString = await client.GetStringAsync(url);

                    if (jsonString.StartsWith("ERROR"))
                    {
                        MessageBox.Show($"Server Error: {jsonString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable dt = ParseJsonToDataTable(jsonString);
                    dataOH.DataSource = dt;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load order history: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SearchOrderHistoryData(string keyword)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{baseApiUrl}/SearchOrderHistory?customerNumber={currentCustomerNumber}&keyword={Uri.EscapeDataString(keyword)}";
                    string jsonString = await client.GetStringAsync(url);

                    if (jsonString.StartsWith("ERROR"))
                    {
                        MessageBox.Show($"Server Error: {jsonString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataTable dt = ParseJsonToDataTable(jsonString);
                    dataOH.DataSource = dt;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("orderDate", typeof(string));
            dataTable.Columns.Add("status", typeof(string));
            dataTable.Columns.Add("comments", typeof(string));

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name))
                            {
                                newRow[property.Name] = property.Value.ToString();
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }
    }
}
