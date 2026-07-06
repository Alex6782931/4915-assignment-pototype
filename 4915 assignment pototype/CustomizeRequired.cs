using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class CustomizeRequired : Form
    {
        private readonly string apiBaseUrl = "https://localhost:7146/api/SimpleGetAPI/";

        public CustomizeRequired()
        {
            InitializeComponent();
        }

        private async void CustomizeRequired_Load_1(object sender, EventArgs e)
        {
            DataTable dt = await GetCustomizeRequiredDataFromApiResponse();
            datacr.DataSource = dt;
            datacr.ReadOnly = true;
        }

        private async Task<DataTable> GetCustomizeRequiredDataFromApiResponse()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = apiBaseUrl + "GetCustomizeRequiredData";
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return ParseJsonToDataTable(responseBody);
                }
                catch (Exception)
                {
                    return CreateEmptyTable();
                }
            }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyTable();
            if (string.IsNullOrEmpty(jsonString) || jsonString == "[]") return dataTable;

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                {
                    DataRow newRow = dataTable.NewRow();
                    foreach (JsonProperty property in rowElement.EnumerateObject())
                    {
                        // Ensure the column exists in the DataTable before setting
                        if (dataTable.Columns.Contains(property.Name))
                        {
                            newRow[property.Name] = property.Value.ToString();
                        }
                    }    
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }

        private DataTable CreateEmptyTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("requirementID", typeof(int));
            dataTable.Columns.Add("customizeID", typeof(int));
            dataTable.Columns.Add("desktopMaterialID", typeof(string));
            dataTable.Columns.Add("desktopQty", typeof(int));
            dataTable.Columns.Add("legMaterialID", typeof(string));
            dataTable.Columns.Add("legQty", typeof(int));
            dataTable.Columns.Add("type", typeof(string));
            dataTable.Columns.Add("color", typeof(string));
            dataTable.Columns.Add("size", typeof(string));
            dataTable.Columns.Add("description", typeof(string));
            return dataTable;
        }

        private void btncrback_Click_1(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["staffMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Close();
        }

        private async void btncrsearch_Click(object sender, EventArgs e)
        {
            string searchDesc = txtbcustomizeSsearch.Text.Trim();
            if (string.IsNullOrEmpty(searchDesc)) return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiBaseUrl + "FindCustomizeRequiredData?searchTerm=" + Uri.EscapeDataString(searchDesc));
                    string content = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        DataTable dt = ParseJsonToDataTable(content);
                        datacr.DataSource = dt;
                    }
                    else
                    {
                        // Displays the actual error message from the backend
                        MessageBox.Show("Search Error: " + content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical Error: " + ex.Message);
            }
        }

        private async void btncrclear_Click(object sender, EventArgs e)
        {
            txtbcustomizeSsearch.Clear();
            DataTable dt = await GetCustomizeRequiredDataFromApiResponse();
            datacr.DataSource = dt;
        }
    }
}