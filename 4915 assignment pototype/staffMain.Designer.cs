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
            btnssac = new Button();
            lblstaffname = new Label();
            label2 = new Label();
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
            btnOrderdata.Location = new Point(128, 155);
            btnOrderdata.Name = "btnOrderdata";
            btnOrderdata.Size = new Size(75, 23);
            btnOrderdata.TabIndex = 1;
            btnOrderdata.Text = "Order";
            btnOrderdata.UseVisualStyleBackColor = true;
            btnOrderdata.Click += button1_Click;
            // 
            // btninventorydata
            // 
            btninventorydata.Location = new Point(472, 155);
            btninventorydata.Name = "btninventorydata";
            btninventorydata.Size = new Size(75, 23);
            btninventorydata.TabIndex = 2;
            btninventorydata.Text = "Inventory";
            btninventorydata.UseVisualStyleBackColor = true;
            // 
            // btnMaterialdata
            // 
            btnMaterialdata.Location = new Point(245, 155);
            btnMaterialdata.Name = "btnMaterialdata";
            btnMaterialdata.Size = new Size(75, 23);
            btnMaterialdata.TabIndex = 3;
            btnMaterialdata.Text = "Material";
            btnMaterialdata.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsdata
            // 
            btnLogisticsdata.Location = new Point(364, 155);
            btnLogisticsdata.Name = "btnLogisticsdata";
            btnLogisticsdata.Size = new Size(75, 23);
            btnLogisticsdata.TabIndex = 4;
            btnLogisticsdata.Text = "Logistics";
            btnLogisticsdata.UseVisualStyleBackColor = true;
            // 
            // btnMdm
            // 
            btnMdm.Location = new Point(138, 215);
            btnMdm.Name = "btnMdm";
            btnMdm.Size = new Size(189, 25);
            btnMdm.TabIndex = 5;
            btnMdm.Text = "Master Data Maintance";
            btnMdm.UseVisualStyleBackColor = true;
            // 
            // btnssac
            // 
            btnssac.Location = new Point(374, 215);
            btnssac.Name = "btnssac";
            btnssac.Size = new Size(184, 23);
            btnssac.TabIndex = 6;
            btnssac.Text = "System security and Control";
            btnssac.UseVisualStyleBackColor = true;
            // 
            // lblstaffname
            // 
            lblstaffname.AutoSize = true;
            lblstaffname.Location = new Point(134, 48);
            lblstaffname.Name = "lblstaffname";
            lblstaffname.Size = new Size(55, 15);
            lblstaffname.TabIndex = 7;
            lblstaffname.Text = "welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 97);
            label2.Name = "label2";
            label2.Size = new Size(158, 15);
            label2.TabIndex = 8;
            label2.Text = "please choose youe function";
            // 
            // staffMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblstaffname);
            Controls.Add(btnssac);
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
        private Button btnssac;
        private Label lblstaffname;
        private Label label2;
    }
}