namespace _4915_assignment_pototype
{
    partial class Staff
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
            btnStaffback = new Button();
            label1 = new Label();
            btnStaffsearch = new Button();
            btnSaffupdate = new Button();
            label2 = new Label();
            txtbStaffsearch = new TextBox();
            dataStaff = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataStaff).BeginInit();
            SuspendLayout();
            // 
            // btnStaffback
            // 
            btnStaffback.Location = new Point(19, 18);
            btnStaffback.Margin = new Padding(5, 5, 5, 5);
            btnStaffback.Name = "btnStaffback";
            btnStaffback.Size = new Size(82, 49);
            btnStaffback.TabIndex = 0;
            btnStaffback.Text = "back";
            btnStaffback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 34);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 1;
            label1.Text = "Staff";
            // 
            // btnStaffsearch
            // 
            btnStaffsearch.Location = new Point(638, 155);
            btnStaffsearch.Margin = new Padding(5, 5, 5, 5);
            btnStaffsearch.Name = "btnStaffsearch";
            btnStaffsearch.Size = new Size(118, 35);
            btnStaffsearch.TabIndex = 2;
            btnStaffsearch.Text = "Search";
            btnStaffsearch.UseVisualStyleBackColor = true;
            // 
            // btnSaffupdate
            // 
            btnSaffupdate.Location = new Point(1070, 541);
            btnSaffupdate.Margin = new Padding(5, 5, 5, 5);
            btnSaffupdate.Name = "btnSaffupdate";
            btnSaffupdate.Size = new Size(118, 35);
            btnSaffupdate.TabIndex = 4;
            btnSaffupdate.Text = "Update";
            btnSaffupdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(143, 161);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 5;
            label2.Text = "Search for:";
            // 
            // txtbStaffsearch
            // 
            txtbStaffsearch.Location = new Point(272, 156);
            txtbStaffsearch.Margin = new Padding(5, 5, 5, 5);
            txtbStaffsearch.Name = "txtbStaffsearch";
            txtbStaffsearch.Size = new Size(293, 30);
            txtbStaffsearch.TabIndex = 6;
            // 
            // dataStaff
            // 
            dataStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataStaff.Location = new Point(55, 218);
            dataStaff.Margin = new Padding(5, 5, 5, 5);
            dataStaff.Name = "dataStaff";
            dataStaff.RowHeadersWidth = 62;
            dataStaff.Size = new Size(1133, 285);
            dataStaff.TabIndex = 7;
            // 
            // Staff
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(dataStaff);
            Controls.Add(txtbStaffsearch);
            Controls.Add(label2);
            Controls.Add(btnSaffupdate);
            Controls.Add(btnStaffsearch);
            Controls.Add(label1);
            Controls.Add(btnStaffback);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Staff";
            Text = "Staff";
            ((System.ComponentModel.ISupportInitialize)dataStaff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStaffback;
        private Label label1;
        private Button btnStaffsearch;
        private Button btnStaffcd;
        private Button btnSaffupdate;
        private Label label2;
        private TextBox txtbStaffsearch;
        private DataGridView dataStaff;
    }
}