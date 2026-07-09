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
            btnAddSupplier = new Button();
            ((System.ComponentModel.ISupportInitialize)dataSuppliers).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(16, 14);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(129, 33);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSupplierSearch
            // 
            btnSupplierSearch.Location = new Point(848, 120);
            btnSupplierSearch.Margin = new Padding(4, 3, 4, 3);
            btnSupplierSearch.Name = "btnSupplierSearch";
            btnSupplierSearch.Size = new Size(129, 33);
            btnSupplierSearch.TabIndex = 1;
            btnSupplierSearch.Text = "Search";
            btnSupplierSearch.UseVisualStyleBackColor = true;
            btnSupplierSearch.Click += btnSupplierSearch_Click;
            // 
            // btnSupplierClear
            // 
            btnSupplierClear.Location = new Point(986, 117);
            btnSupplierClear.Margin = new Padding(4, 3, 4, 3);
            btnSupplierClear.Name = "btnSupplierClear";
            btnSupplierClear.Size = new Size(129, 33);
            btnSupplierClear.TabIndex = 2;
            btnSupplierClear.Text = "Clear";
            btnSupplierClear.UseVisualStyleBackColor = true;
            btnSupplierClear.Click += btnSupplierClear_Click;
            // 
            // btnSupplierUpdate
            // 
            btnSupplierUpdate.Location = new Point(899, 496);
            btnSupplierUpdate.Margin = new Padding(4, 3, 4, 3);
            btnSupplierUpdate.Name = "btnSupplierUpdate";
            btnSupplierUpdate.Size = new Size(129, 33);
            btnSupplierUpdate.TabIndex = 3;
            btnSupplierUpdate.Text = "Update";
            btnSupplierUpdate.UseVisualStyleBackColor = true;
            btnSupplierUpdate.Click += btnSupplierUpdate_Click;
            // 
            // dataSuppliers
            // 
            dataSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSuppliers.Location = new Point(45, 166);
            dataSuppliers.Margin = new Padding(4, 3, 4, 3);
            dataSuppliers.Name = "dataSuppliers";
            dataSuppliers.RowHeadersWidth = 51;
            dataSuppliers.Size = new Size(1070, 310);
            dataSuppliers.TabIndex = 4;
            // 
            // label1
            // 
            label1.Location = new Point(63, 123);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(254, 29);
            label1.TabIndex = 5;
            label1.Text = "Search by(supplier name):";
            // 
            // txtSupplierSearch
            // 
            txtSupplierSearch.Location = new Point(315, 120);
            txtSupplierSearch.Margin = new Padding(4, 3, 4, 3);
            txtSupplierSearch.Name = "txtSupplierSearch";
            txtSupplierSearch.Size = new Size(504, 30);
            txtSupplierSearch.TabIndex = 6;
            // 
            // label2
            // 
            label2.Location = new Point(63, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(202, 29);
            label2.TabIndex = 7;
            label2.Text = "Supplier database";
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(986, 56);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(112, 34);
            btnAddSupplier.TabIndex = 8;
            btnAddSupplier.Text = "Add";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // Supplier
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 568);
            Controls.Add(btnAddSupplier);
            Controls.Add(label2);
            Controls.Add(txtSupplierSearch);
            Controls.Add(label1);
            Controls.Add(dataSuppliers);
            Controls.Add(btnSupplierUpdate);
            Controls.Add(btnSupplierClear);
            Controls.Add(btnSupplierSearch);
            Controls.Add(btnBack);
            Margin = new Padding(4, 3, 4, 3);
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
        private Button btnAddSupplier;
    }
}