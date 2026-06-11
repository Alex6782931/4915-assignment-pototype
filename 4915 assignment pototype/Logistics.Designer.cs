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
            btnLcreate = new Button();
            label2 = new Label();
            txtbLsearch = new TextBox();
            btnLsearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataLogistics).BeginInit();
            SuspendLayout();
            // 
            // btnLback
            // 
            btnLback.Location = new Point(18, 12);
            btnLback.Name = "btnLback";
            btnLback.Size = new Size(50, 38);
            btnLback.TabIndex = 0;
            btnLback.Text = "back";
            btnLback.UseVisualStyleBackColor = true;
            // 
            // dataLogistics
            // 
            dataLogistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataLogistics.Location = new Point(53, 90);
            dataLogistics.Name = "dataLogistics";
            dataLogistics.Size = new Size(686, 213);
            dataLogistics.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 21);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 2;
            label1.Text = "Logistics";
            // 
            // btnLcreate
            // 
            btnLcreate.Location = new Point(639, 327);
            btnLcreate.Name = "btnLcreate";
            btnLcreate.Size = new Size(75, 23);
            btnLcreate.TabIndex = 3;
            btnLcreate.Text = "create";
            btnLcreate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 64);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Search for";
            // 
            // txtbLsearch
            // 
            txtbLsearch.Location = new Point(166, 61);
            txtbLsearch.Name = "txtbLsearch";
            txtbLsearch.Size = new Size(260, 23);
            txtbLsearch.TabIndex = 6;
            // 
            // btnLsearch
            // 
            btnLsearch.Location = new Point(435, 60);
            btnLsearch.Name = "btnLsearch";
            btnLsearch.Size = new Size(75, 23);
            btnLsearch.TabIndex = 7;
            btnLsearch.Text = "Search";
            btnLsearch.UseVisualStyleBackColor = true;
            // 
            // Logistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLsearch);
            Controls.Add(txtbLsearch);
            Controls.Add(label2);
            Controls.Add(btnLcreate);
            Controls.Add(label1);
            Controls.Add(dataLogistics);
            Controls.Add(btnLback);
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
        private Button btnLcreate;
        private Label label2;
        private TextBox txtbLsearch;
        private Button btnLsearch;
    }
}