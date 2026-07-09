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
            btnCancelOrder = new Button();
            btndelivery = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrders).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 61);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(142, 23);
            label1.TabIndex = 0;
            label1.Text = "Order database";
            // 
            // dataOrders
            // 
            dataOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrders.Location = new Point(52, 166);
            dataOrders.Margin = new Padding(4, 5, 4, 5);
            dataOrders.Name = "dataOrders";
            dataOrders.RowHeadersWidth = 51;
            dataOrders.Size = new Size(1145, 365);
            dataOrders.TabIndex = 1;
            // 
            // txtOrderSearch
            // 
            txtOrderSearch.Location = new Point(304, 110);
            txtOrderSearch.Margin = new Padding(4, 5, 4, 5);
            txtOrderSearch.Name = "txtOrderSearch";
            txtOrderSearch.Size = new Size(628, 30);
            txtOrderSearch.TabIndex = 2;
            // 
            // lblOsearch
            // 
            lblOsearch.AutoSize = true;
            lblOsearch.Location = new Point(52, 114);
            lblOsearch.Margin = new Padding(4, 0, 4, 0);
            lblOsearch.Name = "lblOsearch";
            lblOsearch.Size = new Size(226, 23);
            lblOsearch.TabIndex = 3;
            lblOsearch.Text = "Search by(order number):";
            // 
            // btnOrderSearch
            // 
            btnOrderSearch.Location = new Point(942, 109);
            btnOrderSearch.Margin = new Padding(4, 5, 4, 5);
            btnOrderSearch.Name = "btnOrderSearch";
            btnOrderSearch.Size = new Size(118, 36);
            btnOrderSearch.TabIndex = 4;
            btnOrderSearch.Text = "Search";
            btnOrderSearch.UseVisualStyleBackColor = true;
            btnOrderSearch.Click += btnOrderSearch_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(19, 14);
            btnBack.Margin = new Padding(4, 5, 4, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 43);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnOrderClear
            // 
            btnOrderClear.Location = new Point(1068, 109);
            btnOrderClear.Margin = new Padding(4, 3, 4, 3);
            btnOrderClear.Name = "btnOrderClear";
            btnOrderClear.Size = new Size(129, 33);
            btnOrderClear.TabIndex = 9;
            btnOrderClear.Text = "Clear";
            btnOrderClear.UseVisualStyleBackColor = true;
            btnOrderClear.Click += btnOrderClear_Click;
            // 
            // btnOrderUpdateClick
            // 
            btnOrderUpdateClick.Location = new Point(1027, 553);
            btnOrderUpdateClick.Margin = new Padding(4, 3, 4, 3);
            btnOrderUpdateClick.Name = "btnOrderUpdateClick";
            btnOrderUpdateClick.Size = new Size(129, 33);
            btnOrderUpdateClick.TabIndex = 10;
            btnOrderUpdateClick.Text = "Update";
            btnOrderUpdateClick.UseVisualStyleBackColor = true;
            btnOrderUpdateClick.Click += btnOrderUpdate_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Location = new Point(77, 553);
            btnCancelOrder.Margin = new Padding(4, 3, 4, 3);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(129, 33);
            btnCancelOrder.TabIndex = 11;
            btnCancelOrder.Text = "Cancel";
            btnCancelOrder.UseVisualStyleBackColor = true;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btndelivery
            // 
            btndelivery.Location = new Point(877, 552);
            btndelivery.Name = "btndelivery";
            btndelivery.Size = new Size(112, 34);
            btndelivery.TabIndex = 12;
            btndelivery.Text = "delivery";
            btndelivery.UseVisualStyleBackColor = true;
            btndelivery.Click += btndelivery_Click;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btndelivery);
            Controls.Add(btnCancelOrder);
            Controls.Add(btnOrderUpdateClick);
            Controls.Add(btnOrderClear);
            Controls.Add(btnBack);
            Controls.Add(btnOrderSearch);
            Controls.Add(lblOsearch);
            Controls.Add(txtOrderSearch);
            Controls.Add(dataOrders);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
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
        private Button btnCancelOrder;
        private Button btndelivery;
    }
}