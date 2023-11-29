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
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            button2 = new Button();
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
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
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
            label2.Location = new Point(598, 107);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 11;
            label2.Text = "Afgang:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(598, 213);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 13;
            label4.Text = "Pris:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(80, 18);
            label5.Name = "label5";
            label5.Size = new Size(182, 37);
            label5.TabIndex = 15;
            label5.Text = "Destinationer:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(409, 107);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 22;
            label6.Text = "Brugernavn:";
            label6.TextAlign = ContentAlignment.TopCenter;
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(486, 107);
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
            label9.Location = new Point(449, 292);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 27;
            label9.Text = "Valgt destination:";
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(12, 69);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(302, 23);
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
            label10.Location = new Point(704, 107);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 31;
            label10.Text = "Aalborg";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(685, 292);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 33;
            label11.Text = "Destination";
            label11.Click += label11_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(578, 24);
            label3.Name = "label3";
            label3.Size = new Size(76, 30);
            label3.TabIndex = 34;
            label3.Text = "Ordre:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(704, 213);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 35;
            label12.Text = "X";
            // 
            // button1
            // 
            button1.Location = new Point(704, 327);
            button1.Name = "button1";
            button1.Size = new Size(81, 35);
            button1.TabIndex = 36;
            button1.Text = "Godkend";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(409, 142);
            label13.Name = "label13";
            label13.Size = new Size(53, 15);
            label13.TabIndex = 37;
            label13.Text = "Fornavn:";
            label13.TextAlign = ContentAlignment.TopCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(486, 142);
            label14.Name = "label14";
            label14.Size = new Size(30, 15);
            label14.TabIndex = 38;
            label14.Text = "Tom";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(409, 174);
            label15.Name = "label15";
            label15.Size = new Size(60, 15);
            label15.TabIndex = 39;
            label15.Text = "Efternavn:";
            label15.TextAlign = ContentAlignment.TopCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(409, 207);
            label16.Name = "label16";
            label16.Size = new Size(41, 15);
            label16.TabIndex = 40;
            label16.Text = "Mobil:";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(409, 235);
            label17.Name = "label17";
            label17.Size = new Size(39, 15);
            label17.TabIndex = 41;
            label17.Text = "Email:";
            label17.TextAlign = ContentAlignment.TopCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(409, 261);
            label18.Name = "label18";
            label18.Size = new Size(44, 15);
            label18.TabIndex = 42;
            label18.Text = "UserID:";
            label18.TextAlign = ContentAlignment.TopCenter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(486, 175);
            label19.Name = "label19";
            label19.Size = new Size(30, 15);
            label19.TabIndex = 43;
            label19.Text = "Tom";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(486, 207);
            label20.Name = "label20";
            label20.Size = new Size(30, 15);
            label20.TabIndex = 44;
            label20.Text = "Tom";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(486, 235);
            label21.Name = "label21";
            label21.Size = new Size(30, 15);
            label21.TabIndex = 45;
            label21.Text = "Tom";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(486, 261);
            label22.Name = "label22";
            label22.Size = new Size(30, 15);
            label22.TabIndex = 46;
            label22.Text = "Tom";
            // 
            // button2
            // 
            button2.Location = new Point(320, 69);
            button2.Name = "button2";
            button2.Size = new Size(72, 23);
            button2.TabIndex = 47;
            button2.Text = "Vælg";
            button2.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 376);
            Controls.Add(button2);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
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
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Button button2;
    }
}