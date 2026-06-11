namespace _4915_assignment_pototype
{
    partial class Customer
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
            btnCustback = new Button();
            label1 = new Label();
            btnCustsearch = new Button();
            label2 = new Label();
            txtbCustsearch = new TextBox();
            btnCustcreate = new Button();
            dataCust = new DataGridView();
            btnCustadjust = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCust).BeginInit();
            SuspendLayout();
            // 
            // btnCustback
            // 
            btnCustback.Location = new Point(11, 12);
            btnCustback.Name = "btnCustback";
            btnCustback.Size = new Size(42, 28);
            btnCustback.TabIndex = 0;
            btnCustback.Text = "back";
            btnCustback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 22);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Customer";
            // 
            // btnCustsearch
            // 
            btnCustsearch.Location = new Point(392, 98);
            btnCustsearch.Name = "btnCustsearch";
            btnCustsearch.Size = new Size(75, 23);
            btnCustsearch.TabIndex = 2;
            btnCustsearch.Text = "Search";
            btnCustsearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 99);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Search for:";
            // 
            // txtbCustsearch
            // 
            txtbCustsearch.Location = new Point(166, 99);
            txtbCustsearch.Name = "txtbCustsearch";
            txtbCustsearch.Size = new Size(220, 23);
            txtbCustsearch.TabIndex = 4;
            // 
            // btnCustcreate
            // 
            btnCustcreate.Location = new Point(643, 365);
            btnCustcreate.Name = "btnCustcreate";
            btnCustcreate.Size = new Size(123, 23);
            btnCustcreate.TabIndex = 5;
            btnCustcreate.Text = "create and delete";
            btnCustcreate.UseVisualStyleBackColor = true;
            // 
            // dataCust
            // 
            dataCust.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCust.Location = new Point(36, 145);
            dataCust.Name = "dataCust";
            dataCust.Size = new Size(730, 199);
            dataCust.TabIndex = 6;
            // 
            // btnCustadjust
            // 
            btnCustadjust.Location = new Point(534, 365);
            btnCustadjust.Name = "btnCustadjust";
            btnCustadjust.Size = new Size(75, 23);
            btnCustadjust.TabIndex = 7;
            btnCustadjust.Text = "adjust";
            btnCustadjust.UseVisualStyleBackColor = true;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCustadjust);
            Controls.Add(dataCust);
            Controls.Add(btnCustcreate);
            Controls.Add(txtbCustsearch);
            Controls.Add(label2);
            Controls.Add(btnCustsearch);
            Controls.Add(label1);
            Controls.Add(btnCustback);
            Name = "Customer";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)dataCust).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCustback;
        private Label label1;
        private Button btnCustsearch;
        private Label label2;
        private TextBox txtbCustsearch;
        private Button btnCustcreate;
        private DataGridView dataCust;
        private Button btnCustadjust;
    }
}