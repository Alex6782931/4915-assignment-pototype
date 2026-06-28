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
        // 指向你的 API 伺服器基礎 URL
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        // 1. 修改建構子，接收主畫面傳遞過來的 Customer ID 整數
        public OrderHistory(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        // 2. 表單載入時，自動讀取並顯示該客戶的所有訂單
        private async void OrderHistory_Load(object sender, EventArgs e)
        {
            await LoadOrderHistoryData();
        }

        // 3. 返回主選單按鈕事件
        private void btnOHback_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }
            this.Close();
        }

        // 4. 「Search」搜尋按鈕點擊事件（對應控制項：btnOHsearch）
        private async void btnOHsearch_Click(object sender, EventArgs e)
        {
            // 讀取輸入框文字（對應控制項：txtbOHsearch）
            string keyword = txtbOHsearch.Text.Trim();

            // 如果搜尋框是空的，就還原成載入全部歷史紀錄
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadOrderHistoryData();
                return;
            }

            await SearchOrderHistoryData(keyword);
        }

        // 核心方法：透過 API 載入完整訂單紀錄
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
                    dataOH.DataSource = dt; // ✅ 成功綁定到你的 DataGridView 控制項：dataOH
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load order history: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 核心方法：透過 API 模糊搜尋指定訂單
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
                    dataOH.DataSource = dt; // ✅ 成功綁定到你的 DataGridView 控制項：dataOH
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 解析 JSON 字串並自動產生 DataTable 架構
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
