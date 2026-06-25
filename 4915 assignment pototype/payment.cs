using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class payment : Form
    {
        // 指向你的 API 伺服器基礎 URL
        private readonly string baseApiUrl = "https://localhost:7146/api/SimpleGetAPI";
        private int currentCustomerNumber;

        // 修改建構子：讓它像 Address 一樣接收登入的客戶編號
        public payment(int customerNumber)
        {
            InitializeComponent();
            this.currentCustomerNumber = customerNumber;
        }

        // 頁面載入時，自動從 API 讀取目前的付款資訊
        private async void payment_Load(object sender, EventArgs e)
        {
            await LoadCustomerPaymentFromApi();
        }

        private void btnPback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // 「修改」按鈕點擊事件
        private async void btnPmodify_Click_1(object sender, EventArgs e)
        {
            // 1. 收集輸入欄位文字
            string cardNumber = txtbPcardnum.Text.Trim();
            string expiredDay = txtbexpireddate.Text.Trim();
            string cvv = txtbcvv.Text.Trim();

            // 2. 欄位驗證：因為是付款資訊，全部皆為必填
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiredDay) || string.IsNullOrEmpty(cvv))
            {
                MessageBox.Show("All payment fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. 打包成字典檔 Payload（格式與 Address 一致）
            var paymentData = new Dictionary<string, string>
            {
                { "customerNumber", currentCustomerNumber.ToString() },
                { "cardNumber", cardNumber },
                { "expiredDay", expiredDay },
                { "cvv", cvv }
            };

            // 4. 非同步發送請求至後端 API
            bool success = await UpdateCustomerPaymentViaApi(paymentData);

            if (success)
            {
                MessageBox.Show("Payment information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 輔助方法：向 API 獲取資料 (GET)
        private async Task LoadCustomerPaymentFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{baseApiUrl}/GetCustomerPayment?customerNumber={currentCustomerNumber}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement root = doc.RootElement;

                            // 安全地將資料寫入對應的 TextBox
                            txtbPcardnum.Text = root.TryGetProperty("cardNumber", out var c) && c.ValueKind != JsonValueKind.Null ? c.GetString() : "";
                            txtbexpireddate.Text = root.TryGetProperty("expiredDay", out var eDay) && eDay.ValueKind != JsonValueKind.Null ? eDay.GetString() : "";
                            txtbcvv.Text = root.TryGetProperty("cvv", out var cv) && cv.ValueKind != JsonValueKind.Null ? cv.GetString() : "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer payment details not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network initialization fault: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 輔助方法：將更新後的資料提交給 API (POST)
        private async Task<bool> UpdateCustomerPaymentViaApi(Dictionary<string, string> paymentPayload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = JsonSerializer.Serialize(paymentPayload);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = $"{baseApiUrl}/UpdateCustomerPayment";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // 讀取回傳的字串狀態碼是否為 SUCCESS
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result == "SUCCESS";
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Network communication error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        
    }
}
