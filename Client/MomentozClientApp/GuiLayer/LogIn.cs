

using MomentozClientApp.ServiceLayer;

namespace MomentozClientApp.GuiLayer
{
    public partial class LogIn : Form
    {
        private readonly CustomerAccess _customerAccess;
        private Button button1;
        private Label label1;
        private Label label2;
        private MaskedTextBox maskedTextBox1;
        // This might be in your Login.Designer.cs file
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;


        public LogIn()
        {
            InitializeComponent();
            _customerAccess = new CustomerAccess();
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


        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = maskedTextBox1.Text; // Assuming the password is in the maskedTextBox

            // Validate the credentials through the CustomerController
            bool isValidUser = _customerAccess.ValidateLogin(username, password);

            if (isValidUser)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide the login form
                Hide();

                // Create a new instance of MainMenu form, passing the username as an argument
                var mainForm = new MainMenu(username); // Pass the username to the MainMenu form
                mainForm.Closed += (s, args) => Close();
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

        /*   private void button2_Click(object sender, EventArgs e)
           {
               var username = textBoxUsername.Text;
               var password = textBoxPassword.Text;

               if (username == "BigBoss" && password == "1234")
               {
                   MessageBox.Show("Du er nu logget ind som BigBoss.", "Velkommen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   // Her kan du lukke login-formen og åbne hovedformen
                   this.Close();
                   MainMenu mainForm = new MainMenu();
                    mainForm.Show();
               }
               else
               {
                   MessageBox.Show("Ugyldigt brugernavn eller adgangskode.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           */
        private async void button2_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = maskedTextBox1.Text;

            bool isValidUser = await ValidateLogin(username, password);

            if (isValidUser)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Åbn hovedskærmen med brugeroplysninger
                var mainForm = new MainMenu(username); // Send brugernavn som parameter til hovedskærmen
                Hide();
                mainForm.Closed += (s, args) => Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       // User
        private Task<bool> ValidateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }


        // ... Resten af din kode ...
    }
}

