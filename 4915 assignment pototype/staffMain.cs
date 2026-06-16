using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype.staff
{
    public partial class staffMain : Form
    {
        public staffMain()
        {
            InitializeComponent();
        }

        private void btnGoCustomer_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            customerForm.Show();
            this.Hide(); // Hides the main menu so it stays cleanly in the background
        }

        private void btnGoAfterService_Click(object sender, EventArgs e)
        {
            AfterService afterServiceForm = new AfterService();
            afterServiceForm.Show();
            this.Hide();
        }

        private void btnGoOrders_Click(object sender, EventArgs e)
        {
            Order orderForm = new Order(); // Ensure lowercase 'o' matches your file name!
            orderForm.Show();
            this.Hide();
        }

        private void btnGoInventory_Click(object sender, EventArgs e)
        {
            Inventory inventoryForm = new Inventory();
            inventoryForm.Show();
            this.Hide();
        }

        private void btnGoProcurement_Click(object sender, EventArgs e)
        {
            Procurement procurementForm = new Procurement();
            procurementForm.Show();
            this.Hide();
        }

        private void btnGoStaff_Click(object sender, EventArgs e)
        {
            Staff staffForm = new Staff();
            staffForm.Show();
            this.Hide();
        }

        private void btnGoSupplier_Click(object sender, EventArgs e)
        {
            Supplier supplierForm = new Supplier();
            supplierForm.Show();
            this.Hide();
        }

        private void btnGoUser_account_Click(object sender, EventArgs e)
        {
            User_Account accountForm = new User_Account();
            accountForm.Show();
            this.Hide();
        }

        private void btnGoLogistics_Click(object sender, EventArgs e)
        {
            Logistics logisticsForm = new Logistics();
            logisticsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. Create and show a fresh instance of the login window
            Login loginForm = new Login();
            loginForm.Show();

            // 2. Permanently close and dispose of the main menu form
            this.Close();
        }
    }
}
