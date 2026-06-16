namespace _4915_assignment_pototype
{
    partial class Material
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
            btnMupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataMaterial).BeginInit();
            SuspendLayout();
            // 
            // lblM
            // 
            lblM.AutoSize = true;
            lblM.Location = new Point(152, 35);
            lblM.Margin = new Padding(5, 0, 5, 0);
            lblM.Name = "lblM";
            lblM.Size = new Size(81, 23);
            lblM.TabIndex = 0;
            lblM.Text = "Material";
            // 
            // btnMback
            // 
            btnMback.Location = new Point(44, 18);
            btnMback.Margin = new Padding(5, 5, 5, 5);
            btnMback.Name = "btnMback";
            btnMback.Size = new Size(88, 55);
            btnMback.TabIndex = 1;
            btnMback.Text = "back";
            btnMback.UseVisualStyleBackColor = true;
            // 
            // dataMaterial
            // 
            dataMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataMaterial.Location = new Point(33, 195);
            dataMaterial.Margin = new Padding(5, 5, 5, 5);
            dataMaterial.Name = "dataMaterial";
            dataMaterial.RowHeadersWidth = 62;
            dataMaterial.Size = new Size(1164, 331);
            dataMaterial.TabIndex = 2;
            // 
            // btnMsearch
            // 
            btnMsearch.Location = new Point(583, 140);
            btnMsearch.Margin = new Padding(5, 5, 5, 5);
            btnMsearch.Name = "btnMsearch";
            btnMsearch.Size = new Size(118, 35);
            btnMsearch.TabIndex = 3;
            btnMsearch.Text = "Search";
            btnMsearch.UseVisualStyleBackColor = true;
            // 
            // txtbMseacrh
            // 
            txtbMseacrh.Location = new Point(261, 135);
            txtbMseacrh.Margin = new Padding(5, 5, 5, 5);
            txtbMseacrh.Name = "txtbMseacrh";
            txtbMseacrh.Size = new Size(257, 30);
            txtbMseacrh.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 140);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            label1.Text = "Search for:";
            // 
            // btnMupdate
            // 
            btnMupdate.Location = new Point(1079, 557);
            btnMupdate.Margin = new Padding(5, 5, 5, 5);
            btnMupdate.Name = "btnMupdate";
            btnMupdate.Size = new Size(118, 35);
            btnMupdate.TabIndex = 6;
            btnMupdate.Text = "Update";
            btnMupdate.UseVisualStyleBackColor = true;
            // 
            // Material
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnMupdate);
            Controls.Add(label1);
            Controls.Add(txtbMseacrh);
            Controls.Add(btnMsearch);
            Controls.Add(dataMaterial);
            Controls.Add(btnMback);
            Controls.Add(lblM);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Material";
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
        private Button btnMupdate;
    }
}