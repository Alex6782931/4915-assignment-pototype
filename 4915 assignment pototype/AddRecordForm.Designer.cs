namespace _4915_assignment_pototype
{
    partial class AddRecordForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtRole = new TextBox();
            txtDept = new TextBox();
            txtEmail = new TextBox();
            btnSubmit = new Button();
            label5 = new Label();
            txtID = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 128);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "Staff's full name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 187);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 1;
            label2.Text = "Staff's role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 248);
            label3.Name = "label3";
            label3.Size = new Size(257, 23);
            label3.TabIndex = 2;
            label3.Text = "Staff's is in what department:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 319);
            label4.Name = "label4";
            label4.Size = new Size(117, 23);
            label4.TabIndex = 3;
            label4.Text = "Staff's email:";
            // 
            // txtName
            // 
            txtName.Location = new Point(362, 128);
            txtName.Name = "txtName";
            txtName.Size = new Size(354, 30);
            txtName.TabIndex = 4;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(362, 184);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(354, 30);
            txtRole.TabIndex = 5;
            txtRole.TextChanged += textBox2_TextChanged;
            // 
            // txtDept
            // 
            txtDept.Location = new Point(362, 248);
            txtDept.Name = "txtDept";
            txtDept.Size = new Size(354, 30);
            txtDept.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(362, 319);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(354, 30);
            txtEmail.TabIndex = 7;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(83, 385);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 31);
            label5.Name = "label5";
            label5.Size = new Size(207, 23);
            label5.TabIndex = 9;
            label5.Text = "Please fill out the form:";
            // 
            // txtID
            // 
            txtID.Location = new Point(362, 75);
            txtID.Name = "txtID";
            txtID.Size = new Size(354, 30);
            txtID.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 75);
            label6.Name = "label6";
            label6.Size = new Size(150, 23);
            label6.TabIndex = 10;
            label6.Text = "Staff's full name:";
            // 
            // AddRecordForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnSubmit);
            Controls.Add(txtEmail);
            Controls.Add(txtDept);
            Controls.Add(txtRole);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddRecordForm";
            Text = "AddRecordForm";
            Load += AddRecordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtRole;
        private TextBox txtDept;
        private TextBox txtEmail;
        private Button btnSubmit;
        private Label label5;
        private TextBox txtID;
        private Label label6;
    }
}