namespace MomentozClientApp
{
    partial class MainMenu
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            comboBox3 = new ComboBox();
            button1 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            label9 = new Label();
            comboBox4 = new ComboBox();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(715, 9);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(37, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Ordre";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(12, 327);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(88, 15);
            linkLabel2.TabIndex = 9;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Om Momentoz";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(598, 172);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 10;
            label1.Text = "Baggage";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(605, 72);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 11;
            label2.Text = "Afgang";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(598, 131);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 12;
            label3.Text = "Destination";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(614, 213);
            label4.Name = "label4";
            label4.Size = new Size(26, 15);
            label4.TabIndex = 13;
            label4.Text = "Pris";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(234, 23);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 15;
            label5.Text = "Destinationer";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(683, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(685, 128);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 17;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(685, 210);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 19;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(685, 169);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(100, 23);
            comboBox3.TabIndex = 20;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(654, 305);
            button1.Name = "button1";
            button1.Size = new Size(131, 37);
            button1.TabIndex = 21;
            button1.Text = "Godkend";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(587, 38);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 22;
            label6.Text = "Kunde:";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(637, 38);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 23;
            label7.Text = "Customer";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(598, 102);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 24;
            label8.Text = "Retur billet";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(683, 99);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(100, 23);
            comboBox2.TabIndex = 25;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(12, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(547, 23);
            comboBox1.TabIndex = 29;
            comboBox1.SelectedIndexChanged += Form1_Load;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(686, 254);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(585, 257);
            label9.Name = "label9";
            label9.Size = new Size(95, 15);
            label9.TabIndex = 27;
            label9.Text = "Valgt destination";
            // 
            // comboBox4
            // 
            comboBox4.Location = new Point(12, 205);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(547, 23);
            comboBox4.TabIndex = 30;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 376);
            Controls.Add(comboBox4);
            Controls.Add(textBox5);
            Controls.Add(label9);
            Controls.Add(comboBox1);
            Controls.Add(comboBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Name = "MainMenu";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private ComboBox comboBox3;
        private Button button1;
        private Label label6;
        private Label label7;
        private TextBox textBox3;
        private Label label8;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox textBox5;
        private Label label9;
        private ComboBox comboBox4;
    }
}