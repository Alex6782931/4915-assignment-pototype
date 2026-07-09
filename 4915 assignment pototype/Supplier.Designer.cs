namespace _4915_assignment_pototype
{
    partial class Supplier
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
            btnBack = new Button();
            btnSupplierSearch = new Button();
            btnSupplierClear = new Button();
            btnSupplierUpdate = new Button();
            dataSuppliers = new DataGridView();
            label1 = new Label();
            txtSupplierSearch = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataSuppliers).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(10, 9);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(82, 22);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSupplierSearch
            // 
            btnSupplierSearch.Location = new Point(540, 78);
            btnSupplierSearch.Margin = new Padding(3, 2, 3, 2);
            btnSupplierSearch.Name = "btnSupplierSearch";
            btnSupplierSearch.Size = new Size(82, 22);
            btnSupplierSearch.TabIndex = 1;
            btnSupplierSearch.Text = "Search";
            btnSupplierSearch.UseVisualStyleBackColor = true;
            btnSupplierSearch.Click += btnSupplierSearch_Click;
            // 
            // btnSupplierClear
            // 
            btnSupplierClear.Location = new Point(627, 76);
            btnSupplierClear.Margin = new Padding(3, 2, 3, 2);
            btnSupplierClear.Name = "btnSupplierClear";
            btnSupplierClear.Size = new Size(82, 22);
            btnSupplierClear.TabIndex = 2;
            btnSupplierClear.Text = "Clear";
            btnSupplierClear.UseVisualStyleBackColor = true;
            btnSupplierClear.Click += btnSupplierClear_Click;
            // 
            // btnSupplierUpdate
            // 
            btnSupplierUpdate.Location = new Point(572, 323);
            btnSupplierUpdate.Margin = new Padding(3, 2, 3, 2);
            btnSupplierUpdate.Name = "btnSupplierUpdate";
            btnSupplierUpdate.Size = new Size(82, 22);
            btnSupplierUpdate.TabIndex = 3;
            btnSupplierUpdate.Text = "Update";
            btnSupplierUpdate.UseVisualStyleBackColor = true;
            btnSupplierUpdate.Click += btnSupplierUpdate_Click;
            // 
            // dataSuppliers
            // 
            dataSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSuppliers.Location = new Point(29, 108);
            dataSuppliers.Margin = new Padding(3, 2, 3, 2);
            dataSuppliers.Name = "dataSuppliers";
            dataSuppliers.RowHeadersWidth = 51;
            dataSuppliers.Size = new Size(681, 202);
            dataSuppliers.TabIndex = 4;
            // 
            // label1
            // 
            label1.Location = new Point(40, 80);
            label1.Name = "label1";
            label1.Size = new Size(162, 19);
            label1.TabIndex = 5;
            label1.Text = "Search by(supplier name):";
            // 
            // txtSupplierSearch
            // 
            txtSupplierSearch.Location = new Point(200, 78);
            txtSupplierSearch.Margin = new Padding(3, 2, 3, 2);
            txtSupplierSearch.Name = "txtSupplierSearch";
            txtSupplierSearch.Size = new Size(322, 23);
            txtSupplierSearch.TabIndex = 6;
            // 
            // label2
            // 
            label2.Location = new Point(40, 40);
            label2.Name = "label2";
            label2.Size = new Size(129, 19);
            label2.TabIndex = 7;
            label2.Text = "Supplier database";
            // 
            // Supplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 370);
            Controls.Add(label2);
            Controls.Add(txtSupplierSearch);
            Controls.Add(label1);
            Controls.Add(dataSuppliers);
            Controls.Add(btnSupplierUpdate);
            Controls.Add(btnSupplierClear);
            Controls.Add(btnSupplierSearch);
            Controls.Add(btnBack);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Supplier";
            Text = "Supplier";
            Load += Supplier_Load;
            ((System.ComponentModel.ISupportInitialize)dataSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnSupplierSearch;
        private Button btnSupplierClear;
        private Button btnSupplierUpdate;
        private DataGridView dataSuppliers;
        private Label label1;
        private TextBox txtSupplierSearch;
        private Label label2;
    }
}