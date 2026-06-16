using _4915_assignment_pototype.staff;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.CompilerServices;

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
                        else
                        {
                            // Success! Authorization Level is retrieved (e.g. 'Admin', 'Sales')
                            MessageBox.Show($"Access Granted! Welcome back. Authorized Role: {result}");

                            // Route user to your main program menu interface file
                            staffMain mainMenu = new staffMain();
                            mainMenu.Show();

                            this.Hide(); // Hides the login screen cleanly
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

    }
}
