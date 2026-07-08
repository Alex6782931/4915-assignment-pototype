namespace _4915_assignment_pototype
{
    partial class Customize
    {
        private System.ComponentModel.IContainer components = null;

        // UI Element Declarations
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblDesktopMaterial;
        private System.Windows.Forms.ComboBox cmbDesktopMaterial;
        private System.Windows.Forms.Label lblLegMaterial;
        private System.Windows.Forms.ComboBox cmbLegMaterial;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblType = new Label();
            txtType = new TextBox();
            lblSize = new Label();
            txtSize = new TextBox();
            lblColor = new Label();
            txtColor = new TextBox();
            lblDesktopMaterial = new Label();
            cmbDesktopMaterial = new ComboBox();
            lblLegMaterial = new Label();
            cmbLegMaterial = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblType
            // 
            lblType.Location = new Point(26, 30);
            lblType.Name = "lblType";
            lblType.Size = new Size(105, 25);
            lblType.TabIndex = 0;
            lblType.Text = "Furniture Type:";
            // 
            // txtType
            // 
            txtType.Location = new Point(158, 30);
            txtType.Name = "txtType";
            txtType.Size = new Size(176, 23);
            txtType.TabIndex = 1;
            // 
            // lblSize
            // 
            lblSize.Location = new Point(26, 70);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(105, 25);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size (Dimensions):";
            // 
            // txtSize
            // 
            txtSize.Location = new Point(158, 70);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(176, 23);
            txtSize.TabIndex = 3;
            // 
            // lblColor
            // 
            lblColor.Location = new Point(26, 110);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(105, 25);
            lblColor.TabIndex = 4;
            lblColor.Text = "Color:";
            // 
            // cmbColor
            // 
            // txtColor
            txtColor.Location = new Point(158, 110);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(176, 23);
            txtColor.TabIndex = 5;

            // 
            // lblDesktopMaterial
            // 
            lblDesktopMaterial.Location = new Point(26, 150);
            lblDesktopMaterial.Name = "lblDesktopMaterial";
            lblDesktopMaterial.Size = new Size(122, 25);
            lblDesktopMaterial.TabIndex = 6;
            lblDesktopMaterial.Text = "Desktop Material:";
            // 
            // cmbDesktopMaterial
            // 
            cmbDesktopMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDesktopMaterial.Location = new Point(158, 150);
            cmbDesktopMaterial.Name = "cmbDesktopMaterial";
            cmbDesktopMaterial.Size = new Size(176, 23);
            cmbDesktopMaterial.TabIndex = 7;
            // 
            // lblLegMaterial
            // 
            lblLegMaterial.Location = new Point(26, 190);
            lblLegMaterial.Name = "lblLegMaterial";
            lblLegMaterial.Size = new Size(105, 25);
            lblLegMaterial.TabIndex = 8;
            lblLegMaterial.Text = "Leg Material:";
            // 
            // cmbLegMaterial
            // 
            cmbLegMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLegMaterial.Location = new Point(158, 190);
            cmbLegMaterial.Name = "cmbLegMaterial";
            cmbLegMaterial.Size = new Size(176, 23);
            cmbLegMaterial.TabIndex = 9;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(26, 230);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(105, 25);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(158, 230);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(307, 80);
            txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(158, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save Configuration";
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(269, 330);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(91, 35);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Customize
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 400);
            Controls.Add(btnBack);
            Controls.Add(lblType);
            Controls.Add(txtType);
            Controls.Add(lblSize);
            Controls.Add(txtSize);
            Controls.Add(lblColor);
            this.Controls.Add(txtColor);
            Controls.Add(lblDesktopMaterial);
            Controls.Add(cmbDesktopMaterial);
            Controls.Add(lblLegMaterial);
            Controls.Add(cmbLegMaterial);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Name = "Customize";
            Text = "Customize Furniture";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
    }
}
