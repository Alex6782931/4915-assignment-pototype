namespace _4915_assignment_pototype
{
    partial class User_Account
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
            btnAccountClear = new Button();
            btnAccountSearch = new Button();
            btnAccountUpdate = new Button();
            label1 = new Label();
            dataAccounts = new DataGridView();
            txtAccountSearch = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataAccounts).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnAccountClear
            // 
            btnAccountClear.Location = new Point(680, 133);
            btnAccountClear.Name = "btnAccountClear";
            btnAccountClear.Size = new Size(94, 29);
            btnAccountClear.TabIndex = 1;
            btnAccountClear.Text = "Clear";
            btnAccountClear.UseVisualStyleBackColor = true;
            btnAccountClear.Click += btnAccountClear_Click;
            // 
            // btnAccountSearch
            // 
            btnAccountSearch.Location = new Point(580, 133);
            btnAccountSearch.Name = "btnAccountSearch";
            btnAccountSearch.Size = new Size(94, 29);
            btnAccountSearch.TabIndex = 2;
            btnAccountSearch.Text = "Search";
            btnAccountSearch.UseVisualStyleBackColor = true;
            btnAccountSearch.Click += btnAccountSearch_Click;
            // 
            // btnAccountUpdate
            // 
            btnAccountUpdate.Location = new Point(657, 496);
            btnAccountUpdate.Name = "btnAccountUpdate";
            btnAccountUpdate.Size = new Size(94, 29);
            btnAccountUpdate.TabIndex = 3;
            btnAccountUpdate.Text = "Update";
            btnAccountUpdate.UseVisualStyleBackColor = true;
            btnAccountUpdate.Click += btnAccountUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 111);
            label1.Name = "label1";
            label1.Size = new Size(387, 20);
            label1.TabIndex = 4;
            label1.Text = "Search by(username, passwordHash, staffID, accessLevel):";
            // 
            // dataAccounts
            // 
            dataAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAccounts.Location = new Point(56, 168);
            dataAccounts.Name = "dataAccounts";
            dataAccounts.RowHeadersWidth = 51;
            dataAccounts.Size = new Size(718, 309);
            dataAccounts.TabIndex = 5;
            // 
            // txtAccountSearch
            // 
            txtAccountSearch.Location = new Point(56, 135);
            txtAccountSearch.Name = "txtAccountSearch";
            txtAccountSearch.Size = new Size(500, 27);
            txtAccountSearch.TabIndex = 6;
            // 
            // label2
            // 
            label2.Location = new Point(56, 54);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 7;
            label2.Text = "User account database";
            // 
            // User_Account
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 546);
            Controls.Add(label2);
            Controls.Add(txtAccountSearch);
            Controls.Add(dataAccounts);
            Controls.Add(label1);
            Controls.Add(btnAccountUpdate);
            Controls.Add(btnAccountSearch);
            Controls.Add(btnAccountClear);
            Controls.Add(btnBack);
            Name = "User_Account";
            Text = "User_Account";
            Load += User_Account_Load;
            ((System.ComponentModel.ISupportInitialize)dataAccounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnAccountClear;
        private Button btnAccountSearch;
        private Button btnAccountUpdate;
        private Label label1;
        private DataGridView dataAccounts;
        private TextBox txtAccountSearch;
        private Label label2;
    }
}