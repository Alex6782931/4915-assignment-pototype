namespace _4915_assignment_pototype
{
    partial class CancelOrder
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
            btnCOback = new Button();
            label1 = new Label();
            label2 = new Label();
            txtbCOsearch = new TextBox();
            brnCOsearch = new Button();
            dataCO = new DataGridView();
            btnCOcancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCO).BeginInit();
            SuspendLayout();
            // 
            // btnCOback
            // 
            btnCOback.Location = new Point(14, 17);
            btnCOback.Name = "btnCOback";
            btnCOback.Size = new Size(113, 28);
            btnCOback.TabIndex = 0;
            btnCOback.Text = "back";
            btnCOback.UseVisualStyleBackColor = true;
            btnCOback.Click += btnCOback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 16);
            label1.Name = "label1";
            label1.Size = new Size(122, 23);
            label1.TabIndex = 1;
            label1.Text = "Cancel Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 123);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 2;
            label2.Text = "search";
            // 
            // txtbCOsearch
            // 
            txtbCOsearch.Location = new Point(145, 118);
            txtbCOsearch.Name = "txtbCOsearch";
            txtbCOsearch.Size = new Size(333, 30);
            txtbCOsearch.TabIndex = 3;
            // 
            // brnCOsearch
            // 
            brnCOsearch.Location = new Point(490, 117);
            brnCOsearch.Name = "brnCOsearch";
            brnCOsearch.Size = new Size(129, 29);
            brnCOsearch.TabIndex = 4;
            brnCOsearch.Text = "search";
            brnCOsearch.UseVisualStyleBackColor = true;
            // 
            // dataCO
            // 
            dataCO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCO.Location = new Point(18, 167);
            dataCO.Name = "dataCO";
            dataCO.RowHeadersWidth = 62;
            dataCO.Size = new Size(763, 189);
            dataCO.TabIndex = 5;
            // 
            // btnCOcancel
            // 
            btnCOcancel.Location = new Point(655, 383);
            btnCOcancel.Name = "btnCOcancel";
            btnCOcancel.Size = new Size(126, 30);
            btnCOcancel.TabIndex = 6;
            btnCOcancel.Text = "Cancel";
            btnCOcancel.UseVisualStyleBackColor = true;
            // 
            // CancelOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCOcancel);
            Controls.Add(dataCO);
            Controls.Add(brnCOsearch);
            Controls.Add(txtbCOsearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCOback);
            Name = "CancelOrder";
            Text = "CancelOrder";
            ((System.ComponentModel.ISupportInitialize)dataCO).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCOback;
        private Label label1;
        private Label label2;
        private TextBox txtbCOsearch;
        private Button brnCOsearch;
        private DataGridView dataCO;
        private Button btnCOcancel;
    }
}