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
            lblwel = new Label();
            btnGoOrders = new Button();
            btnGoInventory = new Button();
            btnGoLogistics = new Button();
            btnGoUser_account = new Button();
            btnGoStaff = new Button();
            lblstaffname = new Label();
            label2 = new Label();
            btnGoProcurement = new Button();
            btnGoAfterService = new Button();
            btnLogout = new Button();
            btnGoCustomer = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGoSupplier = new Button();
            SuspendLayout();
            // 
            // lblwel
            // 
            lblwel.AutoSize = true;
            lblwel.Location = new Point(351, 71);
            lblwel.Margin = new Padding(4, 0, 4, 0);
            lblwel.Name = "lblwel";
            lblwel.Size = new Size(0, 15);
            lblwel.TabIndex = 0;
            // 
            // btnGoOrders
            // 
            btnGoOrders.Location = new Point(57, 142);
            btnGoOrders.Margin = new Padding(4, 3, 4, 3);
            btnGoOrders.Name = "btnGoOrders";
            btnGoOrders.Size = new Size(90, 22);
            btnGoOrders.TabIndex = 1;
            btnGoOrders.Text = "Order";
            btnGoOrders.UseVisualStyleBackColor = true;
            btnGoOrders.Click += btnGoOrders_Click;
            // 
            // btnGoInventory
            // 
            btnGoInventory.Location = new Point(294, 188);
            btnGoInventory.Margin = new Padding(4, 3, 4, 3);
            btnGoInventory.Name = "btnGoInventory";
            btnGoInventory.Size = new Size(90, 22);
            btnGoInventory.TabIndex = 2;
            btnGoInventory.Text = "Inventory";
            btnGoInventory.UseVisualStyleBackColor = true;
            btnGoInventory.Click += btnGoInventory_Click;
            // 
            // btnGoLogistics
            // 
            btnGoLogistics.Location = new Point(57, 188);
            btnGoLogistics.Margin = new Padding(4, 3, 4, 3);
            btnGoLogistics.Name = "btnGoLogistics";
            btnGoLogistics.Size = new Size(90, 22);
            btnGoLogistics.TabIndex = 4;
            btnGoLogistics.Text = "Logistics";
            btnGoLogistics.UseVisualStyleBackColor = true;
            btnGoLogistics.Click += btnGoLogistics_Click;
            // 
            // btnGoUser_account
            // 
            btnGoUser_account.Location = new Point(542, 142);
            btnGoUser_account.Margin = new Padding(4, 3, 4, 3);
            btnGoUser_account.Name = "btnGoUser_account";
            btnGoUser_account.Size = new Size(98, 25);
            btnGoUser_account.TabIndex = 5;
            btnGoUser_account.Text = "User Accounts";
            btnGoUser_account.UseVisualStyleBackColor = true;
            btnGoUser_account.Click += btnGoUser_account_Click;
            // 
            // btnGoStaff
            // 
            btnGoStaff.Location = new Point(542, 188);
            btnGoStaff.Margin = new Padding(4, 3, 4, 3);
            btnGoStaff.Name = "btnGoStaff";
            btnGoStaff.Size = new Size(98, 22);
            btnGoStaff.TabIndex = 6;
            btnGoStaff.Text = "Staff";
            btnGoStaff.UseVisualStyleBackColor = true;
            btnGoStaff.Click += btnGoStaff_Click;
            // 
            // lblstaffname
            // 
            lblstaffname.AutoSize = true;
            lblstaffname.Location = new Point(47, 26);
            lblstaffname.Margin = new Padding(4, 0, 4, 0);
            lblstaffname.Name = "lblstaffname";
            lblstaffname.Size = new Size(58, 15);
            lblstaffname.TabIndex = 7;
            lblstaffname.Text = "welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 71);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(168, 15);
            label2.TabIndex = 8;
            label2.Text = "please choose youe function";
            // 
            // btnGoProcurement
            // 
            btnGoProcurement.Location = new Point(294, 141);
            btnGoProcurement.Margin = new Padding(4, 3, 4, 3);
            btnGoProcurement.Name = "btnGoProcurement";
            btnGoProcurement.Size = new Size(90, 22);
            btnGoProcurement.TabIndex = 9;
            btnGoProcurement.Text = "Procurement";
            btnGoProcurement.UseVisualStyleBackColor = true;
            btnGoProcurement.Click += btnGoProcurement_Click;
            // 
            // btnGoAfterService
            // 
            btnGoAfterService.Location = new Point(57, 232);
            btnGoAfterService.Margin = new Padding(4, 3, 4, 3);
            btnGoAfterService.Name = "btnGoAfterService";
            btnGoAfterService.Size = new Size(90, 27);
            btnGoAfterService.TabIndex = 10;
            btnGoAfterService.Text = "After service";
            btnGoAfterService.UseVisualStyleBackColor = true;
            btnGoAfterService.Click += btnGoAfterService_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(694, 26);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 22);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnGoCustomer
            // 
            btnGoCustomer.Location = new Point(542, 232);
            btnGoCustomer.Margin = new Padding(4, 3, 4, 3);
            btnGoCustomer.Name = "btnGoCustomer";
            btnGoCustomer.Size = new Size(98, 22);
            btnGoCustomer.TabIndex = 12;
            btnGoCustomer.Text = "Customer";
            btnGoCustomer.UseVisualStyleBackColor = true;
            btnGoCustomer.Click += btnGoCustomer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 123);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 13;
            label1.Text = "Order Manage:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(294, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 14;
            label3.Text = "Material Manage:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(542, 123);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 15);
            label4.TabIndex = 15;
            label4.Text = "Personal Info Manage: ";
            // 
            // btnGoSupplier
            // 
            btnGoSupplier.Location = new Point(542, 282);
            btnGoSupplier.Margin = new Padding(3, 2, 3, 2);
            btnGoSupplier.Name = "btnGoSupplier";
            btnGoSupplier.Size = new Size(98, 22);
            btnGoSupplier.TabIndex = 16;
            btnGoSupplier.Text = "Supplier";
            btnGoSupplier.UseVisualStyleBackColor = true;
            btnGoSupplier.Click += btnGoSupplier_Click;
            // 
            // staffMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGoSupplier);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnGoCustomer);
            Controls.Add(btnLogout);
            Controls.Add(btnGoAfterService);
            Controls.Add(btnGoProcurement);
            Controls.Add(label2);
            Controls.Add(lblstaffname);
            Controls.Add(btnGoStaff);
            Controls.Add(btnGoUser_account);
            Controls.Add(btnGoLogistics);
            Controls.Add(btnGoInventory);
            Controls.Add(btnGoOrders);
            Controls.Add(lblwel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "staffMain";
            Text = "staffMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblwel;
        private Button btnGoOrders;
        private Button btnGoInventory;
        private Button btnGoLogistics;
        private Button btnGoUser_account;
        private Button btnGoStaff;
        private Label lblstaffname;
        private Label label2;
        private Button btnGoProcurement;
        private Button btnGoAfterService;
        private Button btnLogout;
        private Button btnGoCustomer;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button btnGoSupplier;
    }
}