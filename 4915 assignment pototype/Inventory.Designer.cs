namespace _4915_assignment_pototype
{
    partial class Inventory
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
            btnIback = new Button();
            label1 = new Label();
            dataInv = new DataGridView();
            btnInvSearch = new Button();
            label2 = new Label();
            txtInvSearch = new TextBox();
            btnInvUpdate = new Button();
            btnInvClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataInv).BeginInit();
            SuspendLayout();
            // 
            // btnIback
            // 
            btnIback.Location = new Point(10, 17);
            btnIback.Margin = new Padding(4);
            btnIback.Name = "btnIback";
            btnIback.Size = new Size(55, 40);
            btnIback.TabIndex = 0;
            btnIback.Text = "back";
            btnIback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 1;
            label1.Text = "Inventory";
            // 
            // dataInv
            // 
            dataInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataInv.Location = new Point(48, 114);
            dataInv.Margin = new Padding(4);
            dataInv.Name = "dataInv";
            dataInv.RowHeadersWidth = 62;
            dataInv.Size = new Size(802, 327);
            dataInv.TabIndex = 2;
            // 
            // btnInvSearch
            // 
            btnInvSearch.Location = new Point(648, 76);
            btnInvSearch.Margin = new Padding(4);
            btnInvSearch.Name = "btnInvSearch";
            btnInvSearch.Size = new Size(94, 30);
            btnInvSearch.TabIndex = 3;
            btnInvSearch.Text = "Search";
            btnInvSearch.UseVisualStyleBackColor = true;
            btnInvSearch.Click += btnInvSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 4;
            label2.Text = "Search by(item name):";
            // 
            // txtInvSearch
            // 
            txtInvSearch.Location = new Point(213, 79);
            txtInvSearch.Margin = new Padding(4);
            txtInvSearch.Name = "txtInvSearch";
            txtInvSearch.Size = new Size(427, 27);
            txtInvSearch.TabIndex = 5;
            // 
            // btnInvUpdate
            // 
            btnInvUpdate.Location = new Point(727, 457);
            btnInvUpdate.Margin = new Padding(2, 3, 2, 3);
            btnInvUpdate.Name = "btnInvUpdate";
            btnInvUpdate.Size = new Size(116, 28);
            btnInvUpdate.TabIndex = 6;
            btnInvUpdate.Text = "Update";
            btnInvUpdate.UseVisualStyleBackColor = true;
            btnInvUpdate.Click += btnInvUpdate_Click;
            // 
            // btnInvClear
            // 
            btnInvClear.Location = new Point(749, 76);
            btnInvClear.Name = "btnInvClear";
            btnInvClear.Size = new Size(94, 29);
            btnInvClear.TabIndex = 7;
            btnInvClear.Text = "Clear";
            btnInvClear.UseVisualStyleBackColor = true;
            btnInvClear.Click += btnInvClear_Click;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnInvClear);
            Controls.Add(btnInvUpdate);
            Controls.Add(txtInvSearch);
            Controls.Add(label2);
            Controls.Add(btnInvSearch);
            Controls.Add(dataInv);
            Controls.Add(label1);
            Controls.Add(btnIback);
            Margin = new Padding(4);
            Name = "Inventory";
            Text = "Inventory";
            Load += Inventory_Load;
            ((System.ComponentModel.ISupportInitialize)dataInv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIback;
        private Label label1;
        private DataGridView dataInv;
        private Button btnInvSearch;
        private Label label2;
        private TextBox txtInvSearch;
        private Button btnInvUpdate;
        private Button btnInvClear;
    }
}