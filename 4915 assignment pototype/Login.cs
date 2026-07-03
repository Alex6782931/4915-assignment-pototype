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

                        if (result.Contains("FAILED_USER_NOT_FOUND"))
                        {
                            MessageBox.Show("Access Denied: Invalid username provided.");
                        }
                        else if (result.Contains("FAILED_WRONG_PASSWORD"))
                        {
                            MessageBox.Show("Access Denied: Invalid security password provided.");
                        }
                        else if (result.StartsWith("STAFF_ROUTE:"))
                        {
                            string routeData = result.Replace("STAFF_ROUTE:", "");

                            string[] dataParts = routeData.Split(',');
                            string actualRole = dataParts[0]; // This holds 'Admin', 'Sales', etc.
                            string staffId = dataParts.Length > 1 ? dataParts[1] : string.Empty;

                            MessageBox.Show($"Access Granted! Welcome back Internal Staff.\nAuthorized Role: {actualRole}\nStaff ID: {staffId}");

                            this.FormClosed -= Login_FormClosed;

                            // PASS THE ROLE INTO THE CONSTRUCTOR HERE
                            staffMain mainMenu = new staffMain(actualRole);
                            mainMenu.Show();

                            this.Hide();
                        }
                        else if (result.StartsWith("CUSTOMER_ROUTE:"))
                        {
                            string routeData = result.Replace("CUSTOMER_ROUTE:", "");

                            string[] dataParts = routeData.Split(',');
                            string actualRole = dataParts[0];

                            string customerId = dataParts.Length > 1 ? dataParts[1] : string.Empty;

                            MessageBox.Show($"Access Granted! Welcome back Customer");

                            this.FormClosed -= Login_FormClosed;

                            CustomerMain customerMenu = new CustomerMain(customerId);
                            customerMenu.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Access Granted! Welcome back.\nRaw routing response config: {result}");

                            this.FormClosed -= Login_FormClosed;

                            string fallbackRole = "Unknown";
                            if (result.StartsWith("UNKNOWN_ROUTE:"))
                            {
                                string routeData = result.Replace("UNKNOWN_ROUTE:", "");
                                string[] dataParts = routeData.Split(',');
                                fallbackRole = dataParts[0];
                            }

                            staffMain mainMenu = new staffMain(fallbackRole);
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

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}