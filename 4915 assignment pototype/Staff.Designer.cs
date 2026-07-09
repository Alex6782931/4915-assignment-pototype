namespace _4915_assignment_pototype
{
    partial class Staff
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
            label1 = new Label();
            btnStaffSearch = new Button();
            btnStaffUpdate = new Button();
            label2 = new Label();
            txtStaffSearch = new TextBox();
            dataStaff = new DataGridView();
            btnStaffClear = new Button();
            btnAddStaff = new Button();
            ((System.ComponentModel.ISupportInitialize)dataStaff).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(19, 18);
            btnBack.Margin = new Padding(6, 5, 6, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(107, 49);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 89);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 1;
            label1.Text = "Staff database";
            // 
            // btnStaffSearch
            // 
            btnStaffSearch.Location = new Point(906, 161);
            btnStaffSearch.Margin = new Padding(6, 5, 6, 5);
            btnStaffSearch.Name = "btnStaffSearch";
            btnStaffSearch.Size = new Size(118, 34);
            btnStaffSearch.TabIndex = 2;
            btnStaffSearch.Text = "Search";
            btnStaffSearch.UseVisualStyleBackColor = true;
            btnStaffSearch.Click += btnStaffSearch_Click;
            // 
            // btnStaffUpdate
            // 
            btnStaffUpdate.Location = new Point(1045, 608);
            btnStaffUpdate.Margin = new Padding(6, 5, 6, 5);
            btnStaffUpdate.Name = "btnStaffUpdate";
            btnStaffUpdate.Size = new Size(118, 34);
            btnStaffUpdate.TabIndex = 4;
            btnStaffUpdate.Text = "Update";
            btnStaffUpdate.UseVisualStyleBackColor = true;
            btnStaffUpdate.Click += btnStaffUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 167);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(271, 23);
            label2.TabIndex = 5;
            label2.Text = "Search by(staff full name only):";
            // 
            // txtStaffSearch
            // 
            txtStaffSearch.Location = new Point(359, 163);
            txtStaffSearch.Margin = new Padding(6, 5, 6, 5);
            txtStaffSearch.Name = "txtStaffSearch";
            txtStaffSearch.Size = new Size(511, 30);
            txtStaffSearch.TabIndex = 6;
            // 
            // dataStaff
            // 
            dataStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataStaff.Location = new Point(55, 205);
            dataStaff.Margin = new Padding(6, 5, 6, 5);
            dataStaff.Name = "dataStaff";
            dataStaff.RowHeadersWidth = 62;
            dataStaff.Size = new Size(1108, 394);
            dataStaff.TabIndex = 7;
            // 
            // btnStaffClear
            // 
            btnStaffClear.Location = new Point(1034, 161);
            btnStaffClear.Margin = new Padding(4, 3, 4, 3);
            btnStaffClear.Name = "btnStaffClear";
            btnStaffClear.Size = new Size(129, 33);
            btnStaffClear.TabIndex = 8;
            btnStaffClear.Text = "Clear";
            btnStaffClear.UseVisualStyleBackColor = true;
            btnStaffClear.Click += btnStaffClear_Click;
            // 
            // btnAddStaff
            // 
            btnAddStaff.Location = new Point(1045, 83);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.Size = new Size(112, 34);
            btnAddStaff.TabIndex = 9;
            btnAddStaff.Text = "Add staff";
            btnAddStaff.UseVisualStyleBackColor = true;
            btnAddStaff.Click += btnAddStaff_Click;
            // 
            // Staff
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnAddStaff);
            Controls.Add(btnStaffClear);
            Controls.Add(dataStaff);
            Controls.Add(txtStaffSearch);
            Controls.Add(label2);
            Controls.Add(btnStaffUpdate);
            Controls.Add(btnStaffSearch);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Staff";
            Text = "Staff";
            Load += Staff_Load;
            ((System.ComponentModel.ISupportInitialize)dataStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label1;
        private Button btnStaffSearch;
        private Button btnStaffcd;
        private Button btnStaffUpdate;
        private Label label2;
        private TextBox txtStaffSearch;
        private DataGridView dataStaff;
        private Button btnStaffClear;
        private Button btnAddStaff;
    }
}