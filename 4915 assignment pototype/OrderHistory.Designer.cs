namespace _4915_assignment_pototype
{
    partial class OrderHistory
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
            label1 = new Label();
            btnOHback = new Button();
            label2 = new Label();
            txtbOHsearch = new TextBox();
            btnOHsearch = new Button();
            dataOH = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataOH).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 25);
            label1.Name = "label1";
            label1.Size = new Size(126, 23);
            label1.TabIndex = 0;
            label1.Text = "Order History";
            // 
            // btnOHback
            // 
            btnOHback.Location = new Point(19, 19);
            btnOHback.Name = "btnOHback";
            btnOHback.Size = new Size(87, 29);
            btnOHback.TabIndex = 1;
            btnOHback.Text = "back";
            btnOHback.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 111);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 2;
            label2.Text = "search";
            // 
            // txtbOHsearch
            // 
            txtbOHsearch.Location = new Point(122, 105);
            txtbOHsearch.Name = "txtbOHsearch";
            txtbOHsearch.Size = new Size(290, 30);
            txtbOHsearch.TabIndex = 3;
            // 
            // btnOHsearch
            // 
            btnOHsearch.Location = new Point(429, 105);
            btnOHsearch.Name = "btnOHsearch";
            btnOHsearch.Size = new Size(132, 31);
            btnOHsearch.TabIndex = 4;
            btnOHsearch.Text = "button2";
            btnOHsearch.UseVisualStyleBackColor = true;
            // 
            // dataOH
            // 
            dataOH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOH.Location = new Point(18, 160);
            dataOH.Name = "dataOH";
            dataOH.RowHeadersWidth = 62;
            dataOH.Size = new Size(750, 175);
            dataOH.TabIndex = 5;
            // 
            // OrderHistory
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataOH);
            Controls.Add(btnOHsearch);
            Controls.Add(txtbOHsearch);
            Controls.Add(label2);
            Controls.Add(btnOHback);
            Controls.Add(label1);
            Name = "OrderHistory";
            Text = "OrderHistory";
            ((System.ComponentModel.ISupportInitialize)dataOH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnOHback;
        private Label label2;
        private TextBox txtbOHsearch;
        private Button btnOHsearch;
        private DataGridView dataOH;
    }
}