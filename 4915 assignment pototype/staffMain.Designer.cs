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
            btnOrderdata = new Button();
            btninventorydata = new Button();
            btnMaterialdata = new Button();
            btnLogisticsdata = new Button();
            btnMdm = new Button();
            btnstaff = new Button();
            lblstaffname = new Label();
            label2 = new Label();
            btnprocurement = new Button();
            btnAS = new Button();
            btnLogout = new Button();
            btnCust = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblwel
            // 
            lblwel.AutoSize = true;
            lblwel.Location = new Point(351, 71);
            lblwel.Name = "lblwel";
            lblwel.Size = new Size(0, 15);
            lblwel.TabIndex = 0;
            // 
            // btnOrderdata
            // 
            btnOrderdata.Location = new Point(57, 143);
            btnOrderdata.Name = "btnOrderdata";
            btnOrderdata.Size = new Size(75, 23);
            btnOrderdata.TabIndex = 1;
            btnOrderdata.Text = "Order";
            btnOrderdata.UseVisualStyleBackColor = true;
            btnOrderdata.Click += button1_Click;
            // 
            // btninventorydata
            // 
            btninventorydata.Location = new Point(294, 188);
            btninventorydata.Name = "btninventorydata";
            btninventorydata.Size = new Size(75, 23);
            btninventorydata.TabIndex = 2;
            btninventorydata.Text = "Inventory";
            btninventorydata.UseVisualStyleBackColor = true;
            // 
            // btnMaterialdata
            // 
            btnMaterialdata.Location = new Point(294, 236);
            btnMaterialdata.Name = "btnMaterialdata";
            btnMaterialdata.Size = new Size(75, 23);
            btnMaterialdata.TabIndex = 3;
            btnMaterialdata.Text = "Material";
            btnMaterialdata.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsdata
            // 
            btnLogisticsdata.Location = new Point(57, 188);
            btnLogisticsdata.Name = "btnLogisticsdata";
            btnLogisticsdata.Size = new Size(75, 23);
            btnLogisticsdata.TabIndex = 4;
            btnLogisticsdata.Text = "Logistics";
            btnLogisticsdata.UseVisualStyleBackColor = true;
            // 
            // btnMdm
            // 
            btnMdm.Location = new Point(534, 153);
            btnMdm.Name = "btnMdm";
            btnMdm.Size = new Size(151, 25);
            btnMdm.TabIndex = 5;
            btnMdm.Text = "Master Data Maintance";
            btnMdm.UseVisualStyleBackColor = true;
            // 
            // btnstaff
            // 
            btnstaff.Location = new Point(534, 188);
            btnstaff.Name = "btnstaff";
            btnstaff.Size = new Size(69, 23);
            btnstaff.TabIndex = 6;
            btnstaff.Text = "staff";
            btnstaff.UseVisualStyleBackColor = true;
            // 
            // lblstaffname
            // 
            lblstaffname.AutoSize = true;
            lblstaffname.Location = new Point(47, 26);
            lblstaffname.Name = "lblstaffname";
            lblstaffname.Size = new Size(55, 15);
            lblstaffname.TabIndex = 7;
            lblstaffname.Text = "welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 71);
            label2.Name = "label2";
            label2.Size = new Size(158, 15);
            label2.TabIndex = 8;
            label2.Text = "please choose youe function";
            // 
            // btnprocurement
            // 
            btnprocurement.Location = new Point(294, 143);
            btnprocurement.Name = "btnprocurement";
            btnprocurement.Size = new Size(75, 23);
            btnprocurement.TabIndex = 9;
            btnprocurement.Text = "Procurement";
            btnprocurement.UseVisualStyleBackColor = true;
            // 
            // btnAS
            // 
            btnAS.Location = new Point(57, 232);
            btnAS.Name = "btnAS";
            btnAS.Size = new Size(147, 27);
            btnAS.TabIndex = 10;
            btnAS.Text = "After service";
            btnAS.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(694, 26);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnCust
            // 
            btnCust.Location = new Point(534, 232);
            btnCust.Name = "btnCust";
            btnCust.Size = new Size(75, 23);
            btnCust.TabIndex = 12;
            btnCust.Text = "Customer";
            btnCust.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 123);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 13;
            label1.Text = "order manage";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(294, 123);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 14;
            label3.Text = "material manage";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 123);
            label4.Name = "label4";
            label4.Size = new Size(125, 15);
            label4.TabIndex = 15;
            label4.Text = "personal info manage ";
            // 
            // staffMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCust);
            Controls.Add(btnLogout);
            Controls.Add(btnAS);
            Controls.Add(btnprocurement);
            Controls.Add(label2);
            Controls.Add(lblstaffname);
            Controls.Add(btnstaff);
            Controls.Add(btnMdm);
            Controls.Add(btnLogisticsdata);
            Controls.Add(btnMaterialdata);
            Controls.Add(btninventorydata);
            Controls.Add(btnOrderdata);
            Controls.Add(lblwel);
            Name = "staffMain";
            Text = "staffMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblwel;
        private Button btnOrderdata;
        private Button btninventorydata;
        private Button btnMaterialdata;
        private Button btnLogisticsdata;
        private Button btnMdm;
        private Button btnstaff;
        private Label lblstaffname;
        private Label label2;
        private Button btnprocurement;
        private Button btnAS;
        private Button btnLogout;
        private Button btnCust;
        private Label label1;
        private Label label3;
        private Label label4;
    }
}