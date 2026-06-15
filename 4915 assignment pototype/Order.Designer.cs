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
            btnOview = new Button();
            btnOdelete = new Button();
            btnOupdate = new Button();
            btnOback = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrder).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 29);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 0;
            label1.Text = "Order";
            // 
            // dataOrder
            // 
            dataOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrder.Location = new Point(81, 144);
            dataOrder.Margin = new Padding(3, 4, 3, 4);
            dataOrder.Name = "dataOrder";
            dataOrder.RowHeadersWidth = 51;
            dataOrder.Size = new Size(735, 317);
            dataOrder.TabIndex = 1;
            // 
            // txtbOsearch
            // 
            txtbOsearch.Location = new Point(237, 89);
            txtbOsearch.Margin = new Padding(3, 4, 3, 4);
            txtbOsearch.Name = "txtbOsearch";
            txtbOsearch.Size = new Size(247, 27);
            txtbOsearch.TabIndex = 2;
            // 
            // lblOsearch
            // 
            lblOsearch.AutoSize = true;
            lblOsearch.Location = new Point(141, 99);
            lblOsearch.Name = "lblOsearch";
            lblOsearch.Size = new Size(79, 20);
            lblOsearch.TabIndex = 3;
            lblOsearch.Text = "Search for:";
            // 
            // btnOsearch
            // 
            btnOsearch.Location = new Point(510, 88);
            btnOsearch.Margin = new Padding(3, 4, 3, 4);
            btnOsearch.Name = "btnOsearch";
            btnOsearch.Size = new Size(86, 31);
            btnOsearch.TabIndex = 4;
            btnOsearch.Text = "Search";
            btnOsearch.UseVisualStyleBackColor = true;
            // 
            // btnOview
            // 
            btnOview.Location = new Point(730, 493);
            btnOview.Margin = new Padding(3, 4, 3, 4);
            btnOview.Name = "btnOview";
            btnOview.Size = new Size(86, 31);
            btnOview.TabIndex = 5;
            btnOview.Text = "View";
            btnOview.UseVisualStyleBackColor = true;
            // 
            // btnOdelete
            // 
            btnOdelete.Location = new Point(618, 493);
            btnOdelete.Margin = new Padding(3, 4, 3, 4);
            btnOdelete.Name = "btnOdelete";
            btnOdelete.Size = new Size(86, 31);
            btnOdelete.TabIndex = 6;
            btnOdelete.Text = "Delete";
            btnOdelete.UseVisualStyleBackColor = true;
            // 
            // btnOupdate
            // 
            btnOupdate.Location = new Point(474, 493);
            btnOupdate.Margin = new Padding(3, 4, 3, 4);
            btnOupdate.Name = "btnOupdate";
            btnOupdate.Size = new Size(121, 31);
            btnOupdate.TabIndex = 7;
            btnOupdate.Text = "Update";
            btnOupdate.UseVisualStyleBackColor = true;
            // 
            // btnOback
            // 
            btnOback.Location = new Point(14, 12);
            btnOback.Margin = new Padding(3, 4, 3, 4);
            btnOback.Name = "btnOback";
            btnOback.Size = new Size(69, 37);
            btnOback.TabIndex = 8;
            btnOback.Text = "back";
            btnOback.UseVisualStyleBackColor = true;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnOback);
            Controls.Add(btnOupdate);
            Controls.Add(btnOdelete);
            Controls.Add(btnOview);
            Controls.Add(btnOsearch);
            Controls.Add(lblOsearch);
            Controls.Add(txtbOsearch);
            Controls.Add(dataOrder);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnOview;
        private Button btnOdelete;
        private Button btnOupdate;
        private Button btnOback;
    }
}