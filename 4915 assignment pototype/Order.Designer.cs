namespace _4915_assignment_pototype
{
    partial class Order
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
            dataOrders = new DataGridView();
            txtOrderSearch = new TextBox();
            lblOsearch = new Label();
            btnOrderSearch = new Button();
            btnBack = new Button();
            btnOrderClear = new Button();
            btnOrderUpdateClick = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrders).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 53);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Order database";
            // 
            // dataOrders
            // 
            dataOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrders.Location = new Point(38, 144);
            dataOrders.Margin = new Padding(3, 4, 3, 4);
            dataOrders.Name = "dataOrders";
            dataOrders.RowHeadersWidth = 51;
            dataOrders.Size = new Size(833, 317);
            dataOrders.TabIndex = 1;
            // 
            // txtOrderSearch
            // 
            txtOrderSearch.Location = new Point(221, 96);
            txtOrderSearch.Margin = new Padding(3, 4, 3, 4);
            txtOrderSearch.Name = "txtOrderSearch";
            txtOrderSearch.Size = new Size(458, 27);
            txtOrderSearch.TabIndex = 2;
            // 
            // lblOsearch
            // 
            lblOsearch.AutoSize = true;
            lblOsearch.Location = new Point(38, 99);
            lblOsearch.Name = "lblOsearch";
            lblOsearch.Size = new Size(177, 20);
            lblOsearch.TabIndex = 3;
            lblOsearch.Text = "Search by(order number):";
            // 
            // btnOrderSearch
            // 
            btnOrderSearch.Location = new Point(685, 95);
            btnOrderSearch.Margin = new Padding(3, 4, 3, 4);
            btnOrderSearch.Name = "btnOrderSearch";
            btnOrderSearch.Size = new Size(86, 31);
            btnOrderSearch.TabIndex = 4;
            btnOrderSearch.Text = "Search";
            btnOrderSearch.UseVisualStyleBackColor = true;
            btnOrderSearch.Click += btnOrderSearch_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(14, 12);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(69, 37);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnOrderClear
            // 
            btnOrderClear.Location = new Point(777, 95);
            btnOrderClear.Name = "btnOrderClear";
            btnOrderClear.Size = new Size(94, 29);
            btnOrderClear.TabIndex = 9;
            btnOrderClear.Text = "Clear";
            btnOrderClear.UseVisualStyleBackColor = true;
            btnOrderClear.Click += btnOrderClear_Click;
            // 
            // btnOrderUpdateClick
            // 
            btnOrderUpdateClick.Location = new Point(747, 481);
            btnOrderUpdateClick.Name = "btnOrderUpdateClick";
            btnOrderUpdateClick.Size = new Size(94, 29);
            btnOrderUpdateClick.TabIndex = 10;
            btnOrderUpdateClick.Text = "Update";
            btnOrderUpdateClick.UseVisualStyleBackColor = true;
            btnOrderUpdateClick.Click += btnOrderUpdate_Click;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnOrderUpdateClick);
            Controls.Add(btnOrderClear);
            Controls.Add(btnBack);
            Controls.Add(btnOrderSearch);
            Controls.Add(lblOsearch);
            Controls.Add(txtOrderSearch);
            Controls.Add(dataOrders);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Order";
            Text = "OrderMainPage";
            Load += order_Load;
            ((System.ComponentModel.ISupportInitialize)dataOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataOrders;
        private TextBox txtOrderSearch;
        private Label lblOsearch;
        private Button btnOrderSearch;
        private Button btnBack;
        private Button btnOrderClear;
        private Button btnOrderUpdateClick;
    }
}