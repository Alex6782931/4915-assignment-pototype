namespace _4915_assignment_pototype
{
    partial class CustomizeRequired
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
            btncrback = new Button();
            label1 = new Label();
            label2 = new Label();
            txtbcustomizeSsearch = new TextBox();
            datacr = new DataGridView();
            label3 = new Label();
            btncrsearch = new Button();
            btncrclear = new Button();
            ((System.ComponentModel.ISupportInitialize)datacr).BeginInit();
            SuspendLayout();
            // 
            // btncrback
            // 
            btncrback.Location = new Point(32, 20);
            btncrback.Name = "btncrback";
            btncrback.Size = new Size(112, 34);
            btncrback.TabIndex = 0;
            btncrback.Text = "back";
            btncrback.UseVisualStyleBackColor = true;
            btncrback.Click += btncrback_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 74);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 23);
            label1.TabIndex = 4;
            label1.Text = "customize require production database";
            // 
            // label2
            // 
            label2.Location = new Point(-223, 152);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(10, 10);
            label2.TabIndex = 9;
            label2.Text = "Search by(customer ID):";
            // 
            // txtbcustomizeSsearch
            // 
            txtbcustomizeSsearch.Location = new Point(254, 132);
            txtbcustomizeSsearch.Margin = new Padding(4, 5, 4, 5);
            txtbcustomizeSsearch.Name = "txtbcustomizeSsearch";
            txtbcustomizeSsearch.Size = new Size(378, 30);
            txtbcustomizeSsearch.TabIndex = 10;
            // 
            // datacr
            // 
            datacr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datacr.Location = new Point(26, 187);
            datacr.Margin = new Padding(4, 5, 4, 5);
            datacr.Name = "datacr";
            datacr.RowHeadersWidth = 51;
            datacr.Size = new Size(1063, 338);
            datacr.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 135);
            label3.Name = "label3";
            label3.Size = new Size(201, 23);
            label3.TabIndex = 12;
            label3.Text = "search by customizeID";
            // 
            // btncrsearch
            // 
            btncrsearch.Location = new Point(680, 135);
            btncrsearch.Name = "btncrsearch";
            btncrsearch.Size = new Size(112, 34);
            btncrsearch.TabIndex = 13;
            btncrsearch.Text = "search";
            btncrsearch.UseVisualStyleBackColor = true;
            btncrsearch.Click += btncrsearch_Click;
            // 
            // btncrclear
            // 
            btncrclear.Location = new Point(819, 135);
            btncrclear.Name = "btncrclear";
            btncrclear.Size = new Size(112, 34);
            btncrclear.TabIndex = 14;
            btncrclear.Text = "clear";
            btncrclear.UseVisualStyleBackColor = true;
            btncrclear.Click += btncrclear_Click;
            // 
            // CustomizeRequired
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 572);
            Controls.Add(btncrclear);
            Controls.Add(btncrsearch);
            Controls.Add(label3);
            Controls.Add(datacr);
            Controls.Add(txtbcustomizeSsearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btncrback);
            Name = "CustomizeRequired";
            Text = "CustomizeRequired";
            Load += CustomizeRequired_Load_1;
            ((System.ComponentModel.ISupportInitialize)datacr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btncrback;
        private Label label1;
        private Label label2;
        private TextBox txtbcustomizeSsearch;
        private DataGridView datacr;
        private Label label3;
        private Button btncrsearch;
        private Button btncrclear;
    }
}