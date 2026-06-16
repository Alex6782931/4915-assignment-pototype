namespace _4915_assignment_pototype
{
    partial class MakeOrder
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
            btnMOback = new Button();
            label1 = new Label();
            label2 = new Label();
            txtbMOsearch = new TextBox();
            btnMOsearch = new Button();
            dataMO = new DataGridView();
            btnMOselect = new Button();
            label3 = new Label();
            txtbMOqty = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataMO).BeginInit();
            SuspendLayout();
            // 
            // btnMOback
            // 
            btnMOback.Location = new Point(14, 19);
            btnMOback.Name = "btnMOback";
            btnMOback.Size = new Size(94, 28);
            btnMOback.TabIndex = 0;
            btnMOback.Text = "back";
            btnMOback.UseVisualStyleBackColor = true;
            btnMOback.Click += btnMOback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 22);
            label1.Name = "label1";
            label1.Size = new Size(112, 23);
            label1.TabIndex = 1;
            label1.Text = "Make Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 100);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 2;
            label2.Text = "Search";
            // 
            // txtbMOsearch
            // 
            txtbMOsearch.Location = new Point(140, 101);
            txtbMOsearch.Name = "txtbMOsearch";
            txtbMOsearch.Size = new Size(255, 30);
            txtbMOsearch.TabIndex = 3;
            // 
            // btnMOsearch
            // 
            btnMOsearch.Location = new Point(416, 105);
            btnMOsearch.Name = "btnMOsearch";
            btnMOsearch.Size = new Size(136, 32);
            btnMOsearch.TabIndex = 4;
            btnMOsearch.Text = "search";
            btnMOsearch.UseVisualStyleBackColor = true;
            // 
            // dataMO
            // 
            dataMO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataMO.Location = new Point(44, 153);
            dataMO.Name = "dataMO";
            dataMO.RowHeadersWidth = 62;
            dataMO.Size = new Size(705, 180);
            dataMO.TabIndex = 5;
            // 
            // btnMOselect
            // 
            btnMOselect.Location = new Point(614, 372);
            btnMOselect.Name = "btnMOselect";
            btnMOselect.Size = new Size(131, 30);
            btnMOselect.TabIndex = 6;
            btnMOselect.Text = "select";
            btnMOselect.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(263, 373);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 7;
            label3.Text = "Quality";
            // 
            // txtbMOqty
            // 
            txtbMOqty.Location = new Point(342, 371);
            txtbMOqty.Name = "txtbMOqty";
            txtbMOqty.Size = new Size(264, 30);
            txtbMOqty.TabIndex = 8;
            // 
            // MakeOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtbMOqty);
            Controls.Add(label3);
            Controls.Add(btnMOselect);
            Controls.Add(dataMO);
            Controls.Add(btnMOsearch);
            Controls.Add(txtbMOsearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnMOback);
            Name = "MakeOrder";
            Text = "MakeOrder";
            ((System.ComponentModel.ISupportInitialize)dataMO).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMOback;
        private Label label1;
        private Label label2;
        private TextBox txtbMOsearch;
        private Button btnMOsearch;
        private DataGridView dataMO;
        private Button btnMOselect;
        private Label label3;
        private TextBox txtbMOqty;
    }
}