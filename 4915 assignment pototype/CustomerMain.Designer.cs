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
            btnchange = new Button();
            btncustomhis = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblwelcome
            // 
            lblwelcome.AutoSize = true;
            lblwelcome.Location = new Point(44, 28);
            lblwelcome.Name = "lblwelcome";
            lblwelcome.Size = new Size(90, 23);
            lblwelcome.TabIndex = 0;
            lblwelcome.Text = "welcome,";
            // 
            // btnmakeorder
            // 
            btnmakeorder.Location = new Point(77, 215);
            btnmakeorder.Name = "btnmakeorder";
            btnmakeorder.Size = new Size(176, 41);
            btnmakeorder.TabIndex = 1;
            btnmakeorder.Text = "Order product ";
            btnmakeorder.UseVisualStyleBackColor = true;
            btnmakeorder.Click += btnmakeorder_Click;
            // 
            // btnviewhistory
            // 
            btnviewhistory.Location = new Point(77, 281);
            btnviewhistory.Name = "btnviewhistory";
            btnviewhistory.Size = new Size(176, 35);
            btnviewhistory.TabIndex = 2;
            btnviewhistory.Text = "View order history";
            btnviewhistory.UseVisualStyleBackColor = true;
            // 
            // btncancelorder
            // 
            btncancelorder.Location = new Point(77, 389);
            btncancelorder.Name = "btncancelorder";
            btncancelorder.Size = new Size(159, 43);
            btncancelorder.TabIndex = 3;
            btncancelorder.Text = "Cancel order";
            btncancelorder.UseVisualStyleBackColor = true;
            btncancelorder.Click += btncancelorder_Click;
            // 
            // btnaddress
            // 
            btnaddress.Location = new Point(420, 261);
            btnaddress.Name = "btnaddress";
            btnaddress.Size = new Size(255, 41);
            btnaddress.TabIndex = 4;
            btnaddress.Text = "modify/add address";
            btnaddress.UseVisualStyleBackColor = true;
            // 
            // btnlogout
            // 
            btnlogout.Location = new Point(663, 17);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(119, 48);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = true;
            // 
            // btnpayment
            // 
            btnpayment.Location = new Point(410, 327);
            btnpayment.Name = "btnpayment";
            btnpayment.Size = new Size(295, 35);
            btnpayment.TabIndex = 6;
            btnpayment.Text = "modify payment information";
            btnpayment.UseVisualStyleBackColor = true;
            btnpayment.Click += btnpayment_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 83);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 7;
            label1.Text = "product order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 83);
            label2.Name = "label2";
            label2.Size = new Size(189, 23);
            label2.TabIndex = 8;
            label2.Text = "personal information";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(108, 120);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(99, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(470, 120);
            pictureBox2.Margin = new Padding(5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(137, 121);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // btnchange
            // 
            btnchange.Location = new Point(425, 393);
            btnchange.Name = "btnchange";
            btnchange.Size = new Size(250, 34);
            btnchange.TabIndex = 11;
            btnchange.Text = "change passsword";
            btnchange.UseVisualStyleBackColor = true;
            btnchange.Click += btnchange_Click;
            // 
            // btncustomhis
            // 
            btncustomhis.Location = new Point(63, 338);
            btncustomhis.Name = "btncustomhis";
            btncustomhis.Size = new Size(190, 34);
            btncustomhis.TabIndex = 12;
            btncustomhis.Text = "Customize History";
            btncustomhis.UseVisualStyleBackColor = true;
            btncustomhis.Click += btncustomhis_Click;
            // 
            // CustomerMain
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 449);
            Controls.Add(btncustomhis);
            Controls.Add(btnchange);
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
        private Button btnchange;
        private Button btncustomhis;
    }
}