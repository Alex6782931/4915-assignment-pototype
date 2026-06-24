namespace _4915_assignment_pototype
{
    partial class CustomerMain
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
            lblwelcome = new Label();
            btnmakeorder = new Button();
            btnviewhistory = new Button();
            btncancelorder = new Button();
            btnaddress = new Button();
            btnlogout = new Button();
            btnpayment = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Location = new Point(44, 28);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(90, 23);
            lblwelcome.TabIndex = 0;
            lblwelcome.Text = "welcome,";
            // 
            // btnmakeorder
            // 
            btnmakeorder.Location = new Point(94, 176);
            btnmakeorder.Name = "btnmakeorder";
            btnmakeorder.Size = new Size(169, 31);
            btnmakeorder.TabIndex = 1;
            btnmakeorder.Text = "Order product ";
            btnmakeorder.UseVisualStyleBackColor = true;
            // 
            // btnviewhistory
            // 
            btnviewhistory.Location = new Point(94, 224);
            btnviewhistory.Name = "btnviewhistory";
            btnviewhistory.Size = new Size(190, 29);
            btnviewhistory.TabIndex = 2;
            btnviewhistory.Text = "View order history";
            btnviewhistory.UseVisualStyleBackColor = true;
            // 
            // btncancelorder
            // 
            btncancelorder.Location = new Point(94, 273);
            btncancelorder.Name = "btncancelorder";
            btncancelorder.Size = new Size(157, 35);
            btncancelorder.TabIndex = 3;
            btncancelorder.Text = "Cancel order";
            btncancelorder.UseVisualStyleBackColor = true;
            // 
            // btnaddress
            // 
            btnaddress.Location = new Point(446, 176);
            btnaddress.Name = "btnaddress";
            btnaddress.Size = new Size(220, 29);
            btnaddress.TabIndex = 4;
            btnaddress.Text = "modify/add address";
            btnaddress.UseVisualStyleBackColor = true;
            // 
            // btnlogout
            // 
            btnlogout.Location = new Point(621, 30);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(120, 33);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = true;
            // 
            // btnpayment
            // 
            btnpayment.Location = new Point(446, 224);
            btnpayment.Name = "btnpayment";
            btnpayment.Size = new Size(295, 35);
            btnpayment.TabIndex = 6;
            btnpayment.Text = "modify payment information";
            btnpayment.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 123);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 7;
            label1.Text = "product order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 123);
            label2.Name = "label2";
            label2.Size = new Size(189, 23);
            label2.TabIndex = 8;
            label2.Text = "personal information";
            // 
            // CustomerMain
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnpayment);
            Controls.Add(btnlogout);
            Controls.Add(btnaddress);
            Controls.Add(btncancelorder);
            Controls.Add(btnviewhistory);
            Controls.Add(btnmakeorder);
            Controls.Add(lblwelcome);
            Name = "CustomerMain";
            Text = "CustomerMian";
            Load += CustomerMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblwelcome;
        private Button btnmakeorder;
        private Button btnviewhistory;
        private Button btncancelorder;
        private Button btnaddress;
        private Button btnlogout;
        private Button btnpayment;
        private Label label1;
        private Label label2;
    }
}