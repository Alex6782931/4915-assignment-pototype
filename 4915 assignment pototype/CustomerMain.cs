using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class CustomerMain : Form
    {
        private string _loggedInCustomerId;

        public CustomerMain()
        {
            InitializeComponent();
            AttachEventHandlers();
        }

        public CustomerMain(string customerId) : this()
        {
            _loggedInCustomerId = customerId;
        }

        private void AttachEventHandlers()
        {
            btnviewhistory.Click += Btnviewhistory_Click;
            btnaddress.Click += Btnaddress_Click;
            btnpayment.Click += Btnpayment_Click;
            btnlogout.Click += Btnlogout_Click;
        }

        private void Btnviewhistory_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                OrderHistory orderForm = new OrderHistory(customerIdInt);
                NavigateTo(orderForm);
            }
            else
            {
                MessageBox.Show("Invalid Customer ID format. Cannot load order history.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnaddress_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                Address addressForm = new Address(customerIdInt);
                NavigateTo(addressForm);
            }
            else
            {
                MessageBox.Show("Invalid Customer ID format. Cannot load profile details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnpayment_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                payment paymentForm = new payment(customerIdInt);
                NavigateTo(paymentForm);
            }
            else
            {
                MessageBox.Show("Invalid Customer ID format. Cannot load payment profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.FormClosed -= CustomerMain_FormClosed;
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
        }

        private void NavigateTo(Form nextForm)
        {
            this.Hide();
            nextForm.ShowDialog();
            this.Show();
        }

        private void CustomerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void CustomerMain_Load(object sender, EventArgs e)
        {
            lblwelcome.Text = "Loading details...";

            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                string customerName = await FetchCustomerNameFromApi(customerIdInt);
                lblwelcome.Text = $"Welcome back, {customerName} ";
            }
            else
            {
                lblwelcome.Text = $"Welcome back, Customer ({_loggedInCustomerId})";
            }
        }

        private async Task<string> FetchCustomerNameFromApi(int customerId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/GetCustomerName/{customerId}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            if (doc.RootElement.TryGetProperty("customerName", out JsonElement nameElement))
                            {
                                return nameElement.GetString();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return "Customer";
        }

        private void btnpayment_Click_1(object sender, EventArgs e)
        {
        }

        private void btncancelorder_Click(object sender, EventArgs e)
        {
            Cancel cancelForm = new Cancel(_loggedInCustomerId);
            cancelForm.Show();
            this.Hide();
        }

        private void btnmakeorder_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                MakeOrder orderForm = new MakeOrder(customerIdInt);
                NavigateTo(orderForm);
            }
            else
            {
                MessageBox.Show("Invalid Customer ID format. Cannot proceed to order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                changepassword changeForm = new changepassword(customerIdInt);
                NavigateTo(changeForm);
            }
            else
            {
                MessageBox.Show("Invalid Customer ID format. Cannot proceed to order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}