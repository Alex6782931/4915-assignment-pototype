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
            btnPupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataProcurement).BeginInit();
            SuspendLayout();
            // 
            // btnPback
            // 
            btnPback.Location = new Point(14, 11);
            btnPback.Margin = new Padding(5, 5, 5, 5);
            btnPback.Name = "btnPback";
            btnPback.Size = new Size(85, 51);
            btnPback.TabIndex = 0;
            btnPback.Text = "back";
            btnPback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 23);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 23);
            label1.TabIndex = 1;
            label1.Text = "Procurement";
            // 
            // dataProcurement
            // 
            dataProcurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProcurement.Location = new Point(113, 207);
            dataProcurement.Margin = new Padding(5, 5, 5, 5);
            dataProcurement.Name = "dataProcurement";
            dataProcurement.RowHeadersWidth = 62;
            dataProcurement.Size = new Size(1043, 294);
            dataProcurement.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 155);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 3;
            label2.Text = "Search for:";
            // 
            // txtbPsearch
            // 
            txtbPsearch.Location = new Point(234, 150);
            txtbPsearch.Margin = new Padding(5, 5, 5, 5);
            txtbPsearch.Name = "txtbPsearch";
            txtbPsearch.Size = new Size(457, 30);
            txtbPsearch.TabIndex = 4;
            // 
            // btnPsearch
            // 
            btnPsearch.Location = new Point(707, 149);
            btnPsearch.Margin = new Padding(5, 5, 5, 5);
            btnPsearch.Name = "btnPsearch";
            btnPsearch.Size = new Size(118, 35);
            btnPsearch.TabIndex = 5;
            btnPsearch.Text = "Search";
            btnPsearch.UseVisualStyleBackColor = true;
            // 
            // btnPupdate
            // 
            btnPupdate.Location = new Point(957, 531);
            btnPupdate.Margin = new Padding(5, 5, 5, 5);
            btnPupdate.Name = "btnPupdate";
            btnPupdate.Size = new Size(200, 35);
            btnPupdate.TabIndex = 6;
            btnPupdate.Text = "Update";
            btnPupdate.UseVisualStyleBackColor = true;
            // 
            // Procurement
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnPupdate);
            Controls.Add(btnPsearch);
            Controls.Add(txtbPsearch);
            Controls.Add(label2);
            Controls.Add(dataProcurement);
            Controls.Add(label1);
            Controls.Add(btnPback);
            Margin = new Padding(5, 5, 5, 5);
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
        private Button btnPupdate;
    }
}