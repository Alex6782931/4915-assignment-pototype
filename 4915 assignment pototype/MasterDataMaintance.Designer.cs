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
            btnMDMcreate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataMDM).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 18);
            button1.Name = "button1";
            button1.Size = new Size(52, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 24);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Data";
            // 
            // dataMDM
            // 
            dataMDM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataMDM.Location = new Point(48, 110);
            dataMDM.Name = "dataMDM";
            dataMDM.Size = new Size(712, 239);
            dataMDM.TabIndex = 2;
            // 
            // txtbMDMsearch
            // 
            txtbMDMsearch.Location = new Point(174, 75);
            txtbMDMsearch.Name = "txtbMDMsearch";
            txtbMDMsearch.Size = new Size(257, 23);
            txtbMDMsearch.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 78);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "Search for:";
            // 
            // btnMDMsearch
            // 
            btnMDMsearch.Location = new Point(459, 73);
            btnMDMsearch.Name = "btnMDMsearch";
            btnMDMsearch.Size = new Size(67, 23);
            btnMDMsearch.TabIndex = 5;
            btnMDMsearch.Text = "Search";
            btnMDMsearch.UseVisualStyleBackColor = true;
            // 
            // btnMDMcreate
            // 
            btnMDMcreate.Location = new Point(685, 367);
            btnMDMcreate.Name = "btnMDMcreate";
            btnMDMcreate.Size = new Size(75, 23);
            btnMDMcreate.TabIndex = 6;
            btnMDMcreate.Text = "Create";
            btnMDMcreate.UseVisualStyleBackColor = true;
            // 
            // MasterDataMaintance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMDMcreate);
            Controls.Add(btnMDMsearch);
            Controls.Add(label2);
            Controls.Add(txtbMDMsearch);
            Controls.Add(dataMDM);
            Controls.Add(label1);
            Controls.Add(button1);
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
        private Button btnMDMcreate;
    }
}