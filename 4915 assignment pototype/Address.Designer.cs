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
            btnAback.Location = new Point(12, 12);
            btnAback.Name = "btnAback";
            btnAback.Size = new Size(128, 37);
            btnAback.TabIndex = 0;
            btnAback.Text = "back";
            btnAback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 19);
            label1.Name = "label1";
            label1.Size = new Size(146, 23);
            label1.TabIndex = 1;
            label1.Text = "Address Modify ";
            // 
            // txtbAfloor
            // 
            txtbAfloor.Location = new Point(159, 90);
            txtbAfloor.Name = "txtbAfloor";
            txtbAfloor.Size = new Size(312, 30);
            txtbAfloor.TabIndex = 2;
            // 
            // txtbAbuilding
            // 
            txtbAbuilding.Location = new Point(159, 156);
            txtbAbuilding.Name = "txtbAbuilding";
            txtbAbuilding.Size = new Size(150, 30);
            txtbAbuilding.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 98);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 4;
            label2.Text = "floor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 159);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 5;
            label3.Text = "building";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 224);
            label4.Name = "label4";
            label4.Size = new Size(59, 23);
            label4.TabIndex = 6;
            label4.Text = "street";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 281);
            label5.Name = "label5";
            label5.Size = new Size(40, 23);
            label5.TabIndex = 7;
            label5.Text = "city";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 340);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 8;
            label6.Text = "country";
            // 
            // txtbAstreet
            // 
            txtbAstreet.Location = new Point(159, 217);
            txtbAstreet.Name = "txtbAstreet";
            txtbAstreet.Size = new Size(302, 30);
            txtbAstreet.TabIndex = 9;
            // 
            // txtbAcity
            // 
            txtbAcity.Location = new Point(159, 281);
            txtbAcity.Name = "txtbAcity";
            txtbAcity.Size = new Size(304, 30);
            txtbAcity.TabIndex = 10;
            // 
            // txtbcountry
            // 
            txtbcountry.Location = new Point(159, 340);
            txtbcountry.Name = "txtbcountry";
            txtbcountry.Size = new Size(325, 30);
            txtbcountry.TabIndex = 11;
            // 
            // btnAmodify
            // 
            btnAmodify.Location = new Point(535, 409);
            btnAmodify.Name = "btnAmodify";
            btnAmodify.Size = new Size(171, 29);
            btnAmodify.TabIndex = 12;
            btnAmodify.Text = "modify";
            btnAmodify.UseVisualStyleBackColor = true;
            // 
            // Address
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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