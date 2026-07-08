namespace _4915_assignment_pototype
{
    partial class customizehistort
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
            btnCClear = new Button();
            btnCSearch = new Button();
            txtsearch = new TextBox();
            label2 = new Label();
            btnaccept = new Button();
            label1 = new Label();
            dataCustomizeC = new DataGridView();
            btnBack = new Button();
            btnedit = new Button();
            btnreject = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCustomizeC).BeginInit();
            SuspendLayout();
            // 
            // btnCClear
            // 
            btnCClear.Location = new Point(1025, 114);
            btnCClear.Margin = new Padding(4, 3, 4, 3);
            btnCClear.Name = "btnCClear";
            btnCClear.Size = new Size(129, 33);
            btnCClear.TabIndex = 16;
            btnCClear.Text = "Clear";
            btnCClear.UseVisualStyleBackColor = true;
            btnCClear.Click += btnReset_Click;
            // 
            // btnCSearch
            // 
            btnCSearch.Location = new Point(879, 113);
            btnCSearch.Margin = new Padding(6, 5, 6, 5);
            btnCSearch.Name = "btnCSearch";
            btnCSearch.Size = new Size(118, 34);
            btnCSearch.TabIndex = 15;
            btnCSearch.Text = "Search";
            btnCSearch.UseVisualStyleBackColor = true;
            btnCSearch.Click += btnCSearch_Click_1;
            // 
            // txtsearch
            // 
            txtsearch.Location = new Point(304, 115);
            txtsearch.Margin = new Padding(6, 5, 6, 5);
            txtsearch.Name = "txtsearch";
            txtsearch.Size = new Size(562, 30);
            txtsearch.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 119);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(200, 23);
            label2.TabIndex = 13;
            label2.Text = "Search by(type,status):";
            // 
            // btnaccept
            // 
            btnaccept.Location = new Point(951, 575);
            btnaccept.Margin = new Padding(6, 5, 6, 5);
            btnaccept.Name = "btnaccept";
            btnaccept.Size = new Size(118, 34);
            btnaccept.TabIndex = 12;
            btnaccept.Text = "accept";
            btnaccept.UseVisualStyleBackColor = true;
            btnaccept.Click += btnaccept_Click;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 60);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 23);
            label1.TabIndex = 11;
            label1.Text = "customize history";
            // 
            // dataCustomizeC
            // 
            dataCustomizeC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCustomizeC.Location = new Point(35, 154);
            dataCustomizeC.Margin = new Padding(6, 5, 6, 5);
            dataCustomizeC.Name = "dataCustomizeC";
            dataCustomizeC.RowHeadersWidth = 62;
            dataCustomizeC.Size = new Size(1119, 392);
            dataCustomizeC.TabIndex = 10;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(3, 4);
            btnBack.Margin = new Padding(6, 5, 6, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(76, 40);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(803, 575);
            btnedit.Margin = new Padding(6, 5, 6, 5);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(118, 34);
            btnedit.TabIndex = 17;
            btnedit.Text = "edit";
            btnedit.UseVisualStyleBackColor = true; 
            btnedit.Click += btnedit_Click;
            // 
            // btnreject
            // 
            btnreject.Location = new Point(659, 575);
            btnreject.Margin = new Padding(6, 5, 6, 5);
            btnreject.Name = "btnreject";
            btnreject.Size = new Size(118, 34);
            btnreject.TabIndex = 18;
            btnreject.Text = "reject";
            btnreject.UseVisualStyleBackColor = true;
            btnreject.Click += btnreject_Click;
            // 
            // customizehistort
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 639);
            Controls.Add(btnreject);
            Controls.Add(btnedit);
            Controls.Add(btnCClear);
            Controls.Add(btnCSearch);
            Controls.Add(txtsearch);
            Controls.Add(label2);
            Controls.Add(btnaccept);
            Controls.Add(label1);
            Controls.Add(dataCustomizeC);
            Controls.Add(btnBack);
            Name = "customizehistort";
            Text = "customizehistort";
            Load += customizehistort_Load;
            ((System.ComponentModel.ISupportInitialize)dataCustomizeC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCClear;
        private Button btnCSearch;
        private TextBox txtsearch;
        private Label label2;
        private Button btnaccept;
        private Label label1;
        private DataGridView dataCustomizeC;
        private Button btnBack;
        private Button btnedit;
        private Button btnreject;
    }
}