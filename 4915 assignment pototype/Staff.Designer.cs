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
            btnStaffcd = new Button();
            btnSaffadjust = new Button();
            label2 = new Label();
            txtbStaffsearch = new TextBox();
            dataStaff = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataStaff).BeginInit();
            SuspendLayout();
            // 
            // btnStaffback
            // 
            btnStaffback.Location = new Point(12, 12);
            btnStaffback.Name = "btnStaffback";
            btnStaffback.Size = new Size(52, 32);
            btnStaffback.TabIndex = 0;
            btnStaffback.Text = "back";
            btnStaffback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 22);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Staff";
            // 
            // btnStaffsearch
            // 
            btnStaffsearch.Location = new Point(406, 101);
            btnStaffsearch.Name = "btnStaffsearch";
            btnStaffsearch.Size = new Size(75, 23);
            btnStaffsearch.TabIndex = 2;
            btnStaffsearch.Text = "Search";
            btnStaffsearch.UseVisualStyleBackColor = true;
            // 
            // btnStaffcd
            // 
            btnStaffcd.Location = new Point(593, 341);
            btnStaffcd.Name = "btnStaffcd";
            btnStaffcd.Size = new Size(126, 23);
            btnStaffcd.TabIndex = 3;
            btnStaffcd.Text = "create and delete";
            btnStaffcd.UseVisualStyleBackColor = true;
            // 
            // btnSaffadjust
            // 
            btnSaffadjust.Location = new Point(496, 341);
            btnSaffadjust.Name = "btnSaffadjust";
            btnSaffadjust.Size = new Size(75, 23);
            btnSaffadjust.TabIndex = 4;
            btnSaffadjust.Text = "adjust";
            btnSaffadjust.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 105);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 5;
            label2.Text = "Search for:";
            // 
            // txtbStaffsearch
            // 
            txtbStaffsearch.Location = new Point(173, 102);
            txtbStaffsearch.Name = "txtbStaffsearch";
            txtbStaffsearch.Size = new Size(188, 23);
            txtbStaffsearch.TabIndex = 6;
            // 
            // dataStaff
            // 
            dataStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataStaff.Location = new Point(35, 142);
            dataStaff.Name = "dataStaff";
            dataStaff.Size = new Size(721, 186);
            dataStaff.TabIndex = 7;
            // 
            // Staff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataStaff);
            Controls.Add(txtbStaffsearch);
            Controls.Add(label2);
            Controls.Add(btnSaffadjust);
            Controls.Add(btnStaffcd);
            Controls.Add(btnStaffsearch);
            Controls.Add(label1);
            Controls.Add(btnStaffback);
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
        private Button btnSaffadjust;
        private Label label2;
        private TextBox txtbStaffsearch;
        private DataGridView dataStaff;
    }
}