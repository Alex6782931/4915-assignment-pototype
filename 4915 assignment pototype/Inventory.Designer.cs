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
            btnBack = new Button();
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
            // btnBack
            // 
            btnBack.Location = new Point(10, 17);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(55, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 73);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 1;
            label1.Text = "Inventory database";
            // 
            // dataInv
            // 
            dataInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataInv.Location = new Point(50, 201);
            dataInv.Margin = new Padding(4);
            dataInv.Name = "dataInv";
            dataInv.RowHeadersWidth = 62;
            dataInv.Size = new Size(802, 327);
            dataInv.TabIndex = 2;
            // 
            // btnInvSearch
            // 
            btnInvSearch.Location = new Point(650, 163);
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
            label2.Location = new Point(50, 172);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 4;
            label2.Text = "Search by(item name):";
            // 
            // txtInvSearch
            // 
            txtInvSearch.Location = new Point(215, 166);
            txtInvSearch.Margin = new Padding(4);
            txtInvSearch.Name = "txtInvSearch";
            txtInvSearch.Size = new Size(427, 27);
            txtInvSearch.TabIndex = 5;
            // 
            // btnInvUpdate
            // 
            btnInvUpdate.Location = new Point(729, 544);
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
            btnInvClear.Location = new Point(751, 163);
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
            Controls.Add(btnBack);
            Margin = new Padding(4);
            Name = "Inventory";
            Text = "Inventory";
            Load += Inventory_Load;
            ((System.ComponentModel.ISupportInitialize)dataInv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label1;
        private DataGridView dataInv;
        private Button btnInvSearch;
        private Label label2;
        private TextBox txtInvSearch;
        private Button btnInvUpdate;
        private Button btnInvClear;
    }
}