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
            btnCustadjust = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCust).BeginInit();
            SuspendLayout();
            // 
            // btnCustback
            // 
            btnCustback.Location = new Point(13, 16);
            btnCustback.Margin = new Padding(3, 4, 3, 4);
            btnCustback.Name = "btnCustback";
            btnCustback.Size = new Size(48, 37);
            btnCustback.TabIndex = 0;
            btnCustback.Text = "back";
            btnCustback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 29);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 1;
            label1.Text = "Customer";
            // 
            // btnCustsearch
            // 
            btnCustsearch.Location = new Point(448, 131);
            btnCustsearch.Margin = new Padding(3, 4, 3, 4);
            btnCustsearch.Name = "btnCustsearch";
            btnCustsearch.Size = new Size(86, 31);
            btnCustsearch.TabIndex = 2;
            btnCustsearch.Text = "Search";
            btnCustsearch.UseVisualStyleBackColor = true;
            btnCustsearch.Click += btnCustsearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 132);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Search for:";
            // 
            // txtbCustsearch
            // 
            txtbCustsearch.Location = new Point(190, 132);
            txtbCustsearch.Margin = new Padding(3, 4, 3, 4);
            txtbCustsearch.Name = "txtbCustsearch";
            txtbCustsearch.Size = new Size(251, 27);
            txtbCustsearch.TabIndex = 4;
            // 
            // btnCustupdate
            // 
            btnCustupdate.Location = new Point(735, 487);
            btnCustupdate.Margin = new Padding(3, 4, 3, 4);
            btnCustupdate.Name = "btnCustupdate";
            btnCustupdate.Size = new Size(141, 31);
            btnCustupdate.TabIndex = 5;
            btnCustupdate.Text = "Update";
            btnCustupdate.UseVisualStyleBackColor = true;
            btnCustupdate.Click += btnCustupdate_click;
            // 
            // dataCust
            // 
            dataCust.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCust.Location = new Point(41, 193);
            dataCust.Margin = new Padding(3, 4, 3, 4);
            dataCust.Name = "dataCust";
            dataCust.RowHeadersWidth = 51;
            dataCust.Size = new Size(834, 265);
            dataCust.TabIndex = 6;
            // 
            // btnCustadjust
            // 
            btnCustadjust.Location = new Point(610, 487);
            btnCustadjust.Margin = new Padding(3, 4, 3, 4);
            btnCustadjust.Name = "btnCustadjust";
            btnCustadjust.Size = new Size(86, 31);
            btnCustadjust.TabIndex = 7;
            btnCustadjust.Text = "adjust";
            btnCustadjust.UseVisualStyleBackColor = true;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnCustadjust);
            Controls.Add(dataCust);
            Controls.Add(btnCustupdate);
            Controls.Add(txtbCustsearch);
            Controls.Add(label2);
            Controls.Add(btnCustsearch);
            Controls.Add(label1);
            Controls.Add(btnCustback);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnCustadjust;
    }
}