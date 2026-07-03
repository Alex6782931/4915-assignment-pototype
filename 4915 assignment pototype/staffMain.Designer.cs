namespace _4915_assignment_pototype.staff
{
    partial class staffMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowOrder = new FlowLayoutPanel();
            btnGoOrders = new Button();
            btnGoLogistics = new Button();
            btnGoAfterService = new Button();
            btncustomize = new Button();
            flowMaterial = new FlowLayoutPanel();
            btnGoProcurement = new Button();
            btnGoInventory = new Button();
            flowPersonal = new FlowLayoutPanel();
            btnGoUser_account = new Button();
            btnGoStaff = new Button();
            btnGoCustomer = new Button();
            btnGoSupplier = new Button();
            lblwel = new Label();
            lblstaffname = new Label();
            btnLogout = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            flowOrder.SuspendLayout();
            flowMaterial.SuspendLayout();
            flowPersonal.SuspendLayout();
            SuspendLayout();
            // 
            // flowOrder
            // 
            flowOrder.Controls.Add(btnGoOrders);
            flowOrder.Controls.Add(btnGoLogistics);
            flowOrder.Controls.Add(btnGoAfterService);
            flowOrder.Controls.Add(btncustomize);
            flowOrder.FlowDirection = FlowDirection.TopDown;
            flowOrder.Location = new Point(40, 150);
            flowOrder.Name = "flowOrder";
            flowOrder.Size = new Size(180, 250);
            flowOrder.TabIndex = 0;
            // 
            // btnGoOrders
            // 
            btnGoOrders.Location = new Point(3, 3);
            btnGoOrders.Name = "btnGoOrders";
            btnGoOrders.Size = new Size(150, 35);
            btnGoOrders.TabIndex = 0;
            btnGoOrders.Text = "Order";
            btnGoOrders.Click += btnGoOrders_Click;
            // 
            // btnGoLogistics
            // 
            btnGoLogistics.Location = new Point(3, 44);
            btnGoLogistics.Name = "btnGoLogistics";
            btnGoLogistics.Size = new Size(150, 35);
            btnGoLogistics.TabIndex = 1;
            btnGoLogistics.Text = "Logistics";
            btnGoLogistics.Click += btnGoLogistics_Click;
            // 
            // btnGoAfterService
            // 
            btnGoAfterService.Location = new Point(3, 85);
            btnGoAfterService.Name = "btnGoAfterService";
            btnGoAfterService.Size = new Size(150, 35);
            btnGoAfterService.TabIndex = 2;
            btnGoAfterService.Text = "After service";
            btnGoAfterService.Click += btnGoAfterService_Click;
            // 
            // btncustomize
            // 
            btncustomize.Location = new Point(3, 126);
            btncustomize.Name = "btncustomize";
            btncustomize.Size = new Size(150, 35);
            btncustomize.TabIndex = 3;
            btncustomize.Text = "Customize order";
            // 
            // flowMaterial
            // 
            flowMaterial.Controls.Add(btnGoProcurement);
            flowMaterial.Controls.Add(btnGoInventory);
            flowMaterial.FlowDirection = FlowDirection.TopDown;
            flowMaterial.Location = new Point(280, 150);
            flowMaterial.Name = "flowMaterial";
            flowMaterial.Size = new Size(180, 250);
            flowMaterial.TabIndex = 1;
            // 
            // btnGoProcurement
            // 
            btnGoProcurement.Location = new Point(3, 3);
            btnGoProcurement.Name = "btnGoProcurement";
            btnGoProcurement.Size = new Size(150, 35);
            btnGoProcurement.TabIndex = 0;
            btnGoProcurement.Text = "Procurement";
            btnGoProcurement.Click += btnGoProcurement_Click;
            // 
            // btnGoInventory
            // 
            btnGoInventory.Location = new Point(3, 44);
            btnGoInventory.Name = "btnGoInventory";
            btnGoInventory.Size = new Size(150, 35);
            btnGoInventory.TabIndex = 1;
            btnGoInventory.Text = "Inventory";
            btnGoInventory.Click += btnGoInventory_Click;
            // 
            // flowPersonal
            // 
            flowPersonal.Controls.Add(btnGoUser_account);
            flowPersonal.Controls.Add(btnGoStaff);
            flowPersonal.Controls.Add(btnGoCustomer);
            flowPersonal.Controls.Add(btnGoSupplier);
            flowPersonal.FlowDirection = FlowDirection.TopDown;
            flowPersonal.Location = new Point(520, 150);
            flowPersonal.Name = "flowPersonal";
            flowPersonal.Size = new Size(180, 250);
            flowPersonal.TabIndex = 2;
            // 
            // btnGoUser_account
            // 
            btnGoUser_account.Location = new Point(3, 3);
            btnGoUser_account.Name = "btnGoUser_account";
            btnGoUser_account.Size = new Size(150, 35);
            btnGoUser_account.TabIndex = 0;
            btnGoUser_account.Text = "User Accounts";
            btnGoUser_account.Click += btnGoUser_account_Click;
            // 
            // btnGoStaff
            // 
            btnGoStaff.Location = new Point(3, 44);
            btnGoStaff.Name = "btnGoStaff";
            btnGoStaff.Size = new Size(150, 35);
            btnGoStaff.TabIndex = 1;
            btnGoStaff.Text = "Staff";
            btnGoStaff.Click += btnGoStaff_Click;
            // 
            // btnGoCustomer
            // 
            btnGoCustomer.Location = new Point(3, 85);
            btnGoCustomer.Name = "btnGoCustomer";
            btnGoCustomer.Size = new Size(150, 35);
            btnGoCustomer.TabIndex = 2;
            btnGoCustomer.Text = "Customer";
            btnGoCustomer.Click += btnGoCustomer_Click;
            // 
            // btnGoSupplier
            // 
            btnGoSupplier.Location = new Point(3, 126);
            btnGoSupplier.Name = "btnGoSupplier";
            btnGoSupplier.Size = new Size(150, 35);
            btnGoSupplier.TabIndex = 3;
            btnGoSupplier.Text = "Supplier";
            btnGoSupplier.Click += btnGoSupplier_Click;
            // 
            // lblwel
            // 
            lblwel.Location = new Point(0, 0);
            lblwel.Name = "lblwel";
            lblwel.Size = new Size(100, 23);
            lblwel.TabIndex = 0;
            // 
            // lblstaffname
            // 
            lblstaffname.Location = new Point(40, 30);
            lblstaffname.Name = "lblstaffname";
            lblstaffname.Size = new Size(100, 23);
            lblstaffname.TabIndex = 6;
            lblstaffname.Text = "welcome";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(570, 30);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(87, 36);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // label1
            // 
            label1.Location = new Point(40, 120);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 3;
            label1.Text = "Order Manage:";
            // 
            // label3
            // 
            label3.Location = new Point(280, 120);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Material Manage:";
            // 
            // label4
            // 
            label4.Location = new Point(520, 120);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 5;
            label4.Text = "Personal Info Manage:";
            // 
            // staffMain
            // 
            ClientSize = new Size(730, 420);
            Controls.Add(flowOrder);
            Controls.Add(flowMaterial);
            Controls.Add(flowPersonal);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblstaffname);
            Controls.Add(btnLogout);
            Name = "staffMain";
            Text = "Staff Main Menu";
            flowOrder.ResumeLayout(false);
            flowMaterial.ResumeLayout(false);
            flowPersonal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblwel;
        private Button btnGoOrders;
        private Button btnGoInventory;
        private Button btnGoLogistics;
        private Button btnGoUser_account;
        private Button btnGoStaff;
        private Label lblstaffname;
        private Button btnGoProcurement;
        private Button btnGoAfterService;
        private Button btnLogout;
        private Button btnGoCustomer;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button btnGoSupplier;
        private Button btncustomize;
        private FlowLayoutPanel flowOrder;
        private FlowLayoutPanel flowMaterial;
        private FlowLayoutPanel flowPersonal;
    }
}