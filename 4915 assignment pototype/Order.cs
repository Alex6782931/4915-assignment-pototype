using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private async void order_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetOrderRecordsDataFromApiResponse();
            dataOrders.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetOrderRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetOrderRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
                return CreateEmptyOrderTable();
            }
        }

        private async void btnOrderSearch_Click(object sender, EventArgs e)
        {
            string searchNum = txtOrderSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchNum))
            {
                MessageBox.Show("Please enter an order number to search.");
                return;
            }
            DataTable dt = await FindOrderRecordsDataFromApiResponse(searchNum);
            dataOrders.DataSource = dt;
        }

        private async Task<DataTable> FindOrderRecordsDataFromApiResponse(string orderNumber)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindOrderRecordsData?orderNumber={orderNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyOrderTable();
                }
            }
            catch (Exception) { return CreateEmptyOrderTable(); }
        }

        private async void btnOrderClear_Click(object sender, EventArgs e)
        {
            txtOrderSearch.Clear();
            DataTable dt = await GetOrderRecordsDataFromApiResponse();
            dataOrders.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnOrderUpdate_Click(object sender, EventArgs e)
        {
            dataOrders.EndEdit();
            if (dataOrders.DataSource != null) this.BindingContext[dataOrders.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataOrders.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateOrderRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} orders updated successfully.");
            }
        }


        private async Task<int> UpdateOrderRecordsToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    var listModified = new List<Dictionary<string, string>>();

                    foreach (DataRow row in dtUpdated.Rows)
                    {
                        var dict = new Dictionary<string, string>();
                        foreach (DataColumn col in dtUpdated.Columns) dict[col.ColumnName] = row[col]?.ToString() ?? "";
                        listModified.Add(dict);
                    }

                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = "[]",
                        dtModified = JsonSerializer.Serialize(listModified, jsonOptions),
                        dtDeleted = "[]"
                    };

                    string jsonString = JsonSerializer.Serialize(jsonDT);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateOrderRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyOrderTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name)) newRow[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        private DataTable CreateEmptyOrderTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("orderNumber", typeof(string));
            dataTable.Columns.Add("orderDate", typeof(string));
            dataTable.Columns.Add("customerNumber", typeof(string));
            dataTable.Columns.Add("totalAmount", typeof(string));
            dataTable.Columns.Add("orderStatus", typeof(string));
            return dataTable;
        }
    }
}