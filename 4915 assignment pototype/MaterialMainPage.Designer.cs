namespace _4915_assignment_pototype
{
    partial class MaterialMainPage
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
            lblM = new Label();
            btnMback = new Button();
            dataMaterial = new DataGridView();
            btnMsearch = new Button();
            txtbMseacrh = new TextBox();
            label1 = new Label();
            btnMcreate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataMaterial).BeginInit();
            SuspendLayout();
            // 
            // lblM
            // 
            lblM.AutoSize = true;
            lblM.Location = new Point(97, 23);
            lblM.Name = "lblM";
            lblM.Size = new Size(50, 15);
            lblM.TabIndex = 0;
            lblM.Text = "Material";
            // 
            // btnMback
            // 
            btnMback.Location = new Point(28, 12);
            btnMback.Name = "btnMback";
            btnMback.Size = new Size(56, 36);
            btnMback.TabIndex = 1;
            btnMback.Text = "back";
            btnMback.UseVisualStyleBackColor = true;
            // 
            // dataMaterial
            // 
            dataMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataMaterial.Location = new Point(97, 127);
            dataMaterial.Name = "dataMaterial";
            dataMaterial.Size = new Size(585, 216);
            dataMaterial.TabIndex = 2;
            // 
            // btnMsearch
            // 
            btnMsearch.Location = new Point(371, 91);
            btnMsearch.Name = "btnMsearch";
            btnMsearch.Size = new Size(75, 23);
            btnMsearch.TabIndex = 3;
            btnMsearch.Text = "Search";
            btnMsearch.UseVisualStyleBackColor = true;
            // 
            // txtbMseacrh
            // 
            txtbMseacrh.Location = new Point(166, 88);
            txtbMseacrh.Name = "txtbMseacrh";
            txtbMseacrh.Size = new Size(165, 23);
            txtbMseacrh.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 91);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 5;
            label1.Text = "Search for:";
            // 
            // btnMcreate
            // 
            btnMcreate.Location = new Point(597, 358);
            btnMcreate.Name = "btnMcreate";
            btnMcreate.Size = new Size(75, 23);
            btnMcreate.TabIndex = 6;
            btnMcreate.Text = "Create request";
            btnMcreate.UseVisualStyleBackColor = true;
            // 
            // MaterialMainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMcreate);
            Controls.Add(label1);
            Controls.Add(txtbMseacrh);
            Controls.Add(btnMsearch);
            Controls.Add(dataMaterial);
            Controls.Add(btnMback);
            Controls.Add(lblM);
            Name = "MaterialMainPage";
            Text = "MaterialMainPage";
            ((System.ComponentModel.ISupportInitialize)dataMaterial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblM;
        private Button btnMback;
        private DataGridView dataMaterial;
        private Button btnMsearch;
        private TextBox txtbMseacrh;
        private Label label1;
        private Button btnMcreate;
    }
}