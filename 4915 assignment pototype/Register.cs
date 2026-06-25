using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class Register : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public Register()
        {
            InitializeComponent();
        }

        private void btnRback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private async void btnRregister_Click(object sender, EventArgs e)
        {
            string user = txtbRusername.Text.Trim();
            string pass = txtbRpasswd.Text;
            string confipass = txtbRconfipasswd.Text;
            string firstname = txtbfistname.Text.Trim();
            string lastname = txtbLastname.Text.Trim();
            string phoneNumber = txtbphoneNum.Text.Trim();


            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill in all required fields (Username, Password, First/Last Name, and Phone).");
                return;
            }

            if (pass != confipass)
            {
                MessageBox.Show("Registration Denied: Passwords do not match.");
                return;
            }

            try
            {

                string url = $"https://localhost:7146/api/SimpleGetAPI/VerifyRegister?" +
                             $"username={Uri.EscapeDataString(user)}&" +
                             $"password={Uri.EscapeDataString(pass)}&" +
                             $"firstname={Uri.EscapeDataString(firstname)}&" +
                             $"lastname={Uri.EscapeDataString(lastname)}&" +
                             $"phone={Uri.EscapeDataString(phoneNumber)}&" +
                             $"city=Unknown&" +
                             $"country=Unknown";

                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    if (result.Contains("FAILED_USER_EXISTS"))
                    {
                        MessageBox.Show("Registration Denied: Username is already taken.");
                    }
                    else if (result.StartsWith("SUCCESS_REGISTERED:"))
                    {
                        string routeData = result.Replace("SUCCESS_REGISTERED:", "");


                        string[] dataParts = routeData.Split(',');
                        string actualFirstName = dataParts[0];
                        string customerId = dataParts.Length > 1 ? dataParts[1] : string.Empty;


                        MessageBox.Show($"Account successfully created!\n\nWelcome, {actualFirstName}!\nPlease log in now.");
                        this.Hide();
                        Login loginForm = new Login();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show($"Server registration error: {result}");
                    }
                }
                else
                {
                    MessageBox.Show($"Authentication server error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to authentication server module: {ex.Message}");
            }
        }
    }
}