namespace _4915_assignment_pototype
{
    partial class Procurement
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
            btnPback = new Button();
            label1 = new Label();
            dataProcurement = new DataGridView();
            label2 = new Label();
            txtbPsearch = new TextBox();
            btnPsearch = new Button();
            btnPce = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProcurement).BeginInit();
            SuspendLayout();
            // 
            // btnPback
            // 
            btnPback.Location = new Point(9, 7);
            btnPback.Name = "btnPback";
            btnPback.Size = new Size(54, 33);
            btnPback.TabIndex = 0;
            btnPback.Text = "back";
            btnPback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 15);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Procurement";
            // 
            // dataProcurement
            // 
            dataProcurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProcurement.Location = new Point(72, 135);
            dataProcurement.Name = "dataProcurement";
            dataProcurement.Size = new Size(664, 192);
            dataProcurement.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 101);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Search for:";
            // 
            // txtbPsearch
            // 
            txtbPsearch.Location = new Point(149, 98);
            txtbPsearch.Name = "txtbPsearch";
            txtbPsearch.Size = new Size(292, 23);
            txtbPsearch.TabIndex = 4;
            // 
            // btnPsearch
            // 
            btnPsearch.Location = new Point(450, 97);
            btnPsearch.Name = "btnPsearch";
            btnPsearch.Size = new Size(75, 23);
            btnPsearch.TabIndex = 5;
            btnPsearch.Text = "Search";
            btnPsearch.UseVisualStyleBackColor = true;
            // 
            // btnPce
            // 
            btnPce.Location = new Point(609, 346);
            btnPce.Name = "btnPce";
            btnPce.Size = new Size(127, 23);
            btnPce.TabIndex = 6;
            btnPce.Text = "Create and Edit";
            btnPce.UseVisualStyleBackColor = true;
            // 
            // Procurement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPce);
            Controls.Add(btnPsearch);
            Controls.Add(txtbPsearch);
            Controls.Add(label2);
            Controls.Add(dataProcurement);
            Controls.Add(label1);
            Controls.Add(btnPback);
            Name = "Procurement";
            Text = "Procurement";
            ((System.ComponentModel.ISupportInitialize)dataProcurement).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPback;
        private Label label1;
        private DataGridView dataProcurement;
        private Label label2;
        private TextBox txtbPsearch;
        private Button btnPsearch;
        private Button btnPce;
    }
}