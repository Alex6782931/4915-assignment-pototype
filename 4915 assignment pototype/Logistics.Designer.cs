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
            btnBack.Location = new Point(20, 16);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(57, 50);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataLog
            // 
            dataLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataLog.Location = new Point(45, 162);
            dataLog.Margin = new Padding(4);
            dataLog.Name = "dataLog";
            dataLog.RowHeadersWidth = 62;
            dataLog.Size = new Size(814, 341);
            dataLog.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 80);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 2;
            label1.Text = "Logistics database";
            // 
            // btnLogUpdate
            // 
            btnLogUpdate.Location = new Point(711, 528);
            btnLogUpdate.Margin = new Padding(4);
            btnLogUpdate.Name = "btnLogUpdate";
            btnLogUpdate.Size = new Size(86, 30);
            btnLogUpdate.TabIndex = 3;
            btnLogUpdate.Text = "Update";
            btnLogUpdate.UseVisualStyleBackColor = true;
            btnLogUpdate.Click += btnLogUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 131);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 5;
            label2.Text = "Search by(delivery note ID):";
            // 
            // txtLogSearch
            // 
            txtLogSearch.Location = new Point(241, 128);
            txtLogSearch.Margin = new Padding(4);
            txtLogSearch.Name = "txtLogSearch";
            txtLogSearch.Size = new Size(410, 27);
            txtLogSearch.TabIndex = 6;
            // 
            // btnLogSearch
            // 
            btnLogSearch.Location = new Point(659, 126);
            btnLogSearch.Margin = new Padding(4);
            btnLogSearch.Name = "btnLogSearch";
            btnLogSearch.Size = new Size(86, 30);
            btnLogSearch.TabIndex = 7;
            btnLogSearch.Text = "Search";
            btnLogSearch.UseVisualStyleBackColor = true;
            btnLogSearch.Click += btnLogSearch_Click;
            // 
            // btnLogClear
            // 
            btnLogClear.Location = new Point(765, 127);
            btnLogClear.Name = "btnLogClear";
            btnLogClear.Size = new Size(94, 29);
            btnLogClear.TabIndex = 8;
            btnLogClear.Text = "Clear";
            btnLogClear.UseVisualStyleBackColor = true;
            btnLogClear.Click += btnLogClear_Click;
            // 
            // Logistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnLogClear);
            Controls.Add(btnLogSearch);
            Controls.Add(txtLogSearch);
            Controls.Add(label2);
            Controls.Add(btnLogUpdate);
            Controls.Add(label1);
            Controls.Add(dataLog);
            Controls.Add(btnBack);
            Margin = new Padding(4);
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