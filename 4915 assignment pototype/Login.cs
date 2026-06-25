using _4915_assignment_pototype;
using _4915_assignment_pototype.staff;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please type in both fields to request access verification.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/VerifyLogin?username={user}&password={pass}";
                    HttpResponseMessage response = await client.PostAsync(url, null);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        // 1. 处理用户名不存在
                        if (result.Contains("FAILED_USER_NOT_FOUND"))
                        {
                            MessageBox.Show("Access Denied: Invalid username provided.");
                        }
                        // 2. 处理密码错误
                        else if (result.Contains("FAILED_WRONG_PASSWORD"))
                        {
                            MessageBox.Show("Access Denied: Invalid security password provided.");
                        }
                        // 3. 处理员工登录路由
                        else if (result.StartsWith("STAFF_ROUTE:"))
                        {
                            string routeData = result.Replace("STAFF_ROUTE:", "");

                            // 同样使用逗号分割字符串
                            string[] dataParts = routeData.Split(',');
                            string actualRole = dataParts[0];
                            string staffId = dataParts.Length > 1 ? dataParts[1] : string.Empty;

                            MessageBox.Show($"Access Granted! Welcome back Internal Staff.\nAuthorized Role: {actualRole}\nStaff ID: {staffId}");

                            // 暂时取消窗体关闭监听，防止隐藏引发退出冲突
                            this.FormClosed -= Login_FormClosed;

                            // 如果今后 staffMain 也需要传参，可改为 new staffMain(staffId);
                            staffMain mainMenu = new staffMain();
                            mainMenu.Show();

                            this.Hide();
                        }
                        // 4. 处理客户登录路由
                        else if (result.StartsWith("CUSTOMER_ROUTE:"))
                        {
                            // 去掉前缀，数据变为 "accessLevel,customerId" 的格式
                            string routeData = result.Replace("CUSTOMER_ROUTE:", "");

                            // 使用逗号分割字符串
                            string[] dataParts = routeData.Split(',');
                            string actualRole = dataParts[0];

                            // 安全地获取 customerId，防御一重或漏传引发的数组越界
                            string customerId = dataParts.Length > 1 ? dataParts[1] : string.Empty;

                            MessageBox.Show($"Access Granted! Welcome back Customer.\nAuthorized Role: {actualRole}\nCustomer ID: {customerId}");

                            // 暂时取消窗体关闭监听，防止干扰应用程序域
                            this.FormClosed -= Login_FormClosed;

                            // 【关键】将解出的客户 ID 作为参数正常实例化并跳转
                            CustomerMain customerMenu = new CustomerMain(customerId);
                            customerMenu.Show();

                            this.Hide();
                        }
                        // 5. 无法识别的兜底路由
                        else
                        {
                            MessageBox.Show($"Access Granted! Welcome back.\nRaw routing response config: {result}");

                            this.FormClosed -= Login_FormClosed;

                            staffMain mainMenu = new staffMain();
                            mainMenu.Show();

                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Security authentication routing server error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to authentication server module: {ex.Message}");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register newForm = new Register();
            newForm.Show();
        }
    }
}