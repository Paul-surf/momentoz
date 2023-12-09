namespace MomentozClientApp
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

      
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

 
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            LinkLabel = new LinkLabel();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            BaggageLabel = new Label();
            AfgangLabel = new Label();
            PrisLabel = new Label();
            Destinationer = new Label();
            label6 = new Label();
            ReturLabel = new Label();
            DestinationLabel = new Label();
            DestinationDropDown = new ComboBox();
            ReturValgDropDown = new ComboBox();
            BaggageDropDown = new ComboBox();
            AfgangsDestination = new Label();
            Destination = new Label();
            OrdreInfo = new Label();
            SamletPris = new Label();
            BestilKnap = new Button();
            ForNavnLabel = new Label();
            labelCustomerName = new Label();
            efterNavnLabel = new Label();
            MobileLabel = new Label();
            MailLabel = new Label();
            lastName = new Label();
            mobilePhone = new Label();
            email = new Label();
            KundeInfo = new Label();
            label1 = new Label();
            customerID = new Label();
            SuspendLayout();
            // 
            // LinkLabel
            // 
            LinkLabel.AutoSize = true;
            LinkLabel.Location = new Point(17, 545);
            LinkLabel.Margin = new Padding(4, 0, 4, 0);
            LinkLabel.Name = "LinkLabel";
            LinkLabel.Size = new Size(134, 25);
            LinkLabel.TabIndex = 9;
            LinkLabel.TabStop = true;
            LinkLabel.Text = "Om Momentoz";
            LinkLabel.LinkClicked += linkLabel2_LinkClicked;
            // 
            // BaggageLabel
            // 
            BaggageLabel.AutoSize = true;
            BaggageLabel.Location = new Point(853, 273);
            BaggageLabel.Margin = new Padding(4, 0, 4, 0);
            BaggageLabel.Name = "BaggageLabel";
            BaggageLabel.Size = new Size(86, 25);
            BaggageLabel.TabIndex = 10;
            BaggageLabel.Text = "Baggage:";
            // 
            // AfgangLabel
            // 
            AfgangLabel.AutoSize = true;
            AfgangLabel.Location = new Point(853, 165);
            AfgangLabel.Margin = new Padding(4, 0, 4, 0);
            AfgangLabel.Name = "AfgangLabel";
            AfgangLabel.Size = new Size(75, 25);
            AfgangLabel.TabIndex = 11;
            AfgangLabel.Text = "Afgang:";
            // 
            // PrisLabel
            // 
            PrisLabel.AutoSize = true;
            PrisLabel.Location = new Point(853, 342);
            PrisLabel.Margin = new Padding(4, 0, 4, 0);
            PrisLabel.Name = "PrisLabel";
            PrisLabel.Size = new Size(44, 25);
            PrisLabel.TabIndex = 13;
            PrisLabel.Text = "Pris:";
            // 
            // Destinationer
            // 
            Destinationer.AutoSize = true;
            Destinationer.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Destinationer.Location = new Point(17, 28);
            Destinationer.Margin = new Padding(4, 0, 4, 0);
            Destinationer.Name = "Destinationer";
            Destinationer.Size = new Size(270, 54);
            Destinationer.TabIndex = 15;
            Destinationer.Text = "Destinationer:";
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(143, 38);
            label6.TabIndex = 51;
            // 
            // ReturLabel
            // 
            ReturLabel.AutoSize = true;
            ReturLabel.Location = new Point(853, 218);
            ReturLabel.Margin = new Padding(4, 0, 4, 0);
            ReturLabel.Name = "ReturLabel";
            ReturLabel.Size = new Size(100, 25);
            ReturLabel.TabIndex = 24;
            ReturLabel.Text = "Retur billet:";
            // 
            // DestinationLabel
            // 
            DestinationLabel.AutoSize = true;
            DestinationLabel.Location = new Point(449, 412);
            DestinationLabel.Margin = new Padding(4, 0, 4, 0);
            DestinationLabel.Name = "DestinationLabel";
            DestinationLabel.Size = new Size(149, 25);
            DestinationLabel.TabIndex = 27;
            DestinationLabel.Text = "Valgt destination:";
            // 
            // DestinationDropDown
            // 
            DestinationDropDown.Location = new Point(17, 115);
            DestinationDropDown.Margin = new Padding(4, 5, 4, 5);
            DestinationDropDown.Name = "DestinationDropDown";
            DestinationDropDown.Size = new Size(258, 33);
            DestinationDropDown.TabIndex = 30;
            DestinationDropDown.SelectedIndexChanged += flightsDropDown;
            // 
            // ReturValgDropDown
            // 
            ReturValgDropDown.FormattingEnabled = true;
            ReturValgDropDown.Location = new Point(979, 213);
            ReturValgDropDown.Margin = new Padding(4, 5, 4, 5);
            ReturValgDropDown.Name = "ReturValgDropDown";
            ReturValgDropDown.Size = new Size(141, 33);
            ReturValgDropDown.TabIndex = 25;
            ReturValgDropDown.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // BaggageDropDown
            // 
            BaggageDropDown.FormattingEnabled = true;
            BaggageDropDown.Location = new Point(979, 273);
            BaggageDropDown.Margin = new Padding(4, 5, 4, 5);
            BaggageDropDown.Name = "BaggageDropDown";
            BaggageDropDown.Size = new Size(141, 33);
            BaggageDropDown.TabIndex = 20;
            BaggageDropDown.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // AfgangsDestination
            // 
            AfgangsDestination.AutoSize = true;
            AfgangsDestination.Location = new Point(1006, 165);
            AfgangsDestination.Margin = new Padding(4, 0, 4, 0);
            AfgangsDestination.Name = "AfgangsDestination";
            AfgangsDestination.Size = new Size(76, 25);
            AfgangsDestination.TabIndex = 31;
            AfgangsDestination.Text = "Aalborg";
            AfgangsDestination.Click += label10_Click;
            // 
            // Destination
            // 
            Destination.AutoSize = true;
            Destination.Location = new Point(597, 412);
            Destination.Margin = new Padding(4, 0, 4, 0);
            Destination.Name = "Destination";
            Destination.Size = new Size(102, 25);
            Destination.TabIndex = 33;
            Destination.Text = "Destination";
            Destination.Click += label11_Click;
            // 
            // OrdreInfo
            // 
            OrdreInfo.AutoSize = true;
            OrdreInfo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            OrdreInfo.Location = new Point(917, 40);
            OrdreInfo.Margin = new Padding(4, 0, 4, 0);
            OrdreInfo.Name = "OrdreInfo";
            OrdreInfo.Size = new Size(109, 45);
            OrdreInfo.TabIndex = 34;
            OrdreInfo.Text = "Ordre:";
            // 
            // SamletPris
            // 
            SamletPris.AutoSize = true;
            SamletPris.Location = new Point(1006, 342);
            SamletPris.Margin = new Padding(4, 0, 4, 0);
            SamletPris.Name = "SamletPris";
            SamletPris.Size = new Size(100, 25);
            SamletPris.TabIndex = 35;
            SamletPris.Text = "Samlet pris";
            // 
            // BestilKnap
            // 
            BestilKnap.Location = new Point(979, 500);
            BestilKnap.Margin = new Padding(4, 5, 4, 5);
            BestilKnap.Name = "BestilKnap";
            BestilKnap.Size = new Size(141, 70);
            BestilKnap.TabIndex = 36;
            BestilKnap.Text = "Bestil";
            BestilKnap.UseVisualStyleBackColor = true;
            BestilKnap.Click += GodkendOrdreKnap;
            // 
            // ForNavnLabel
            // 
            ForNavnLabel.AutoSize = true;
            ForNavnLabel.Location = new Point(449, 165);
            ForNavnLabel.Margin = new Padding(4, 0, 4, 0);
            ForNavnLabel.Name = "ForNavnLabel";
            ForNavnLabel.Size = new Size(80, 25);
            ForNavnLabel.TabIndex = 37;
            ForNavnLabel.Text = "Fornavn:";
            ForNavnLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.Location = new Point(559, 165);
            labelCustomerName.Margin = new Padding(4, 0, 4, 0);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(76, 25);
            labelCustomerName.TabIndex = 38;
            labelCustomerName.Text = "Fornavn";
            labelCustomerName.Click += forNavn;
            // 
            // efterNavnLabel
            // 
            efterNavnLabel.AutoSize = true;
            efterNavnLabel.Location = new Point(451, 225);
            efterNavnLabel.Margin = new Padding(4, 0, 4, 0);
            efterNavnLabel.Name = "efterNavnLabel";
            efterNavnLabel.Size = new Size(90, 25);
            efterNavnLabel.TabIndex = 39;
            efterNavnLabel.Text = "Efternavn:";
            efterNavnLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MobileLabel
            // 
            MobileLabel.AutoSize = true;
            MobileLabel.Location = new Point(451, 280);
            MobileLabel.Margin = new Padding(4, 0, 4, 0);
            MobileLabel.Name = "MobileLabel";
            MobileLabel.Size = new Size(62, 25);
            MobileLabel.TabIndex = 40;
            MobileLabel.Text = "Mobil:";
            MobileLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // MailLabel
            // 
            MailLabel.AutoSize = true;
            MailLabel.Location = new Point(451, 338);
            MailLabel.Margin = new Padding(4, 0, 4, 0);
            MailLabel.Name = "MailLabel";
            MailLabel.Size = new Size(58, 25);
            MailLabel.TabIndex = 41;
            MailLabel.Text = "Email:";
            MailLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lastName
            // 
            lastName.AutoSize = true;
            lastName.Location = new Point(559, 225);
            lastName.Margin = new Padding(4, 0, 4, 0);
            lastName.Name = "lastName";
            lastName.Size = new Size(86, 25);
            lastName.TabIndex = 43;
            lastName.Text = "Efternavn";
            lastName.Click += lastNameLabel_Click;
            // 
            // mobilePhone
            // 
            mobilePhone.AutoSize = true;
            mobilePhone.Location = new Point(559, 280);
            mobilePhone.Margin = new Padding(4, 0, 4, 0);
            mobilePhone.Name = "mobilePhone";
            mobilePhone.Size = new Size(77, 25);
            mobilePhone.TabIndex = 44;
            mobilePhone.Text = "Mobiloz";
            mobilePhone.Click += mobilePhoneLabel_Click;
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(559, 338);
            email.Margin = new Padding(4, 0, 4, 0);
            email.Name = "email";
            email.Size = new Size(54, 25);
            email.TabIndex = 45;
            email.Text = "Email";
            email.Click += EmailLabel_Click;
            // 
            // KundeInfo
            // 
            KundeInfo.AutoSize = true;
            KundeInfo.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KundeInfo.Location = new Point(480, 40);
            KundeInfo.Margin = new Padding(4, 0, 4, 0);
            KundeInfo.Name = "KundeInfo";
            KundeInfo.Size = new Size(118, 45);
            KundeInfo.TabIndex = 50;
            KundeInfo.Text = "Kunde:";
            // 
            // ID label
            // 
            label1.AutoSize = true;
            label1.Location = new Point(449, 123);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 25);
            label1.TabIndex = 52;
            label1.Text = "ID:";
            label1.TextAlign = ContentAlignment.TopCenter;
          
            customerID.AutoSize = true;
            customerID.Location = new Point(559, 123);
            customerID.Margin = new Padding(4, 0, 4, 0);
            customerID.Name = "label2";
            customerID.Size = new Size(30, 25);
            customerID.TabIndex = 53;
            customerID.Text = "ID";
            customerID.TextAlign = ContentAlignment.TopCenter;
            customerID.Click += CustomerIDLabel_Click;
            
            // MainMenu
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 627);
            Controls.Add(customerID);
            Controls.Add(label1);
            Controls.Add(KundeInfo);
            Controls.Add(email);
            Controls.Add(mobilePhone);
            Controls.Add(lastName);
            Controls.Add(MailLabel);
            Controls.Add(MobileLabel);
            Controls.Add(efterNavnLabel);
            Controls.Add(labelCustomerName);
            Controls.Add(ForNavnLabel);
            Controls.Add(BestilKnap);
            Controls.Add(SamletPris);
            Controls.Add(OrdreInfo);
            Controls.Add(Destination);
            Controls.Add(AfgangsDestination);
            Controls.Add(DestinationDropDown);
            Controls.Add(DestinationLabel);
            Controls.Add(ReturValgDropDown);
            Controls.Add(ReturLabel);
            Controls.Add(label6);
            Controls.Add(BaggageDropDown);
            Controls.Add(Destinationer);
            Controls.Add(PrisLabel);
            Controls.Add(AfgangLabel);
            Controls.Add(BaggageLabel);
            Controls.Add(LinkLabel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainMenu";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private LinkLabel LinkLabel;
        private Label BaggageLabel;
        private Label AfgangLabel;
        private Label PrisLabel;
        private Label Destinationer;
        private Label label6;
        private Label KundeInfo;
        private Label ReturLabel;
        private Label DestinationLabel;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox DestinationDropDown;
        private ComboBox ReturValgDropDown;
        private ComboBox BaggageDropDown;
        private Label AfgangsDestination;
        private Label Destination;
        private Label OrdreInfo;
        private Label SamletPris;
        private Label label14;
        private Button BestilKnap;
        private Label ForNavnLabel;
        private Label labelCustomerName;
        private Label lastName;
        private Label efterNavnLabel;
        private Label MobileLabel;
        private Label MailLabel;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label23;
        private ComboBox comboBox4;
        private Label label18;
        private Label mobilePhone;
        private Label email;
        private Label label1;
        private Label customerID;
    }
}