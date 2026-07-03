namespace _4915_assignment_pototype
{
    partial class CustomizeRequiredForm
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
            label2 = new Label();
            label3 = new Label();
            btnback = new Button();
            txtdtqty = new TextBox();
            txtprice = new TextBox();
            txtlqty = new TextBox();
            btndetermine = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 63);
            label1.Name = "label1";
            label1.Size = new Size(217, 23);
            label1.TabIndex = 0;
            label1.Text = "desktop material quality";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 141);
            label2.Name = "label2";
            label2.Size = new Size(175, 23);
            label2.TabIndex = 1;
            label2.Text = "leg material quality";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 228);
            label3.Name = "label3";
            label3.Size = new Size(52, 23);
            label3.TabIndex = 2;
            label3.Text = "price";
            // 
            // btnback
            // 
            btnback.Location = new Point(23, 12);
            btnback.Name = "btnback";
            btnback.Size = new Size(88, 31);
            btnback.TabIndex = 3;
            btnback.Text = "back";
            btnback.UseVisualStyleBackColor = true;
            btnback.Click += btnback_Click;
            // 
            // txtdtqty
            // 
            txtdtqty.Location = new Point(347, 60);
            txtdtqty.Name = "txtdtqty";
            txtdtqty.Size = new Size(150, 30);
            txtdtqty.TabIndex = 4;
            // 
            // txtprice
            // 
            txtprice.Location = new Point(347, 211);
            txtprice.Name = "txtprice";
            txtprice.Size = new Size(150, 30);
            txtprice.TabIndex = 5;
            // 
            // txtlqty
            // 
            txtlqty.Location = new Point(347, 138);
            txtlqty.Name = "txtlqty";
            txtlqty.Size = new Size(150, 30);
            txtlqty.TabIndex = 6;
            // 
            // btndetermine
            // 
            btndetermine.Location = new Point(639, 362);
            btndetermine.Name = "btndetermine";
            btndetermine.Size = new Size(112, 34);
            btndetermine.TabIndex = 7;
            btndetermine.Text = "determine";
            btndetermine.UseVisualStyleBackColor = true;
            btndetermine.Click += btndetermine_Click;
            // 
            // CustomizeRequiredForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btndetermine);
            Controls.Add(txtlqty);
            Controls.Add(txtprice);
            Controls.Add(txtdtqty);
            Controls.Add(btnback);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CustomizeRequiredForm";
            Text = "CustomizeRequiredForm";
            Load += CustomizeRequiredForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnback;
        private TextBox txtdtqty;
        private TextBox txtprice;
        private TextBox txtlqty;
        private Button btndetermine;
    }
}