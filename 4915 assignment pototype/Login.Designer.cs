namespace _4915_assignment_pototype
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbluserName = new Label();
            lblpassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnregister = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbluserName
            // 
            lbluserName.AutoSize = true;
            lbluserName.Location = new Point(281, 137);
            lbluserName.Margin = new Padding(4, 0, 4, 0);
            lbluserName.Name = "lbluserName";
            lbluserName.Size = new Size(80, 20);
            lbluserName.TabIndex = 1;
            lbluserName.Text = "user Name";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(281, 223);
            lblpassword.Margin = new Padding(4, 0, 4, 0);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(70, 20);
            lblpassword.TabIndex = 2;
            lblpassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(383, 133);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(141, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(383, 218);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(141, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(314, 296);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(86, 30);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnregister
            // 
            btnregister.Location = new Point(428, 292);
            btnregister.Margin = new Padding(2, 3, 2, 3);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(91, 34);
            btnregister.TabIndex = 6;
            btnregister.Text = "Register";
            btnregister.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 70);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 7;
            label1.Text = "Login ";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 436);
            Controls.Add(label1);
            Controls.Add(btnregister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblpassword);
            Controls.Add(lbluserName);
            Margin = new Padding(4);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbluserName;
        private Label lblpassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnregister;
        private Label label1;
    }
}
