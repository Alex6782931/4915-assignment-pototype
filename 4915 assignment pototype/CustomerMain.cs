using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Binds the click events of the designer buttons to their respective logic methods.
        /// </summary>
        private void AttachEventHandlers()
        {
            btnviewhistory.Click += Btnviewhistory_Click;
            btnaddress.Click += Btnaddress_Click;
            btnpayment.Click += Btnpayment_Click;
            btnlogout.Click += Btnlogout_Click;
        }

        // 1. Order Product
        /*private void Btnmakeorder_Click(object sender, EventArgs e)
        {
            MakeOrder orderForm = new MakeOrder();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Order Product Screen...", "Prototype Action");
        }*/

        // 2. View Order History
        private void Btnviewhistory_Click(object sender, EventArgs e)
        {

            if (int.TryParse(_loggedInCustomerId, out int customerIdInt))
            {
                OrderHistory orderForm = new OrderHistory(customerIdInt); // 👈 傳入轉換後的整數 ID
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

        // 5. Modify Payment Information
        // 5. Modify Payment Information
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


        // 6. Logout
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

        /// <summary>
        /// Helper method to streamline form transition mechanics
        /// </summary>
        private void NavigateTo(Form nextForm)
        {
            this.Hide();            // Hides the current dashboard
            nextForm.ShowDialog();  // Opens the next screen as a modal window
            this.Show();            // Brings the dashboard back once the sub-screen is closed
        }

        private void CustomerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerMain_Load(object sender, EventArgs e)
        {
            lblwelcome.Text = $"Welcome back,: {_loggedInCustomerId}";
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