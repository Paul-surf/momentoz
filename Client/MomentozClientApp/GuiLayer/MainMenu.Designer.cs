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
            linkLabel2 = new LinkLabel();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label3 = new Label();
            label12 = new Label();
            button1 = new Button();
            SuspendLayout();
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
            label1.Size = new Size(56, 15);
            label1.TabIndex = 10;
            label1.Text = "Baggage:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(605, 107);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 11;
            label2.Text = "Afgang:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(614, 213);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 13;
            label4.Text = "Pris:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(234, 23);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 15;
            label5.Text = "Destinationer:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(607, 77);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 22;
            label6.Text = "Kunde:";
            label6.TextAlign = ContentAlignment.TopCenter;
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(685, 77);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 23;
            label7.Text = "Customer";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(598, 139);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 24;
            label8.Text = "Retur billet:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(477, 257);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 27;
            label9.Text = "Valgt destination:";
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(12, 69);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(560, 23);
            comboBox1.TabIndex = 30;
            comboBox1.SelectedIndexChanged += comboBox1_DropDown;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(685, 136);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(100, 23);
            comboBox2.TabIndex = 25;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(685, 172);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(100, 23);
            comboBox3.TabIndex = 20;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(685, 107);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 31;
            label10.Text = "Aalborg";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(637, 257);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 33;
            label11.Text = "Destination";
            label11.Click += label11_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(664, 36);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 34;
            label3.Text = "Ordre:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(654, 213);
            label12.Name = "label12";
            label12.Size = new Size(154, 15);
            label12.TabIndex = 35;
            label12.Text = "pris fra indtastet destination";
            // 
            // button1
            // 
            button1.Location = new Point(704, 317);
            button1.Name = "button1";
            button1.Size = new Size(81, 35);
            button1.TabIndex = 36;
            button1.Text = "Godkend";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 376);
            Controls.Add(button1);
            Controls.Add(label12);
            Controls.Add(label3);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(comboBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel2);
            Name = "MainMenu";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private LinkLabel linkLabel2;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label10;
        private Label label11;
        private Label label3;
        private Label label12;
        private Button button1;
    }
}