namespace _4915_assignment_pototype
{
    partial class AddSupplierForm
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
            label5 = new Label();
            btnSubmitSupplier = new Button();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtContact = new TextBox();
            txtSupplierName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 31);
            label5.Name = "label5";
            label5.Size = new Size(207, 23);
            label5.TabIndex = 21;
            label5.Text = "Please fill out the form:";
            // 
            // btnSubmitSupplier
            // 
            btnSubmitSupplier.Location = new Point(95, 385);
            btnSubmitSupplier.Name = "btnSubmitSupplier";
            btnSubmitSupplier.Size = new Size(112, 34);
            btnSubmitSupplier.TabIndex = 20;
            btnSubmitSupplier.Text = "Submit";
            btnSubmitSupplier.UseVisualStyleBackColor = true;
            btnSubmitSupplier.Click += btnSubmitSupplier_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(374, 319);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(354, 30);
            txtAddress.TabIndex = 19;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(374, 248);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(354, 30);
            txtPhone.TabIndex = 18;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(374, 184);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(354, 30);
            txtContact.TabIndex = 17;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(374, 128);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(354, 30);
            txtSupplierName.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 319);
            label4.Name = "label4";
            label4.Size = new Size(166, 23);
            label4.TabIndex = 15;
            label4.Text = "Supplier's address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 248);
            label3.Name = "label3";
            label3.Size = new Size(227, 23);
            label3.TabIndex = 14;
            label3.Text = "Supplier's phone number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 187);
            label2.Name = "label2";
            label2.Size = new Size(218, 23);
            label2.TabIndex = 13;
            label2.Text = "Supplier's contact name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 128);
            label1.Name = "label1";
            label1.Size = new Size(149, 23);
            label1.TabIndex = 12;
            label1.Text = "Supplier's name:";
            // 
            // AddSupplierForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnSubmitSupplier);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtContact);
            Controls.Add(txtSupplierName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddSupplierForm";
            Text = "AddSupplierForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Button btnSubmitSupplier;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtContact;
        private TextBox txtSupplierName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}