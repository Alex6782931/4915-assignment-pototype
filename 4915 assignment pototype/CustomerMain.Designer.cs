namespace _4915_assignment_pototype
{
    partial class CustomerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMain));
            lblwelcome = new Label();
            btnmakeorder = new Button();
            btnviewhistory = new Button();
            btncancelorder = new Button();
            btnaddress = new Button();
            btnlogout = new Button();
            btnpayment = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Location = new Point(28, 18);
            lblwelcome.Margin = new Padding(2, 0, 2, 0);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(61, 15);
            lblwelcome.TabIndex = 0;
            lblwelcome.Text = "welcome,";
            // 
            // btnmakeorder
            // 
            btnmakeorder.Location = new Point(49, 140);
            btnmakeorder.Margin = new Padding(2);
            btnmakeorder.Name = "btnmakeorder";
            btnmakeorder.Size = new Size(112, 27);
            btnmakeorder.TabIndex = 1;
            btnmakeorder.Text = "Order product ";
            btnmakeorder.UseVisualStyleBackColor = true;
            btnmakeorder.Click += btnmakeorder_Click;
            // 
            // btnviewhistory
            // 
            btnviewhistory.Location = new Point(49, 194);
            btnviewhistory.Margin = new Padding(2);
            btnviewhistory.Name = "btnviewhistory";
            btnviewhistory.Size = new Size(112, 23);
            btnviewhistory.TabIndex = 2;
            btnviewhistory.Text = "View order history";
            btnviewhistory.UseVisualStyleBackColor = true;
            // 
            // btncancelorder
            // 
            btncancelorder.Location = new Point(49, 243);
            btncancelorder.Margin = new Padding(2);
            btncancelorder.Name = "btncancelorder";
            btncancelorder.Size = new Size(101, 28);
            btncancelorder.TabIndex = 3;
            btncancelorder.Text = "Cancel order";
            btncancelorder.UseVisualStyleBackColor = true;
            btncancelorder.Click += btncancelorder_Click;
            // 
            // btnaddress
            // 
            btnaddress.Location = new Point(267, 170);
            btnaddress.Margin = new Padding(2);
            btnaddress.Name = "btnaddress";
            btnaddress.Size = new Size(162, 27);
            btnaddress.TabIndex = 4;
            btnaddress.Text = "modify/add address";
            btnaddress.UseVisualStyleBackColor = true;
            // 
            // btnlogout
            // 
            btnlogout.Location = new Point(422, 11);
            btnlogout.Margin = new Padding(2);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(76, 31);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = true;
            // 
            // btnpayment
            // 
            btnpayment.Location = new Point(266, 224);
            btnpayment.Margin = new Padding(2);
            btnpayment.Name = "btnpayment";
            btnpayment.Size = new Size(188, 23);
            btnpayment.TabIndex = 6;
            btnpayment.Text = "modify payment information";
            btnpayment.UseVisualStyleBackColor = true;
            btnpayment.Click += btnpayment_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 54);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 7;
            label1.Text = "product order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(283, 54);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 8;
            label2.Text = "personal information";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(69, 78);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(299, 78);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(87, 79);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // CustomerMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 293);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnpayment);
            Controls.Add(btnlogout);
            Controls.Add(btnaddress);
            Controls.Add(btncancelorder);
            Controls.Add(btnviewhistory);
            Controls.Add(btnmakeorder);
            Controls.Add(lblwelcome);
            Margin = new Padding(2);
            Name = "CustomerMain";
            Text = "CustomerMian";
            Load += CustomerMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblwelcome;
        private Button btnmakeorder;
        private Button btnviewhistory;
        private Button btncancelorder;
        private Button btnaddress;
        private Button btnlogout;
        private Button btnpayment;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}