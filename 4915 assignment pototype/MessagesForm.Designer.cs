namespace _4915_assignment_pototype
{
    partial class MessagesForm
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
            dgvMessages = new DataGridView();
            cmbStaffList = new ComboBox();
            txtMessageBody = new TextBox();
            btnSend = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMessages).BeginInit();
            SuspendLayout();
            // 
            // dgvMessages
            // 
            dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMessages.Location = new Point(43, 134);
            dgvMessages.Name = "dgvMessages";
            dgvMessages.RowHeadersWidth = 51;
            dgvMessages.Size = new Size(678, 188);
            dgvMessages.TabIndex = 0;
            // 
            // cmbStaffList
            // 
            cmbStaffList.FormattingEnabled = true;
            cmbStaffList.Location = new Point(43, 86);
            cmbStaffList.Name = "cmbStaffList";
            cmbStaffList.Size = new Size(151, 28);
            cmbStaffList.TabIndex = 1;
            // 
            // txtMessageBody
            // 
            txtMessageBody.Location = new Point(43, 361);
            txtMessageBody.Name = "txtMessageBody";
            txtMessageBody.Size = new Size(678, 27);
            txtMessageBody.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(610, 409);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // MessagesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnSend);
            Controls.Add(txtMessageBody);
            Controls.Add(cmbStaffList);
            Controls.Add(dgvMessages);
            Name = "MessagesForm";
            Text = "MessagesForm";
            Load += MessagesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMessages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMessages;
        private ComboBox cmbStaffList;
        private TextBox txtMessageBody;
        private Button btnSend;
        private Button btnBack;
    }
}