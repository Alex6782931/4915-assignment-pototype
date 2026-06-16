namespace _4915_assignment_pototype
{
    partial class MasterDataMaintance
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
            button1 = new Button();
            label1 = new Label();
            dataMDM = new DataGridView();
            txtbMDMsearch = new TextBox();
            label2 = new Label();
            btnMDMsearch = new Button();
            btnMDMupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataMDM).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(19, 28);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(82, 52);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 37);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 23);
            label1.TabIndex = 1;
            label1.Text = "Data";
            // 
            // dataMDM
            // 
            dataMDM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataMDM.Location = new Point(75, 169);
            dataMDM.Margin = new Padding(5, 5, 5, 5);
            dataMDM.Name = "dataMDM";
            dataMDM.RowHeadersWidth = 62;
            dataMDM.Size = new Size(1119, 366);
            dataMDM.TabIndex = 2;
            // 
            // txtbMDMsearch
            // 
            txtbMDMsearch.Location = new Point(273, 115);
            txtbMDMsearch.Margin = new Padding(5, 5, 5, 5);
            txtbMDMsearch.Name = "txtbMDMsearch";
            txtbMDMsearch.Size = new Size(402, 30);
            txtbMDMsearch.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            label2.Text = "Search for:";
            // 
            // btnMDMsearch
            // 
            btnMDMsearch.Location = new Point(721, 112);
            btnMDMsearch.Margin = new Padding(5, 5, 5, 5);
            btnMDMsearch.Name = "btnMDMsearch";
            btnMDMsearch.Size = new Size(105, 35);
            btnMDMsearch.TabIndex = 5;
            btnMDMsearch.Text = "Search";
            btnMDMsearch.UseVisualStyleBackColor = true;
            // 
            // btnMDMupdate
            // 
            btnMDMupdate.Location = new Point(1076, 563);
            btnMDMupdate.Margin = new Padding(5, 5, 5, 5);
            btnMDMupdate.Name = "btnMDMupdate";
            btnMDMupdate.Size = new Size(118, 35);
            btnMDMupdate.TabIndex = 6;
            btnMDMupdate.Text = "Update";
            btnMDMupdate.UseVisualStyleBackColor = true;
            // 
            // MasterDataMaintance
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnMDMupdate);
            Controls.Add(btnMDMsearch);
            Controls.Add(label2);
            Controls.Add(txtbMDMsearch);
            Controls.Add(dataMDM);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "MasterDataMaintance";
            Text = "MasterDataMaintance";
            ((System.ComponentModel.ISupportInitialize)dataMDM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private DataGridView dataMDM;
        private TextBox txtbMDMsearch;
        private Label label2;
        private Button btnMDMsearch;
        private Button btnMDMupdate;
    }
}