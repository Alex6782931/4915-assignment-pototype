namespace _4915_assignment_pototype
{
    partial class Address
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
            btnAback = new Button();
            label1 = new Label();
            txtbAfloor = new TextBox();
            txtbAbuilding = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtbAstreet = new TextBox();
            txtbAcity = new TextBox();
            txtbcountry = new TextBox();
            btnAmodify = new Button();
            SuspendLayout();
            // 
            // btnAback
            // 
            btnAback.Location = new Point(8, 8);
            btnAback.Margin = new Padding(2, 2, 2, 2);
            btnAback.Name = "btnAback";
            btnAback.Size = new Size(81, 24);
            btnAback.TabIndex = 0;
            btnAback.Text = "back";
            btnAback.UseVisualStyleBackColor = true;
            btnAback.Click += btnAback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 12);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 1;
            label1.Text = "Address Modify ";
            // 
            // txtbAfloor
            // 
            txtbAfloor.Location = new Point(101, 59);
            txtbAfloor.Margin = new Padding(2, 2, 2, 2);
            txtbAfloor.Name = "txtbAfloor";
            txtbAfloor.Size = new Size(200, 23);
            txtbAfloor.TabIndex = 2;
            // 
            // txtbAbuilding
            // 
            txtbAbuilding.Location = new Point(101, 102);
            txtbAbuilding.Margin = new Padding(2, 2, 2, 2);
            txtbAbuilding.Name = "txtbAbuilding";
            txtbAbuilding.Size = new Size(97, 23);
            txtbAbuilding.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 64);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 4;
            label2.Text = "floor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 104);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 5;
            label3.Text = "building";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 146);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 6;
            label4.Text = "street";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 183);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 7;
            label5.Text = "city";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 222);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 8;
            label6.Text = "country";
            // 
            // txtbAstreet
            // 
            txtbAstreet.Location = new Point(101, 142);
            txtbAstreet.Margin = new Padding(2, 2, 2, 2);
            txtbAstreet.Name = "txtbAstreet";
            txtbAstreet.Size = new Size(194, 23);
            txtbAstreet.TabIndex = 9;
            // 
            // txtbAcity
            // 
            txtbAcity.Location = new Point(101, 183);
            txtbAcity.Margin = new Padding(2, 2, 2, 2);
            txtbAcity.Name = "txtbAcity";
            txtbAcity.Size = new Size(195, 23);
            txtbAcity.TabIndex = 10;
            // 
            // txtbcountry
            // 
            txtbcountry.Location = new Point(101, 222);
            txtbcountry.Margin = new Padding(2, 2, 2, 2);
            txtbcountry.Name = "txtbcountry";
            txtbcountry.Size = new Size(208, 23);
            txtbcountry.TabIndex = 11;
            // 
            // btnAmodify
            // 
            btnAmodify.Location = new Point(333, 255);
            btnAmodify.Margin = new Padding(2, 2, 2, 2);
            btnAmodify.Name = "btnAmodify";
            btnAmodify.Size = new Size(109, 27);
            btnAmodify.TabIndex = 12;
            btnAmodify.Text = "modify";
            btnAmodify.UseVisualStyleBackColor = true;
            btnAmodify.Click += btnAmodify_Click;
            // 
            // Address
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 293);
            Controls.Add(btnAmodify);
            Controls.Add(txtbcountry);
            Controls.Add(txtbAcity);
            Controls.Add(txtbAstreet);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtbAbuilding);
            Controls.Add(txtbAfloor);
            Controls.Add(label1);
            Controls.Add(btnAback);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Address";
            Text = "Address";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAback;
        private Label label1;
        private TextBox txtbAfloor;
        private TextBox txtbAbuilding;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtbAstreet;
        private TextBox txtbAcity;
        private TextBox txtbcountry;
        private Button btnAmodify;
    }
}