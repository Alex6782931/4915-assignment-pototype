namespace _4915_assignment_pototype
{
    partial class Logistics
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
            btnLback = new Button();
            dataLogistics = new DataGridView();
            label1 = new Label();
            btnLupdate = new Button();
            label2 = new Label();
            txtbLsearch = new TextBox();
            btnLsearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataLogistics).BeginInit();
            SuspendLayout();
            // 
            // btnLback
            // 
            btnLback.Location = new Point(28, 18);
            btnLback.Margin = new Padding(5, 5, 5, 5);
            btnLback.Name = "btnLback";
            btnLback.Size = new Size(79, 58);
            btnLback.TabIndex = 0;
            btnLback.Text = "back";
            btnLback.UseVisualStyleBackColor = true;
            // 
            // dataLogistics
            // 
            dataLogistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataLogistics.Location = new Point(83, 138);
            dataLogistics.Margin = new Padding(5, 5, 5, 5);
            dataLogistics.Name = "dataLogistics";
            dataLogistics.RowHeadersWidth = 62;
            dataLogistics.Size = new Size(1078, 327);
            dataLogistics.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 32);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 2;
            label1.Text = "Logistics";
            // 
            // btnLupdate
            // 
            btnLupdate.Location = new Point(1004, 501);
            btnLupdate.Margin = new Padding(5, 5, 5, 5);
            btnLupdate.Name = "btnLupdate";
            btnLupdate.Size = new Size(118, 35);
            btnLupdate.TabIndex = 3;
            btnLupdate.Text = "Update";
            btnLupdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 98);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 23);
            label2.TabIndex = 5;
            label2.Text = "Search for";
            // 
            // txtbLsearch
            // 
            txtbLsearch.Location = new Point(261, 94);
            txtbLsearch.Margin = new Padding(5, 5, 5, 5);
            txtbLsearch.Name = "txtbLsearch";
            txtbLsearch.Size = new Size(406, 30);
            txtbLsearch.TabIndex = 6;
            // 
            // btnLsearch
            // 
            btnLsearch.Location = new Point(684, 92);
            btnLsearch.Margin = new Padding(5, 5, 5, 5);
            btnLsearch.Name = "btnLsearch";
            btnLsearch.Size = new Size(118, 35);
            btnLsearch.TabIndex = 7;
            btnLsearch.Text = "Search";
            btnLsearch.UseVisualStyleBackColor = true;
            // 
            // Logistics
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnLsearch);
            Controls.Add(txtbLsearch);
            Controls.Add(label2);
            Controls.Add(btnLupdate);
            Controls.Add(label1);
            Controls.Add(dataLogistics);
            Controls.Add(btnLback);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Logistics";
            Text = "Logistics";
            ((System.ComponentModel.ISupportInitialize)dataLogistics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLback;
        private DataGridView dataLogistics;
        private Label label1;
        private Button btnLupdate;
        private Label label2;
        private TextBox txtbLsearch;
        private Button btnLsearch;
    }
}