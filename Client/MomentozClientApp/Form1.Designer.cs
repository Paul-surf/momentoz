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
            label1 = new Label();
            GETbtn = new Button();
            Navn = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            textBox2 = new TextBox();
            AgeLabel = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Client";
            label1.Click += label1_Click;
            // 
            // GETbtn
            // 
            GETbtn.Location = new Point(355, 278);
            GETbtn.Name = "GETbtn";
            GETbtn.Size = new Size(58, 28);
            GETbtn.TabIndex = 1;
            GETbtn.Text = "Search";
            GETbtn.UseVisualStyleBackColor = true;
            GETbtn.Click += GETbtn_Click;
            // 
            // Navn
            // 
            Navn.AutoSize = true;
            Navn.Location = new Point(355, 21);
            Navn.Name = "Navn";
            Navn.Size = new Size(38, 15);
            Navn.TabIndex = 3;
            Navn.Text = "Navn:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(355, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(355, 97);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 7;
            label5.Text = "Fra:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(355, 126);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 11;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(355, 215);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(355, 186);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 12;
            label3.Text = "Til:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(489, 47);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 15;
            // 
            // AgeLabel
            // 
            AgeLabel.AutoSize = true;
            AgeLabel.Location = new Point(489, 21);
            AgeLabel.Name = "AgeLabel";
            AgeLabel.Size = new Size(31, 15);
            AgeLabel.TabIndex = 14;
            AgeLabel.Text = "Age:";
            // 
            // panel1
            // 
            panel1.Location = new Point(102, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(181, 197);
            panel1.TabIndex = 16;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 351);
            Controls.Add(panel1);
            Controls.Add(textBox2);
            Controls.Add(AgeLabel);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(Navn);
            Controls.Add(GETbtn);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button GETbtn;
        private Label Navn;
        private TextBox textBox1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private TextBox textBox2;
        private Label AgeLabel;
        private Panel panel1;
    }
}