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

        public CustomerMain()
        {
            InitializeComponent();
            AttachEventHandlers();
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
            OrderHistory orderForm = new OrderHistory();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Order History Screen...", "Prototype Action");
        }


        private void Btnaddress_Click(object sender, EventArgs e)
        {
            Address orderForm = new Address();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Address Management Screen...", "Prototype Action");
        }

        // 5. Modify Payment Information
        private void Btnpayment_Click(object sender, EventArgs e)
        {
            payment orderForm = new payment();
            NavigateTo(orderForm);

            MessageBox.Show("Navigating to Payment Information Screen...", "Prototype Action");
        }

        // 6. Logout
        private void Btnlogout_Click(object sender, EventArgs e)
        {
            Login orderForm = new Login();
            NavigateTo(orderForm);

            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Closes this main dashboard screen
                this.Close();

                // OPTIONAL: If you want to bring back a login screen:
                // LoginForm login = new LoginForm();
                // login.Show();
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
    }
}