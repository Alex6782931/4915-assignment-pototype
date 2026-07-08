namespace _4915_assignment_pototype
{
    partial class FurnitureProductionRequired1
    {
        private System.Windows.Forms.ComboBox cmbMaterials;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblQty;

        private void InitializeComponent()
        {
            cmbMaterials = new ComboBox();
            numQty = new NumericUpDown();
            btnSubmit = new Button();
            lblMaterial = new Label();
            lblQty = new Label();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            SuspendLayout();
            // 
            // cmbMaterials
            // 
            cmbMaterials.Location = new Point(150, 30);
            cmbMaterials.Name = "cmbMaterials";
            cmbMaterials.Size = new Size(121, 31);
            cmbMaterials.TabIndex = 1;
            // 
            // numQty
            // 
            numQty.Location = new Point(150, 70);
            numQty.Name = "numQty";
            this.numQty.Maximum = 999999;
            numQty.Size = new Size(120, 30);
            numQty.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(150, 120);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(84, 32);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit Request";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblMaterial
            // 
            lblMaterial.Location = new Point(-4, 33);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(148, 23);
            lblMaterial.TabIndex = 0;
            lblMaterial.Text = "Select Furniture Item:";
            // 
            // lblQty
            // 
            lblQty.Location = new Point(30, 70);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(100, 23);
            lblQty.TabIndex = 2;
            lblQty.Text = "Quantity:";
            // 
            // FurnitureProductionRequired1
            // 
            ClientSize = new Size(366, 287);
            Controls.Add(lblMaterial);
            Controls.Add(cmbMaterials);
            Controls.Add(lblQty);
            Controls.Add(numQty);
            Controls.Add(btnSubmit);
            Name = "FurnitureProductionRequired1";
            Text = "Production Request";
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ResumeLayout(false);
        }
    }
}