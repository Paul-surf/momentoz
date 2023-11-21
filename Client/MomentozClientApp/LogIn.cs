using MomentozClientApp.Controller;

namespace MomentozClientApp
{
    public partial class LogIn : Form
    {
        private readonly CustomerController _customerController;
        private Button button1;
        private Label label1;
        private Label label2;
        private MaskedTextBox maskedTextBox1;

        public LogIn()
        {
            InitializeComponent();
            _customerController = new CustomerController();
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(155, 122);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 43);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "Brugernavn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 84);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Kodeord:";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(130, 81);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(100, 23);
            maskedTextBox1.TabIndex = 3;
            maskedTextBox1.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(37, 122);
            button2.Name = "button2";
            button2.Size = new Size(91, 23);
            button2.TabIndex = 5;
            button2.Text = "Opret bruger";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LogIn
            // 
            ClientSize = new Size(294, 166);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(maskedTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LogIn";
            Text = "Momentoz";
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Button button2;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = maskedTextBox1.Text; // Assuming the password is in the maskedTextBox

            // Validate the credentials through the CustomerController
            bool isValidUser = await _customerController.ValidateLogin(username, password);

            // Rest of the code remains the same...



            if (isValidUser)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Assuming you want to close the login form and show the main form
                this.Hide();
                var mainForm = new MainMenu(); // MainForm should be the form you want to show after login
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Her antager vi, at du bruger de samme textBox1 og maskedTextBox1 til at indsamle brugernavn og adgangskode.
            // I et rigtigt program vil du sandsynligvis have separate inputfelter for "Opret bruger" funktionen.
            var newUsername = textBox1.Text;
            var newPassword = maskedTextBox1.Text;

            // Valider input (grundlæggende eksempel, skal udvides med mere robust validering)
            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Brugernavn og adgangskode må ikke være tomme.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Opret den nye bruger (asynkron kald, antager metoden eksisterer i CustomerController)
            var creationResult = await _customerController.CreateCustomer(newUsername, newPassword);

            // Håndter resultatet af brugeroprettelsen
            if (creationResult)
            {
                MessageBox.Show("Bruger oprettet!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fejl ved oprettelse af bruger. Prøv igen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ... Resten af din kode ...
    }
}

