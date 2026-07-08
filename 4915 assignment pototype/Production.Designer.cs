namespace _4915_assignment_pototype
{
    partial class Production
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
            dataProd = new DataGridView();
            txtProdSearch = new TextBox();
            label2 = new Label();
            btnProdSearch = new Button();
            btnProdUpdate = new Button();
            btnProdClear = new Button();
            btnpdone = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProd).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(18, 15);
            btnBack.Margin = new Padding(6, 5, 6, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(98, 52);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 71);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(305, 23);
            label1.TabIndex = 1;
            label1.Text = "Production Management database";
            // 
            // dataProd
            // 
            dataProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProd.Location = new Point(76, 169);
            dataProd.Margin = new Padding(6, 5, 6, 5);
            dataProd.Name = "dataProd";
            dataProd.RowHeadersWidth = 62;
            dataProd.Size = new Size(1119, 415);
            dataProd.TabIndex = 2;
            // 
            // txtProdSearch
            // 
            txtProdSearch.Location = new Point(333, 123);
            txtProdSearch.Margin = new Padding(6, 5, 6, 5);
            txtProdSearch.Name = "txtProdSearch";
            txtProdSearch.Size = new Size(544, 30);
            txtProdSearch.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 130);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(228, 23);
            label2.TabIndex = 4;
            label2.Text = "Search by(target item ID):";
            // 
            // btnProdSearch
            // 
            btnProdSearch.Location = new Point(905, 120);
            btnProdSearch.Margin = new Padding(6, 5, 6, 5);
            btnProdSearch.Name = "btnProdSearch";
            btnProdSearch.Size = new Size(124, 34);
            btnProdSearch.TabIndex = 5;
            btnProdSearch.Text = "Search";
            btnProdSearch.UseVisualStyleBackColor = true;
            btnProdSearch.Click += btnProdSearch_Click;
            // 
            // btnProdUpdate
            // 
            btnProdUpdate.Location = new Point(1042, 606);
            btnProdUpdate.Margin = new Padding(6, 5, 6, 5);
            btnProdUpdate.Name = "btnProdUpdate";
            btnProdUpdate.Size = new Size(118, 34);
            btnProdUpdate.TabIndex = 6;
            btnProdUpdate.Text = "Update";
            btnProdUpdate.UseVisualStyleBackColor = true;
            btnProdUpdate.Click += btnProdUpdate_Click;
            // 
            // btnProdClear
            // 
            btnProdClear.Location = new Point(1066, 120);
            btnProdClear.Margin = new Padding(4, 3, 4, 3);
            btnProdClear.Name = "btnProdClear";
            btnProdClear.Size = new Size(129, 33);
            btnProdClear.TabIndex = 7;
            btnProdClear.Text = "Clear";
            btnProdClear.UseVisualStyleBackColor = true;
            btnProdClear.Click += btnProdClear_Click;
            // 
            // btnpdone
            // 
            btnpdone.Location = new Point(917, 606);
            btnpdone.Name = "btnpdone";
            btnpdone.Size = new Size(112, 34);
            btnpdone.TabIndex = 8;
            btnpdone.Text = "deliveryed";
            btnpdone.UseVisualStyleBackColor = true;
            btnpdone.Click += btnpdone_Click;
            // 
            // Production
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnpdone);
            Controls.Add(btnProdClear);
            Controls.Add(btnProdUpdate);
            Controls.Add(btnProdSearch);
            Controls.Add(label2);
            Controls.Add(txtProdSearch);
            Controls.Add(dataProd);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Production";
            Text = "Production";
            Load += Production_Load;
            ((System.ComponentModel.ISupportInitialize)dataProd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label1;
        private DataGridView dataProd;
        private TextBox txtProdSearch;
        private Label label2;
        private Button btnProdSearch;
        private Button btnProdUpdate;
        private Button btnProdClear;
        private Button btnpdone;
    }
}