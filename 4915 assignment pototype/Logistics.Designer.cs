namespace _4915_assignment_pototype
{
    partial class Logistics
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
            dataLog = new DataGridView();
            label1 = new Label();
            btnLogUpdate = new Button();
            label2 = new Label();
            txtLogSearch = new TextBox();
            btnLogSearch = new Button();
            btnLogClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataLog).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(18, 12);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(50, 38);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataLog
            // 
            dataLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataLog.Location = new Point(39, 121);
            dataLog.Margin = new Padding(4, 3, 4, 3);
            dataLog.Name = "dataLog";
            dataLog.RowHeadersWidth = 62;
            dataLog.Size = new Size(712, 256);
            dataLog.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 60);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 2;
            label1.Text = "Logistics database";
            // 
            // btnLogUpdate
            // 
            btnLogUpdate.Location = new Point(622, 396);
            btnLogUpdate.Margin = new Padding(4, 3, 4, 3);
            btnLogUpdate.Name = "btnLogUpdate";
            btnLogUpdate.Size = new Size(75, 22);
            btnLogUpdate.TabIndex = 3;
            btnLogUpdate.Text = "Update";
            btnLogUpdate.UseVisualStyleBackColor = true;
            btnLogUpdate.Click += btnLogUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 98);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 15);
            label2.TabIndex = 5;
            label2.Text = "Search by(delivery note ID):";
            // 
            // txtLogSearch
            // 
            txtLogSearch.Location = new Point(211, 96);
            txtLogSearch.Margin = new Padding(4, 3, 4, 3);
            txtLogSearch.Name = "txtLogSearch";
            txtLogSearch.Size = new Size(359, 23);
            txtLogSearch.TabIndex = 6;
            // 
            // btnLogSearch
            // 
            btnLogSearch.Location = new Point(577, 95);
            btnLogSearch.Margin = new Padding(4, 3, 4, 3);
            btnLogSearch.Name = "btnLogSearch";
            btnLogSearch.Size = new Size(75, 22);
            btnLogSearch.TabIndex = 7;
            btnLogSearch.Text = "Search";
            btnLogSearch.UseVisualStyleBackColor = true;
            btnLogSearch.Click += btnLogSearch_Click;
            // 
            // btnLogClear
            // 
            btnLogClear.Location = new Point(669, 95);
            btnLogClear.Margin = new Padding(3, 2, 3, 2);
            btnLogClear.Name = "btnLogClear";
            btnLogClear.Size = new Size(82, 22);
            btnLogClear.TabIndex = 8;
            btnLogClear.Text = "Clear";
            btnLogClear.UseVisualStyleBackColor = true;
            btnLogClear.Click += btnLogClear_Click;
            // 
            // Logistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogClear);
            Controls.Add(btnLogSearch);
            Controls.Add(txtLogSearch);
            Controls.Add(label2);
            Controls.Add(btnLogUpdate);
            Controls.Add(label1);
            Controls.Add(dataLog);
            Controls.Add(btnBack);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Logistics";
            Text = "Logistics";
            Load += Logistics_Load;
            ((System.ComponentModel.ISupportInitialize)dataLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private DataGridView dataLog;
        private Label label1;
        private Button btnLogUpdate;
        private Label label2;
        private TextBox txtLogSearch;
        private Button btnLogSearch;
        private Button btnLogClear;
    }
}