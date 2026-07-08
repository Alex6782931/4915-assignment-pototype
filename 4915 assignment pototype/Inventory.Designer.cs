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
            btnProcurement = new Button();
            btnProduction = new Button();
            ((System.ComponentModel.ISupportInitialize)dataInv).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(14, 20);
            btnBack.Margin = new Padding(6, 5, 6, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(76, 46);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 84);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(172, 23);
            label1.TabIndex = 1;
            label1.Text = "Inventory database";
            // 
            // dataInv
            // 
            dataInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataInv.Location = new Point(69, 231);
            dataInv.Margin = new Padding(6, 5, 6, 5);
            dataInv.Name = "dataInv";
            dataInv.RowHeadersWidth = 62;
            dataInv.Size = new Size(1103, 376);
            dataInv.TabIndex = 2;
            // 
            // btnInvSearch
            // 
            btnInvSearch.Location = new Point(894, 187);
            btnInvSearch.Margin = new Padding(6, 5, 6, 5);
            btnInvSearch.Name = "btnInvSearch";
            btnInvSearch.Size = new Size(129, 34);
            btnInvSearch.TabIndex = 3;
            btnInvSearch.Text = "Search";
            btnInvSearch.UseVisualStyleBackColor = true;
            btnInvSearch.Click += btnInvSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 198);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(200, 23);
            label2.TabIndex = 4;
            label2.Text = "Search by(item name):";
            // 
            // txtInvSearch
            // 
            txtInvSearch.Location = new Point(296, 191);
            txtInvSearch.Margin = new Padding(6, 5, 6, 5);
            txtInvSearch.Name = "txtInvSearch";
            txtInvSearch.Size = new Size(586, 30);
            txtInvSearch.TabIndex = 5;
            // 
            // btnInvUpdate
            // 
            btnInvUpdate.Location = new Point(1002, 626);
            btnInvUpdate.Name = "btnInvUpdate";
            btnInvUpdate.Size = new Size(160, 32);
            btnInvUpdate.TabIndex = 6;
            btnInvUpdate.Text = "Update";
            btnInvUpdate.UseVisualStyleBackColor = true;
            btnInvUpdate.Click += btnInvUpdate_Click;
            // 
            // btnInvClear
            // 
            btnInvClear.Location = new Point(1033, 187);
            btnInvClear.Margin = new Padding(4, 3, 4, 3);
            btnInvClear.Name = "btnInvClear";
            btnInvClear.Size = new Size(129, 33);
            btnInvClear.TabIndex = 7;
            btnInvClear.Text = "Clear";
            btnInvClear.UseVisualStyleBackColor = true;
            btnInvClear.Click += btnInvClear_Click;
            // 
            // btnProcurement
            // 
            btnProcurement.Location = new Point(733, 626);
            btnProcurement.Margin = new Padding(4, 3, 4, 3);
            btnProcurement.Name = "btnProcurement";
            btnProcurement.Size = new Size(262, 33);
            btnProcurement.TabIndex = 8;
            btnProcurement.Text = "Raw Material Procurement";
            btnProcurement.Click += btnProcurement_Click;
            // 
            // btnProduction
            // 
            btnProduction.Location = new Point(519, 626);
            btnProduction.Margin = new Padding(4, 3, 4, 3);
            btnProduction.Name = "btnProduction";
            btnProduction.Size = new Size(206, 33);
            btnProduction.TabIndex = 9;
            btnProduction.Text = "Furniture Production";
            btnProduction.Click += btnProduction_Click;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnInvClear);
            Controls.Add(btnInvUpdate);
            Controls.Add(txtInvSearch);
            Controls.Add(label2);
            Controls.Add(btnInvSearch);
            Controls.Add(dataInv);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnProcurement);
            Controls.Add(btnProduction);
            Margin = new Padding(6, 5, 6, 5);
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
        private Button btnProcurement;
        private Button btnProduction;
    }
}