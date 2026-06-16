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
            btnPback = new Button();
            label1 = new Label();
            dataProc = new DataGridView();
            label2 = new Label();
            txtProcSearch = new TextBox();
            btnProcSearch = new Button();
            btnProcUpdate = new Button();
            btnProcClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProc).BeginInit();
            SuspendLayout();
            // 
            // btnPback
            // 
            btnPback.Location = new Point(10, 10);
            btnPback.Margin = new Padding(4);
            btnPback.Name = "btnPback";
            btnPback.Size = new Size(62, 44);
            btnPback.TabIndex = 0;
            btnPback.Text = "back";
            btnPback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 1;
            label1.Text = "Procurement";
            // 
            // dataProc
            // 
            dataProc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProc.Location = new Point(40, 170);
            dataProc.Margin = new Padding(4);
            dataProc.Name = "dataProc";
            dataProc.RowHeadersWidth = 62;
            dataProc.Size = new Size(830, 294);
            dataProc.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 137);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
            label2.TabIndex = 3;
            label2.Text = "Search by(raw material ID):";
            // 
            // txtProcSearch
            // 
            txtProcSearch.Location = new Point(236, 132);
            txtProcSearch.Margin = new Padding(4);
            txtProcSearch.Name = "txtProcSearch";
            txtProcSearch.Size = new Size(427, 27);
            txtProcSearch.TabIndex = 4;
            // 
            // btnProcSearch
            // 
            btnProcSearch.Location = new Point(671, 130);
            btnProcSearch.Margin = new Padding(4);
            btnProcSearch.Name = "btnProcSearch";
            btnProcSearch.Size = new Size(98, 30);
            btnProcSearch.TabIndex = 5;
            btnProcSearch.Text = "Search";
            btnProcSearch.UseVisualStyleBackColor = true;
            btnProcSearch.Click += btnProcSearch_Click;
            // 
            // btnProcUpdate
            // 
            btnProcUpdate.Location = new Point(679, 481);
            btnProcUpdate.Margin = new Padding(4);
            btnProcUpdate.Name = "btnProcUpdate";
            btnProcUpdate.Size = new Size(145, 30);
            btnProcUpdate.TabIndex = 6;
            btnProcUpdate.Text = "Update";
            btnProcUpdate.UseVisualStyleBackColor = true;
            btnProcUpdate.Click += btnProcUpdate_Click;
            // 
            // btnProcClear
            // 
            btnProcClear.Location = new Point(776, 130);
            btnProcClear.Name = "btnProcClear";
            btnProcClear.Size = new Size(94, 29);
            btnProcClear.TabIndex = 7;
            btnProcClear.Text = "Clear";
            btnProcClear.UseVisualStyleBackColor = true;
            btnProcClear.Click += btnProcClear_Click;
            // 
            // Procurement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnProcClear);
            Controls.Add(btnProcUpdate);
            Controls.Add(btnProcSearch);
            Controls.Add(txtProcSearch);
            Controls.Add(label2);
            Controls.Add(dataProc);
            Controls.Add(label1);
            Controls.Add(btnPback);
            Margin = new Padding(4);
            Name = "Procurement";
            Text = "Procurement";
            Load += Procurement_Load;
            ((System.ComponentModel.ISupportInitialize)dataProc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPback;
        private Label label1;
        private DataGridView dataProc;
        private Label label2;
        private TextBox txtProcSearch;
        private Button btnProcSearch;
        private Button btnProcUpdate;
        private Button btnProcClear;
    }
}