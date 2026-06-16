namespace _4915_assignment_pototype
{
    partial class Inventory
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
            btnIback = new Button();
            label1 = new Label();
            datainventory = new DataGridView();
            btnLsearch = new Button();
            label2 = new Label();
            txtbIsearch = new TextBox();
            btnIupdate = new Button();
            ((System.ComponentModel.ISupportInitialize)datainventory).BeginInit();
            SuspendLayout();
            // 
            // btnIback
            // 
            btnIback.Location = new Point(14, 20);
            btnIback.Margin = new Padding(5, 5, 5, 5);
            btnIback.Name = "btnIback";
            btnIback.Size = new Size(75, 46);
            btnIback.TabIndex = 0;
            btnIback.Text = "back";
            btnIback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 29);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 1;
            label1.Text = "Inventory";
            // 
            // datainventory
            // 
            datainventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datainventory.Location = new Point(66, 153);
            datainventory.Margin = new Padding(5, 5, 5, 5);
            datainventory.Name = "datainventory";
            datainventory.RowHeadersWidth = 62;
            datainventory.Size = new Size(1103, 325);
            datainventory.TabIndex = 2;
            // 
            // btnLsearch
            // 
            btnLsearch.Location = new Point(588, 86);
            btnLsearch.Margin = new Padding(5, 5, 5, 5);
            btnLsearch.Name = "btnLsearch";
            btnLsearch.Size = new Size(118, 35);
            btnLsearch.TabIndex = 3;
            btnLsearch.Text = "button1";
            btnLsearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 97);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            label2.Text = "Search for:";
            // 
            // txtbIsearch
            // 
            txtbIsearch.Location = new Point(207, 92);
            txtbIsearch.Margin = new Padding(5, 5, 5, 5);
            txtbIsearch.Name = "txtbIsearch";
            txtbIsearch.Size = new Size(343, 30);
            txtbIsearch.TabIndex = 5;
            // 
            // btnIupdate
            // 
            btnIupdate.Location = new Point(1000, 526);
            btnIupdate.Name = "btnIupdate";
            btnIupdate.Size = new Size(160, 32);
            btnIupdate.TabIndex = 6;
            btnIupdate.Text = "Update";
            btnIupdate.UseVisualStyleBackColor = true;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 690);
            Controls.Add(btnIupdate);
            Controls.Add(txtbIsearch);
            Controls.Add(label2);
            Controls.Add(btnLsearch);
            Controls.Add(datainventory);
            Controls.Add(label1);
            Controls.Add(btnIback);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Inventory";
            Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)datainventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIback;
        private Label label1;
        private DataGridView datainventory;
        private Button btnLsearch;
        private Label label2;
        private TextBox txtbIsearch;
        private Button btnIupdate;
    }
}