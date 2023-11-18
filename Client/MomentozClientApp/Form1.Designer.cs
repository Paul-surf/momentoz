namespace MomentozClientApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.GETbtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ListBoxCustomers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client";
            // 
            // GETbtn
            // 
            this.GETbtn.Location = new System.Drawing.Point(275, 273);
            this.GETbtn.Name = "GETbtn";
            this.GETbtn.Size = new System.Drawing.Size(100, 28);
            this.GETbtn.TabIndex = 1;
            this.GETbtn.Text = "Get Customers";
            this.GETbtn.UseVisualStyleBackColor = true;
            this.GETbtn.Click += new System.EventHandler(this.GETbtn_Click_1);
            // 
            // ListBoxCustomers
            // 
            this.ListBoxCustomers.FormattingEnabled = true;
            this.ListBoxCustomers.ItemHeight = 15;
            this.ListBoxCustomers.Location = new System.Drawing.Point(117, 84);
            this.ListBoxCustomers.Name = "ListBoxCustomers";
            this.ListBoxCustomers.Size = new System.Drawing.Size(417, 169);
            this.ListBoxCustomers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 351);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListBoxCustomers);
            this.Controls.Add(this.GETbtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_2);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button GETbtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListBox ListBoxCustomers;
        private Label label2;
    }
}