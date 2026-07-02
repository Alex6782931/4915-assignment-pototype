namespace _4915_assignment_pototype
{
    partial class changepassword
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
            btnback = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            oldpass = new TextBox();
            newpass = new TextBox();
            confirmpass = new TextBox();
            btnsubmit = new Button();
            SuspendLayout();
            // 
            // btnback
            // 
            btnback.Location = new Point(38, 26);
            btnback.Name = "btnback";
            btnback.Size = new Size(112, 34);
            btnback.TabIndex = 0;
            btnback.Text = "back";
            btnback.UseVisualStyleBackColor = true;
            btnback.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 97);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 1;
            label1.Text = "password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 150);
            label2.Name = "label2";
            label2.Size = new Size(130, 23);
            label2.TabIndex = 2;
            label2.Text = "new password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(140, 199);
            label3.Name = "label3";
            label3.Size = new Size(164, 23);
            label3.TabIndex = 3;
            label3.Text = "confiem password";
            // 
            // oldpass
            // 
            oldpass.Location = new Point(376, 78);
            oldpass.Name = "oldpass";
            oldpass.Size = new Size(150, 30);
            oldpass.TabIndex = 4;
            // 
            // newpass
            // 
            newpass.Location = new Point(376, 143);
            newpass.Name = "newpass";
            newpass.Size = new Size(150, 30);
            newpass.TabIndex = 5;
            // 
            // confirmpass
            // 
            confirmpass.Location = new Point(376, 196);
            confirmpass.Name = "confirmpass";
            confirmpass.Size = new Size(150, 30);
            confirmpass.TabIndex = 6;
            // 
            // btnsubmit
            // 
            btnsubmit.Location = new Point(607, 276);
            btnsubmit.Name = "btnsubmit";
            btnsubmit.Size = new Size(112, 34);
            btnsubmit.TabIndex = 7;
            btnsubmit.Text = "submit";
            btnsubmit.UseVisualStyleBackColor = true;
            btnsubmit.Click += btnsubmit_Click;
            // 
            // changepassword
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnsubmit);
            Controls.Add(confirmpass);
            Controls.Add(newpass);
            Controls.Add(oldpass);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnback);
            Name = "changepassword";
            Text = "changepassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnback;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox oldpass;
        private TextBox newpass;
        private TextBox confirmpass;
        private Button btnsubmit;
    }
}