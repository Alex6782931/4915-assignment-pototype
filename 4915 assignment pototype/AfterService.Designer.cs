namespace _4915_assignment_pototype
{
    partial class AfterService
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
            btnASback = new Button();
            label2 = new Label();
            txtbASsearch = new TextBox();
            btnASsearch = new Button();
            dataAS = new DataGridView();
            btnASupdate = new Button();
            btnASclear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataAS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 28);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 0;
            label1.Text = "After sale service";
            // 
            // btnASback
            // 
            btnASback.Location = new Point(15, 19);
            btnASback.Margin = new Padding(3, 4, 3, 4);
            btnASback.Name = "btnASback";
            btnASback.Size = new Size(57, 37);
            btnASback.TabIndex = 1;
            btnASback.Text = "back";
            btnASback.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Location = new Point(55, 135);
            label2.Name = "label2";
            label2.Size = new Size(216, 20);
            label2.TabIndex = 2;
            label2.Text = "Search by(order number):";
            // 
            // txtbASsearch
            // 
            txtbASsearch.Location = new Point(234, 131);
            txtbASsearch.Margin = new Padding(3, 4, 3, 4);
            txtbASsearch.Name = "txtbASsearch";
            txtbASsearch.Size = new Size(420, 27);
            txtbASsearch.TabIndex = 3;
            // 
            // btnASsearch
            // 
            btnASsearch.Location = new Point(660, 132);
            btnASsearch.Margin = new Padding(3, 4, 3, 4);
            btnASsearch.Name = "btnASsearch";
            btnASsearch.Size = new Size(87, 27);
            btnASsearch.TabIndex = 4;
            btnASsearch.Text = "Search";
            btnASsearch.UseVisualStyleBackColor = true;
            btnASsearch.Click += btnASsearch_Click;
            // 
            // dataAS
            // 
            dataAS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAS.Location = new Point(55, 188);
            dataAS.Margin = new Padding(3, 4, 3, 4);
            dataAS.Name = "dataAS";
            dataAS.RowHeadersWidth = 51;
            dataAS.Size = new Size(794, 287);
            dataAS.TabIndex = 5;
            // 
            // btnASupdate
            // 
            btnASupdate.Location = new Point(695, 507);
            btnASupdate.Margin = new Padding(3, 4, 3, 4);
            btnASupdate.Name = "btnASupdate";
            btnASupdate.Size = new Size(154, 31);
            btnASupdate.TabIndex = 6;
            btnASupdate.Text = "Update";
            btnASupdate.UseVisualStyleBackColor = true;
            btnASupdate.Click += btnASupdate_click;
            // 
            // btnASclear
            // 
            btnASclear.Location = new Point(762, 132);
            btnASclear.Name = "btnASclear";
            btnASclear.Size = new Size(87, 26);
            btnASclear.TabIndex = 7;
            btnASclear.Text = "Clear";
            btnASclear.UseVisualStyleBackColor = true;
            btnASclear.Click += btnASclear_Click;
            // 
            // AfterService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnASclear);
            Controls.Add(btnASupdate);
            Controls.Add(dataAS);
            Controls.Add(btnASsearch);
            Controls.Add(txtbASsearch);
            Controls.Add(label2);
            Controls.Add(btnASback);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AfterService";
            Text = "AfterService";
            Load += AfterService_Load;
            ((System.ComponentModel.ISupportInitialize)dataAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnASback;
        private Label label2;
        private TextBox txtbASsearch;
        private Button btnASsearch;
        private DataGridView dataAS;
        private Button btnASupdate;
        private Button btnASclear;
    }
}