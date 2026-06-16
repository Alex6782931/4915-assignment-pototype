namespace _4915_assignment_pototype
{
    partial class Customer
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
            btnCustback = new Button();
            label1 = new Label();
            btnCustsearch = new Button();
            label2 = new Label();
            txtbCustsearch = new TextBox();
            btnCustupdate = new Button();
            dataCust = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataCust).BeginInit();
            SuspendLayout();
            // 
            // btnCustback
            // 
            btnCustback.Location = new Point(18, 18);
            btnCustback.Margin = new Padding(4, 5, 4, 5);
            btnCustback.Name = "btnCustback";
            btnCustback.Size = new Size(66, 43);
            btnCustback.TabIndex = 0;
            btnCustback.Text = "back";
            btnCustback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 1;
            label1.Text = "Customer";
            // 
            // btnCustsearch
            // 
            btnCustsearch.Location = new Point(616, 151);
            btnCustsearch.Margin = new Padding(4, 5, 4, 5);
            btnCustsearch.Name = "btnCustsearch";
            btnCustsearch.Size = new Size(118, 36);
            btnCustsearch.TabIndex = 2;
            btnCustsearch.Text = "Search";
            btnCustsearch.UseVisualStyleBackColor = true;
            btnCustsearch.Click += btnCustsearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(153, 152);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Search for:";
            // 
            // txtbCustsearch
            // 
            txtbCustsearch.Location = new Point(261, 152);
            txtbCustsearch.Margin = new Padding(4, 5, 4, 5);
            txtbCustsearch.Name = "txtbCustsearch";
            txtbCustsearch.Size = new Size(344, 30);
            txtbCustsearch.TabIndex = 4;
            // 
            // btnCustupdate
            // 
            btnCustupdate.Location = new Point(1011, 560);
            btnCustupdate.Margin = new Padding(4, 5, 4, 5);
            btnCustupdate.Name = "btnCustupdate";
            btnCustupdate.Size = new Size(194, 36);
            btnCustupdate.TabIndex = 5;
            btnCustupdate.Text = "Update";
            btnCustupdate.UseVisualStyleBackColor = true;
            btnCustupdate.Click += btnCustupdate_click;
            // 
            // dataCust
            // 
            dataCust.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCust.Location = new Point(56, 222);
            dataCust.Margin = new Padding(4, 5, 4, 5);
            dataCust.Name = "dataCust";
            dataCust.RowHeadersWidth = 51;
            dataCust.Size = new Size(1147, 305);
            dataCust.TabIndex = 6;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(dataCust);
            Controls.Add(btnCustupdate);
            Controls.Add(txtbCustsearch);
            Controls.Add(label2);
            Controls.Add(btnCustsearch);
            Controls.Add(label1);
            Controls.Add(btnCustback);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Customer";
            Text = "Customer";
            Load += Customer_Load;
            ((System.ComponentModel.ISupportInitialize)dataCust).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCustback;
        private Label label1;
        private Button btnCustsearch;
        private Label label2;
        private TextBox txtbCustsearch;
        private Button btnCustupdate;
        private DataGridView dataCust;
    }
}