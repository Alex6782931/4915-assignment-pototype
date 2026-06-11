namespace _4915_assignment_pototype
{
    partial class OrderMainPage
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
            btnOcae = new Button();
            btnOback = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrder).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 22);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Order";
            // 
            // dataOrder
            // 
            dataOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrder.Location = new Point(71, 108);
            dataOrder.Name = "dataOrder";
            dataOrder.Size = new Size(643, 238);
            dataOrder.TabIndex = 1;
            // 
            // txtbOsearch
            // 
            txtbOsearch.Location = new Point(207, 67);
            txtbOsearch.Name = "txtbOsearch";
            txtbOsearch.Size = new Size(217, 23);
            txtbOsearch.TabIndex = 2;
            // 
            // lblOsearch
            // 
            lblOsearch.AutoSize = true;
            lblOsearch.Location = new Point(123, 74);
            lblOsearch.Name = "lblOsearch";
            lblOsearch.Size = new Size(63, 15);
            lblOsearch.TabIndex = 3;
            lblOsearch.Text = "Search for:";
            // 
            // btnOsearch
            // 
            btnOsearch.Location = new Point(446, 66);
            btnOsearch.Name = "btnOsearch";
            btnOsearch.Size = new Size(75, 23);
            btnOsearch.TabIndex = 4;
            btnOsearch.Text = "Search";
            btnOsearch.UseVisualStyleBackColor = true;
            // 
            // btnOview
            // 
            btnOview.Location = new Point(639, 370);
            btnOview.Name = "btnOview";
            btnOview.Size = new Size(75, 23);
            btnOview.TabIndex = 5;
            btnOview.Text = "View";
            btnOview.UseVisualStyleBackColor = true;
            // 
            // btnOdelete
            // 
            btnOdelete.Location = new Point(541, 370);
            btnOdelete.Name = "btnOdelete";
            btnOdelete.Size = new Size(75, 23);
            btnOdelete.TabIndex = 6;
            btnOdelete.Text = "Delete";
            btnOdelete.UseVisualStyleBackColor = true;
            // 
            // btnOcae
            // 
            btnOcae.Location = new Point(415, 370);
            btnOcae.Name = "btnOcae";
            btnOcae.Size = new Size(106, 23);
            btnOcae.TabIndex = 7;
            btnOcae.Text = "Create and edit";
            btnOcae.UseVisualStyleBackColor = true;
            // 
            // btnOback
            // 
            btnOback.Location = new Point(12, 9);
            btnOback.Name = "btnOback";
            btnOback.Size = new Size(60, 28);
            btnOback.TabIndex = 8;
            btnOback.Text = "back";
            btnOback.UseVisualStyleBackColor = true;
            // 
            // OrderMainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOback);
            Controls.Add(btnOcae);
            Controls.Add(btnOdelete);
            Controls.Add(btnOview);
            Controls.Add(btnOsearch);
            Controls.Add(lblOsearch);
            Controls.Add(txtbOsearch);
            Controls.Add(dataOrder);
            Controls.Add(label1);
            Name = "OrderMainPage";
            Text = "OrderMainPage";
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
        private Button btnOcae;
        private Button btnOback;
    }
}