namespace _4915_assignment_pototype
{
    partial class Register
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
            btnRback = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnRregister = new Button();
            txtbRusername = new TextBox();
            txtbRpasswd = new TextBox();
            txtbRconfipasswd = new TextBox();
            SuspendLayout();
            // 
            // btnRback
            // 
            btnRback.Location = new Point(23, 28);
            btnRback.Name = "btnRback";
            btnRback.Size = new Size(99, 31);
            btnRback.TabIndex = 0;
            btnRback.Text = "back";
            btnRback.UseVisualStyleBackColor = true;
            btnRback.Click += btnRback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 30);
            label1.Name = "label1";
            label1.Size = new Size(129, 23);
            label1.TabIndex = 1;
            label1.Text = "Register Form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(143, 117);
            label2.Name = "label2";
            label2.Size = new Size(105, 23);
            label2.TabIndex = 2;
            label2.Text = "User Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 187);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 253);
            label4.Name = "label4";
            label4.Size = new Size(164, 23);
            label4.TabIndex = 4;
            label4.Text = "Confirm Password";
            // 
            // btnRregister
            // 
            btnRregister.Location = new Point(491, 336);
            btnRregister.Name = "btnRregister";
            btnRregister.Size = new Size(126, 36);
            btnRregister.TabIndex = 5;
            btnRregister.Text = "Register";
            btnRregister.UseVisualStyleBackColor = true;
            btnRregister.Click += btnRregister_Click;
            // 
            // txtbRusername
            // 
            txtbRusername.Location = new Point(262, 117);
            txtbRusername.Name = "txtbRusername";
            txtbRusername.Size = new Size(289, 30);
            txtbRusername.TabIndex = 6;
            // 
            // txtbRpasswd
            // 
            txtbRpasswd.Location = new Point(262, 180);
            txtbRpasswd.Name = "txtbRpasswd";
            txtbRpasswd.Size = new Size(289, 30);
            txtbRpasswd.TabIndex = 7;
            // 
            // txtbRconfipasswd
            // 
            txtbRconfipasswd.Location = new Point(262, 250);
            txtbRconfipasswd.Name = "txtbRconfipasswd";
            txtbRconfipasswd.Size = new Size(289, 30);
            txtbRconfipasswd.TabIndex = 8;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtbRconfipasswd);
            Controls.Add(txtbRpasswd);
            Controls.Add(txtbRusername);
            Controls.Add(btnRregister);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRback);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRback;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnRregister;
        private TextBox txtbRusername;
        private TextBox txtbRpasswd;
        private TextBox txtbRconfipasswd;
    }
}