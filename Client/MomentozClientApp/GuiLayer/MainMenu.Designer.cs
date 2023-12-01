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
            customerNameLabel = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            lastNameLabel = new Label();
            mobilePhoneLabel = new Label();
            EmailLabel = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(17, 545);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(134, 25);
            linkLabel2.TabIndex = 9;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Om Momentoz";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(853, 274);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 10;
            label1.Text = "Baggage:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(853, 165);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 11;
            label2.Text = "Afgang:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(853, 342);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 25);
            label4.TabIndex = 13;
            label4.Text = "Pris:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(17, 28);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(270, 54);
            label5.TabIndex = 15;
            label5.Text = "Destinationer:";
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(143, 38);
            label6.TabIndex = 49;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(853, 219);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(100, 25);
            label8.TabIndex = 24;
            label8.Text = "Retur billet:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(448, 412);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 25);
            label9.TabIndex = 27;
            label9.Text = "Valgt destination:";
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(17, 115);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 33);
            comboBox1.TabIndex = 30;
            comboBox1.SelectedIndexChanged += comboBox1_DropDown;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(978, 214);
            comboBox2.Margin = new Padding(4, 5, 4, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(141, 33);
            comboBox2.TabIndex = 25;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(978, 274);
            comboBox3.Margin = new Padding(4, 5, 4, 5);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(141, 33);
            comboBox3.TabIndex = 20;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1005, 165);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(76, 25);
            label10.TabIndex = 31;
            label10.Text = "Aalborg";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(597, 412);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(102, 25);
            label11.TabIndex = 33;
            label11.Text = "Destination";
            label11.Click += label11_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(917, 40);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 45);
            label3.TabIndex = 34;
            label3.Text = "Ordre:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1005, 342);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(23, 25);
            label12.TabIndex = 35;
            label12.Text = "X";
            label12.Click += label12_Click;
            // 
            // button1
            // 
            button1.Location = new Point(978, 500);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(141, 70);
            button1.TabIndex = 36;
            button1.Text = "Godkend";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(448, 165);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(80, 25);
            label13.TabIndex = 37;
            label13.Text = "Fornavn:";
            label13.TextAlign = ContentAlignment.TopCenter;
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Location = new Point(558, 165);
            customerNameLabel.Margin = new Padding(4, 0, 4, 0);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new Size(174, 25);
            customerNameLabel.TabIndex = 38;
            customerNameLabel.Text = "customerNameLabel";
            customerNameLabel.Click += label14_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(451, 225);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(90, 25);
            label15.TabIndex = 39;
            label15.Text = "Efternavn:";
            label15.TextAlign = ContentAlignment.TopCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(451, 280);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(62, 25);
            label16.TabIndex = 40;
            label16.Text = "Mobil:";
            label16.TextAlign = ContentAlignment.TopCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(451, 338);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(58, 25);
            label17.TabIndex = 41;
            label17.Text = "Email:";
            label17.TextAlign = ContentAlignment.TopCenter;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(558, 225);
            lastNameLabel.Margin = new Padding(4, 0, 4, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(86, 25);
            lastNameLabel.TabIndex = 43;
            lastNameLabel.Text = "Efternavn";
            lastNameLabel.Click += lastNameLabel_Click;
            // 
            // mobilePhoneLabel
            // 
            mobilePhoneLabel.AutoSize = true;
            mobilePhoneLabel.Location = new Point(558, 280);
            mobilePhoneLabel.Margin = new Padding(4, 0, 4, 0);
            mobilePhoneLabel.Name = "mobilePhoneLabel";
            mobilePhoneLabel.Size = new Size(77, 25);
            mobilePhoneLabel.TabIndex = 44;
            mobilePhoneLabel.Text = "Mobiloz";
            mobilePhoneLabel.Click += mobilePhoneLabel_Click;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(558, 338);
            EmailLabel.Margin = new Padding(4, 0, 4, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(54, 25);
            EmailLabel.TabIndex = 45;
            EmailLabel.Text = "Email";
            EmailLabel.Click += EmailLabel_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(480, 40);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(118, 45);
            label7.TabIndex = 50;
            label7.Text = "Kunde:";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 627);
            Controls.Add(label7);
            Controls.Add(EmailLabel);
            Controls.Add(mobilePhoneLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(customerNameLabel);
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
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel2);
            Margin = new Padding(4, 5, 4, 5);
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
        private Label label14;
        private Button button1;
        private Label label13;
        private Label customerNameLabel;
        private Label lastNameLabel;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label23;
        private ComboBox comboBox4;
        private Label label18;
        private Label mobilePhoneLabel;
        private Label EmailLabel;
    }
}