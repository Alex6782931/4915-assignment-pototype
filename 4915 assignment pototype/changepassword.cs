using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class changepassword : Form
    {
        public changepassword()
        {
            InitializeComponent();
        }

        private async void btnsubmit_Click(object sender, EventArgs e)
        {
            string username = oldpass.Text.Trim();
            string oldPassword = .Text.Trim();
            string newPassword = txtnewpassword.Text.Trim();
            string confirmPassword = txtconfirmpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://your-api-url/api/account/changepassword?username={Uri.EscapeDataString(username)}&oldPassword={Uri.EscapeDataString(oldPassword)}&newPassword={Uri.EscapeDataString(newPassword)}";
                    HttpResponseMessage response = await client.PostAsync(apiUrl, null);
                    string result = await response.Content.ReadAsStringAsync();

                    if (result.Contains("SUCCESS_PASSWORD_UPDATED"))
                    {
                        MessageBox.Show("Password changed successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            if (mainForm != null) mainForm.Show();
            this.Close();
        }
    }
}