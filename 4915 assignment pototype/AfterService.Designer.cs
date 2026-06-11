namespace _4915_assignment_pototype
{
    partial class AfterService
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
            label1 = new Label();
            btnASback = new Button();
            label2 = new Label();
            txtbASsearch = new TextBox();
            btnASsearch = new Button();
            dataAS = new DataGridView();
            btnAScd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataAS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 21);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "After sale service";
            // 
            // btnASback
            // 
            btnASback.Location = new Point(13, 14);
            btnASback.Name = "btnASback";
            btnASback.Size = new Size(50, 28);
            btnASback.TabIndex = 1;
            btnASback.Text = "back";
            btnASback.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 101);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Search for:";
            // 
            // txtbASsearch
            // 
            txtbASsearch.Location = new Point(117, 98);
            txtbASsearch.Name = "txtbASsearch";
            txtbASsearch.Size = new Size(303, 23);
            txtbASsearch.TabIndex = 3;
            // 
            // btnASsearch
            // 
            btnASsearch.Location = new Point(437, 98);
            btnASsearch.Name = "btnASsearch";
            btnASsearch.Size = new Size(72, 26);
            btnASsearch.TabIndex = 4;
            btnASsearch.Text = "Search";
            btnASsearch.UseVisualStyleBackColor = true;
            // 
            // dataAS
            // 
            dataAS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAS.Location = new Point(48, 141);
            dataAS.Name = "dataAS";
            dataAS.Size = new Size(695, 215);
            dataAS.TabIndex = 5;
            // 
            // btnAScd
            // 
            btnAScd.Location = new Point(608, 380);
            btnAScd.Name = "btnAScd";
            btnAScd.Size = new Size(135, 23);
            btnAScd.TabIndex = 6;
            btnAScd.Text = "Create and delete";
            btnAScd.UseVisualStyleBackColor = true;
            // 
            // AfterService
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAScd);
            Controls.Add(dataAS);
            Controls.Add(btnASsearch);
            Controls.Add(txtbASsearch);
            Controls.Add(label2);
            Controls.Add(btnASback);
            Controls.Add(label1);
            Name = "AfterService";
            Text = "AfterService";
            ((System.ComponentModel.ISupportInitialize)dataAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnASback;
        private Label label2;
        private TextBox txtbASsearch;
        private Button btnASsearch;
        private DataGridView dataAS;
        private Button btnAScd;
    }
}