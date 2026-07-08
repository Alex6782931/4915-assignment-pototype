namespace _4915_assignment_pototype
{
    partial class Procurement
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
            dataProc = new DataGridView();
            label2 = new Label();
            txtProcSearch = new TextBox();
            btnProcSearch = new Button();
            btnProcUpdate = new Button();
            btnProcClear = new Button();
            btnprdone = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProc).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(14, 12);
            btnBack.Margin = new Padding(6, 5, 6, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 51);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 77);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(203, 23);
            label1.TabIndex = 1;
            label1.Text = "Procurement database";
            // 
            // dataProc
            // 
            dataProc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProc.Location = new Point(55, 196);
            dataProc.Margin = new Padding(6, 5, 6, 5);
            dataProc.Name = "dataProc";
            dataProc.RowHeadersWidth = 62;
            dataProc.Size = new Size(1141, 338);
            dataProc.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 158);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(239, 23);
            label2.TabIndex = 3;
            label2.Text = "Search by(raw material ID):";
            // 
            // txtProcSearch
            // 
            txtProcSearch.Location = new Point(324, 152);
            txtProcSearch.Margin = new Padding(6, 5, 6, 5);
            txtProcSearch.Name = "txtProcSearch";
            txtProcSearch.Size = new Size(586, 30);
            txtProcSearch.TabIndex = 4;
            // 
            // btnProcSearch
            // 
            btnProcSearch.Location = new Point(923, 150);
            btnProcSearch.Margin = new Padding(6, 5, 6, 5);
            btnProcSearch.Name = "btnProcSearch";
            btnProcSearch.Size = new Size(135, 34);
            btnProcSearch.TabIndex = 5;
            btnProcSearch.Text = "Search";
            btnProcSearch.UseVisualStyleBackColor = true;
            btnProcSearch.Click += btnProcSearch_Click;
            // 
            // btnProcUpdate
            // 
            btnProcUpdate.Location = new Point(934, 553);
            btnProcUpdate.Margin = new Padding(6, 5, 6, 5);
            btnProcUpdate.Name = "btnProcUpdate";
            btnProcUpdate.Size = new Size(199, 34);
            btnProcUpdate.TabIndex = 6;
            btnProcUpdate.Text = "Update";
            btnProcUpdate.UseVisualStyleBackColor = true;
            btnProcUpdate.Click += btnProcUpdate_Click;
            // 
            // btnProcClear
            // 
            btnProcClear.Location = new Point(1067, 150);
            btnProcClear.Margin = new Padding(4, 3, 4, 3);
            btnProcClear.Name = "btnProcClear";
            btnProcClear.Size = new Size(129, 33);
            btnProcClear.TabIndex = 7;
            btnProcClear.Text = "Clear";
            btnProcClear.UseVisualStyleBackColor = true;
            btnProcClear.Click += btnProcClear_Click;
            // 
            // btnprdone
            // 
            btnprdone.Location = new Point(798, 553);
            btnprdone.Name = "btnprdone";
            btnprdone.Size = new Size(112, 34);
            btnprdone.TabIndex = 8;
            btnprdone.Text = "deliveryed";
            btnprdone.UseVisualStyleBackColor = true;
            btnprdone.Click += btnprdone_Click;
            // 
            // Procurement
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnprdone);
            Controls.Add(btnProcClear);
            Controls.Add(btnProcUpdate);
            Controls.Add(btnProcSearch);
            Controls.Add(txtProcSearch);
            Controls.Add(label2);
            Controls.Add(dataProc);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Procurement";
            Text = "Procurement";
            Load += Procurement_Load;
            ((System.ComponentModel.ISupportInitialize)dataProc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label1;
        private DataGridView dataProc;
        private Label label2;
        private TextBox txtProcSearch;
        private Button btnProcSearch;
        private Button btnProcUpdate;
        private Button btnProcClear;
        private Button btnprdone;
    }
}