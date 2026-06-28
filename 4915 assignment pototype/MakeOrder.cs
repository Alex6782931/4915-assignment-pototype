using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class MakeOrder : Form
    {
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        // 修改建構子：確保接收 Customer ID
        public MakeOrder(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // 返回主選單
        }

        // 「Order」按鈕的點擊事件
        private async void btnorder_Click_1(object sender, EventArgs e)
        {
            // 1. 取得使用者選擇的商品 ID
            string selectedItemID = GetSelectedItemID();
            if (string.IsNullOrEmpty(selectedItemID))
            {
                MessageBox.Show("Please select a product first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 讀取並驗證使用者輸入的下單數量 (txtCount)
            if (!int.TryParse(txtcount.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid product count (positive integer).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. 準備提交給 API 的 Payload 資料組
            var orderPayload = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "itemID", selectedItemID },
                { "quantity", quantity.ToString() }
            };

            // 4. 發送請求給後端執行下單事務
            btnorder.Enabled = false; // 防止重複點擊
            string result = await SubmitOrderToApi(orderPayload);
            btnorder.Enabled = true;

            // 5. 處理後端回傳結果
            if (result.StartsWith("SUCCESS"))
            {
                string orderNum = result.Split(':')[1];
                MessageBox.Show($"Order #{orderNum} placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcount.Clear();
            }
            else if (result.StartsWith("FAILED_INSUFFICIENT_STOCK"))
            {
                string availableStock = result.Split('=')[1];
                MessageBox.Show($"Order failed. Insufficient stock! Current available stock is {availableStock}.", "Stock Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Order compilation failed: {result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 輔助方法：尋找畫面被勾選的 RadioButton，並回傳對應的商品 ID
        private string GetSelectedItemID()
        {
            if (rbtn6.Checked) return "FG001"; // Ergonomic Office Chair
            if (rbtn7.Checked) return "FG002"; // Mahogany Dining Table
            if (rbtn8.Checked) return "FG003"; // 3-Seater Velvet Sofa
            if (rbtn9.Checked) return "FG004"; // Minimalist Study Desk
            if (rbtn10.Checked) return "FG005"; // Modular Bookcase Rack
            return null;
        }

        // 輔助方法：將資料發送至後端 (POST)
        private async Task<string> SubmitOrderToApi(Dictionary<string, string> payload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(payload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/SubmitOrder";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    return $"ERROR: HTTP {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"ERROR:{ex.Message}";
            }
        }

        
    }
}
