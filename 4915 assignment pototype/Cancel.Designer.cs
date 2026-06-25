namespace _4915_assignment_pototype
{
    partial class Cancel
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
            btnBack = new Button();
            dataOrder = new DataGridView();
            label1 = new Label();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataOrder).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(42, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataOrder
            // 
            dataOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataOrder.Location = new Point(42, 107);
            dataOrder.Name = "dataOrder";
            dataOrder.Size = new Size(671, 202);
            dataOrder.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 67);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 2;
            label1.Text = "Cancel Order ";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(638, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Cancel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(dataOrder);
            Controls.Add(btnBack);
            Name = "Cancel";
            Text = "Cancel";
            Load += Cancel_Load;
            ((System.ComponentModel.ISupportInitialize)dataOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Button btnBack;
        private DataGridView dataOrder;
        private Label label1;
        private Button btnCancel;
    }
}