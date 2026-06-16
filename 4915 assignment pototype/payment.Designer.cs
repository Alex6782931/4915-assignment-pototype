namespace _4915_assignment_pototype
{
    partial class payment
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
            label2 = new Label();
            txtbPcardnum = new TextBox();
            label3 = new Label();
            txtbexpireddate = new TextBox();
            label4 = new Label();
            txtbcvv = new TextBox();
            btnPmodify = new Button();
            SuspendLayout();
            // 
            // btnPback
            // 
            btnPback.Location = new Point(18, 23);
            btnPback.Name = "btnPback";
            btnPback.Size = new Size(119, 30);
            btnPback.TabIndex = 0;
            btnPback.Text = "back";
            btnPback.UseVisualStyleBackColor = true;
            btnPback.Click += btnPback_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 30);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 1;
            label1.Text = "Payment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 107);
            label2.Name = "label2";
            label2.Size = new Size(119, 23);
            label2.TabIndex = 2;
            label2.Text = "card number";
            // 
            // txtbPcardnum
            // 
            txtbPcardnum.Location = new Point(195, 104);
            txtbPcardnum.Name = "txtbPcardnum";
            txtbPcardnum.Size = new Size(235, 30);
            txtbPcardnum.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 171);
            label3.Name = "label3";
            label3.Size = new Size(108, 23);
            label3.TabIndex = 4;
            label3.Text = "expired day";
            // 
            // txtbexpireddate
            // 
            txtbexpireddate.Location = new Point(195, 168);
            txtbexpireddate.Name = "txtbexpireddate";
            txtbexpireddate.Size = new Size(227, 30);
            txtbexpireddate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 231);
            label4.Name = "label4";
            label4.Size = new Size(46, 23);
            label4.TabIndex = 6;
            label4.Text = "CVV";
            // 
            // txtbcvv
            // 
            txtbcvv.Location = new Point(199, 231);
            txtbcvv.Name = "txtbcvv";
            txtbcvv.Size = new Size(231, 30);
            txtbcvv.TabIndex = 7;
            // 
            // btnPmodify
            // 
            btnPmodify.Location = new Point(580, 364);
            btnPmodify.Name = "btnPmodify";
            btnPmodify.Size = new Size(127, 34);
            btnPmodify.TabIndex = 8;
            btnPmodify.Text = "modify";
            btnPmodify.UseVisualStyleBackColor = true;
            // 
            // payment
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPmodify);
            Controls.Add(txtbcvv);
            Controls.Add(label4);
            Controls.Add(txtbexpireddate);
            Controls.Add(label3);
            Controls.Add(txtbPcardnum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPback);
            Name = "payment";
            Text = "payment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPback;
        private Label label1;
        private Label label2;
        private TextBox txtbPcardnum;
        private Label label3;
        private TextBox txtbexpireddate;
        private Label label4;
        private TextBox txtbcvv;
        private Button btnPmodify;
    }
}