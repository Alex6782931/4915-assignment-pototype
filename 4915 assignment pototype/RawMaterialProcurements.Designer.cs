namespace _4915_assignment_pototype
{
    partial class RawMaterialProcurements
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
            lblMaterial = new Label();
            cmbSuppliers = new ComboBox();
            lblQty = new Label();
            numQty = new NumericUpDown();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            SuspendLayout();
            // 
            // lblMaterial
            // 
            lblMaterial.Location = new Point(6, 37);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(146, 23);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "Select supplier";
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.Location = new Point(158, 34);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(279, 31);
            cmbSuppliers.TabIndex = 6;
            // 
            // lblQty
            // 
            lblQty.Location = new Point(38, 74);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(100, 23);
            lblQty.TabIndex = 7;
            lblQty.Text = "Quantity:";
            // 
            // numQty
            // 
            numQty.Location = new Point(158, 74);
            numQty.Name = "numQty";
            this.numQty.Maximum = 999999;
            this.numQty.Maximum = decimal.MaxValue;
            numQty.Size = new Size(120, 30);
            numQty.TabIndex = 8;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(158, 124);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(84, 32);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Submit Request";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // RawMaterialProcurements
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 288);
            Controls.Add(lblMaterial);
            Controls.Add(cmbSuppliers);
            Controls.Add(lblQty);
            Controls.Add(numQty);
            Controls.Add(btnSubmit);
            Name = "RawMaterialProcurements";
            Text = "RawMaterialProcurements";
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMaterial;
        private ComboBox cmbSuppliers;
        private Label lblQty;
        private NumericUpDown numQty;
        private Button btnSubmit;
    }
}