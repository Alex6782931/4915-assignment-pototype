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
        private string currentUserRole;

        // Constructor accepting the role string passed from Login.cs
        public staffMain(string role)
        {
            InitializeComponent();
            this.currentUserRole = role;
            ConfigureAccess();
        }

        private void ConfigureAccess()
        {
            // 1. Hide EVERYTHING by default to keep the UI clean and secure
            btnGoOrders.Visible = false;
            btnGoLogistics.Visible = false;
            btnGoAfterService.Visible = false;
            btncustomize.Visible = false;

            btnGoProcurement.Visible = false;
            btnGoInventory.Visible = false;

            btnGoUser_account.Visible = false;
            btnGoStaff.Visible = false;
            btnGoCustomer.Visible = false;
            btnGoSupplier.Visible = false;
            btncustomize.Visible = false;
            btncr.Visible = false;

            // 2. Enable buttons based on database accessLevel. 
            // The FlowLayoutPanels automatically shift lower buttons up to close any blank gaps.
            switch (currentUserRole)
            {
                case "Admin":
                    // Admin can see and click every function
                    btnGoOrders.Visible = true;
                    btnGoLogistics.Visible = true;
                    btnGoAfterService.Visible = true;
                    btncustomize.Visible = true;
                    btnGoProcurement.Visible = true;
                    btnGoInventory.Visible = true;
                    btnGoUser_account.Visible = true;
                    btnGoStaff.Visible = true;
                    btnGoCustomer.Visible = true;
                    btnGoSupplier.Visible = true;
                    btncustomize.Visible = true;
                    btncr.Visible = true;
                    break;

                case "Sales":
                    btnGoOrders.Visible = true;
                    btnGoCustomer.Visible = true;
                    btnGoAfterService.Visible = true;
                    btncustomize.Visible = true;
                    btncr.Visible = true;
                    break;

                case "Warehouse":
                    btnGoInventory.Visible = true;
                    btnGoLogistics.Visible = true;
                    break;

                case "Procurement":
                    btnGoProcurement.Visible = true;
                    btnGoSupplier.Visible = true;
                    break;

                case "Logistics":
                    btnGoLogistics.Visible = true;
                    break;

                case "Production":
                    btnGoInventory.Visible = true;
                    btncustomize.Visible = true;
                    btncr.Visible = true;
                    break;

                case "After-Service":
                    btnGoAfterService.Visible = true;
                    btnGoCustomer.Visible = true;
                    break;

                default:
                    // Fallback configuration if an unexpected role logs in
                    MessageBox.Show("Warning: Limited menu permissions applied for this account session.");
                    break;
            }
        }

        private void btnGoCustomer_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            customerForm.Show();
            this.Hide();
        }

        private void btnGoAfterService_Click(object sender, EventArgs e)
        {
            AfterService afterServiceForm = new AfterService();
            afterServiceForm.Show();
            this.Hide();
        }

        private void btnGoOrders_Click(object sender, EventArgs e)
        {
            Order orderForm = new Order();
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
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void StaffMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btncustomize_Click(object sender, EventArgs e)
        {
            customizeOrder customizeForm = new customizeOrder();
            customizeForm.Show();
            this.Hide();
        }

        private void btncr_Click(object sender, EventArgs e)
        {
            CustomizeRequired cr = new CustomizeRequired();
            cr.Show();
            this.Hide();
        }

        private void btnGoMessages_Click(object sender, EventArgs e)
        {
            MessagesForm msgForm = new MessagesForm();
            msgForm.Show();
            this.Hide();
        }
    }
}