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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lbluserName = new Label();
            lblpassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnregister = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbluserName
            // 
            lbluserName.AutoSize = true;
            lbluserName.Location = new Point(24, 156);
            lbluserName.Margin = new Padding(6, 0, 6, 0);
            lbluserName.Name = "lbluserName";
            lbluserName.Size = new Size(103, 23);
            lbluserName.TabIndex = 1;
            lbluserName.Text = "user Name";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(24, 255);
            lblpassword.Margin = new Padding(6, 0, 6, 0);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(90, 23);
            lblpassword.TabIndex = 2;
            lblpassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(163, 152);
            txtUsername.Margin = new Padding(6, 5, 6, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(193, 30);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(163, 250);
            txtPassword.Margin = new Padding(6, 5, 6, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(193, 30);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(69, 339);
            btnLogin.Margin = new Padding(6, 5, 6, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(118, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnregister
            // 
            btnregister.Location = new Point(225, 334);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(126, 38);
            btnregister.TabIndex = 6;
            btnregister.Text = "Register";
            btnregister.UseVisualStyleBackColor = true;
            btnregister.Click += btnregister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 61);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 7;
            label1.Text = "Login ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(418, -2);
            pictureBox1.Margin = new Padding(5, 5, 5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(445, 596);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 587);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btnregister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblpassword);
            Controls.Add(lbluserName);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
