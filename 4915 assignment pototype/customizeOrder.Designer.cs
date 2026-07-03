namespace _4915_assignment_pototype
{
    partial class customizeOrder
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
            label2 = new Label();
            txtbcustomizeSsearch = new TextBox();
            datacustomize = new DataGridView();
            btncustomizesearch = new Button();
            btncustomixeclear = new Button();
            btncustomizedeter = new Button();
            btnreject = new Button();
            ((System.ComponentModel.ISupportInitialize)datacustomize).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(26, 14);
            btnBack.Margin = new Padding(4, 5, 4, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(78, 43);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(230, 23);
            label1.TabIndex = 3;
            label1.Text = "customize order database";
            // 
            // label2
            // 
            label2.Location = new Point(91, 135);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(297, 23);
            label2.TabIndex = 4;
            label2.Text = "Search by(customer ID):";
            // 
            // txtbcustomizeSsearch
            // 
            txtbcustomizeSsearch.Location = new Point(311, 135);
            txtbcustomizeSsearch.Margin = new Padding(4, 5, 4, 5);
            txtbcustomizeSsearch.Name = "txtbcustomizeSsearch";
            txtbcustomizeSsearch.Size = new Size(576, 30);
            txtbcustomizeSsearch.TabIndex = 5;
            // 
            // datacustomize
            // 
            datacustomize.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datacustomize.Location = new Point(91, 186);
            datacustomize.Margin = new Padding(4, 5, 4, 5);
            datacustomize.Name = "datacustomize";
            datacustomize.RowHeadersWidth = 51;
            datacustomize.Size = new Size(1092, 330);
            datacustomize.TabIndex = 6;
            // 
            // btncustomizesearch
            // 
            btncustomizesearch.Location = new Point(912, 135);
            btncustomizesearch.Margin = new Padding(4, 5, 4, 5);
            btncustomizesearch.Name = "btncustomizesearch";
            btncustomizesearch.Size = new Size(120, 31);
            btncustomizesearch.TabIndex = 7;
            btncustomizesearch.Text = "Search";
            btncustomizesearch.UseVisualStyleBackColor = true;
            // 
            // btncustomixeclear
            // 
            btncustomixeclear.Location = new Point(1051, 134);
            btncustomixeclear.Margin = new Padding(4, 3, 4, 3);
            btncustomixeclear.Name = "btncustomixeclear";
            btncustomixeclear.Size = new Size(120, 30);
            btncustomixeclear.TabIndex = 8;
            btncustomixeclear.Text = "Clear";
            btncustomixeclear.UseVisualStyleBackColor = true;
            // 
            // btncustomizedeter
            // 
            btncustomizedeter.Location = new Point(1022, 553);
            btncustomizedeter.Margin = new Padding(4, 5, 4, 5);
            btncustomizedeter.Name = "btncustomizedeter";
            btncustomizedeter.Size = new Size(212, 36);
            btncustomizedeter.TabIndex = 9;
            btncustomizedeter.Text = "determine";
            btncustomizedeter.UseVisualStyleBackColor = true;
            btncustomizedeter.Click += btncustomizedeter_Click;
            // 
            // btnreject
            // 
            btnreject.Location = new Point(842, 555);
            btnreject.Name = "btnreject";
            btnreject.Size = new Size(112, 34);
            btnreject.TabIndex = 10;
            btnreject.Text = "reject";
            btnreject.UseVisualStyleBackColor = true;
            btnreject.Click += btnreject_Click;
            // 
            // customizeOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 619);
            Controls.Add(btnreject);
            Controls.Add(btncustomizedeter);
            Controls.Add(btncustomixeclear);
            Controls.Add(btncustomizesearch);
            Controls.Add(datacustomize);
            Controls.Add(txtbcustomizeSsearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Name = "customizeOrder";
            Text = "customizeOrder";
            Load += customizeOrder_Load_1;
            ((System.ComponentModel.ISupportInitialize)datacustomize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label1;
        private Label label2;
        private TextBox txtbcustomizeSsearch;
        private DataGridView datacustomize;
        private Button btncustomizesearch;
        private Button btncustomixeclear;
        private Button btncustomizedeter;
        private Button btnreject;
    }
}