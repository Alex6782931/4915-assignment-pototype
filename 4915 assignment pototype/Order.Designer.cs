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
            dataOrder = new DataGridView();
            txtbOsearch = new TextBox();
            lblOsearch = new Label();
            btnOsearch = new Button();
            btnOupdate = new Button();
            btnOback = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrder).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 23);
            label1.TabIndex = 0;
            label1.Text = "Order";
            // 
            // dataOrder
            // 
            dataOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrder.Location = new Point(52, 166);
            dataOrder.Margin = new Padding(4, 5, 4, 5);
            dataOrder.Name = "dataOrder";
            dataOrder.RowHeadersWidth = 51;
            dataOrder.Size = new Size(1146, 365);
            dataOrder.TabIndex = 1;
            // 
            // txtbOsearch
            // 
            txtbOsearch.Location = new Point(326, 102);
            txtbOsearch.Margin = new Padding(4, 5, 4, 5);
            txtbOsearch.Name = "txtbOsearch";
            txtbOsearch.Size = new Size(338, 30);
            txtbOsearch.TabIndex = 2;
            // 
            // lblOsearch
            // 
            lblOsearch.AutoSize = true;
            lblOsearch.Location = new Point(194, 114);
            lblOsearch.Margin = new Padding(4, 0, 4, 0);
            lblOsearch.Name = "lblOsearch";
            lblOsearch.Size = new Size(100, 23);
            lblOsearch.TabIndex = 3;
            lblOsearch.Text = "Search for:";
            // 
            // btnOsearch
            // 
            btnOsearch.Location = new Point(701, 101);
            btnOsearch.Margin = new Padding(4, 5, 4, 5);
            btnOsearch.Name = "btnOsearch";
            btnOsearch.Size = new Size(118, 36);
            btnOsearch.TabIndex = 4;
            btnOsearch.Text = "Search";
            btnOsearch.UseVisualStyleBackColor = true;
            // 
            // btnOupdate
            // 
            btnOupdate.Location = new Point(956, 568);
            btnOupdate.Margin = new Padding(4, 5, 4, 5);
            btnOupdate.Name = "btnOupdate";
            btnOupdate.Size = new Size(166, 36);
            btnOupdate.TabIndex = 7;
            btnOupdate.Text = "Update";
            btnOupdate.UseVisualStyleBackColor = true;
            // 
            // btnOback
            // 
            btnOback.Location = new Point(19, 14);
            btnOback.Margin = new Padding(4, 5, 4, 5);
            btnOback.Name = "btnOback";
            btnOback.Size = new Size(95, 43);
            btnOback.TabIndex = 8;
            btnOback.Text = "back";
            btnOback.UseVisualStyleBackColor = true;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnOback);
            Controls.Add(btnOupdate);
            Controls.Add(btnOsearch);
            Controls.Add(lblOsearch);
            Controls.Add(txtbOsearch);
            Controls.Add(dataOrder);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Order";
            Text = "OrderMainPage";
            Load += Order_Load;
            ((System.ComponentModel.ISupportInitialize)dataOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataOrder;
        private TextBox txtbOsearch;
        private Label lblOsearch;
        private Button btnOsearch;
        private Button btnOupdate;
        private Button btnOback;
    }
}