using MomentozClientApp.ServiceLayer;
using System.Diagnostics;

namespace MomentozClientApp.GuiLayer
{
    public partial class LogIn : Form
    {
        private readonly CustomerAccess _customerAccess;
        private Button button1;
        private Label label1;
        private TextBox textBox1;



        public LogIn()
        {
            InitializeComponent();
            _customerAccess = new CustomerAccess();
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
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
            label1.Location = new Point(30, 48);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "KundeID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // LogIn
            // 
            ClientSize = new Size(294, 166);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LogIn";
            Text = "Momentoz";
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var customerId = textBox1.Text; // Antager at brugeren indtaster kunde-ID her.

            if (IsValidCustomerId(customerId))
            {
                // Kunde-ID er gyldigt, og brugeren bliver logget ind.
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();

                // Opret MainMenu formen og overfør kunde-ID'et.
                var mainMenu = new MainMenu(customerId);
                mainMenu.Closed += (s, args) => Close();
                mainMenu.Show();
            }
            else
            {
                // Kunde-ID er ikke gyldigt, vis en fejlmeddelelse.
                MessageBox.Show("Login failed. Please check your customer ID.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidCustomerId(string customerId)
        {
            // Tjek først for tomme eller kun-whitespace værdier.
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return false;
            }

            int id;
            if (!int.TryParse(customerId, out id))
            {
                // Hvis ID'et ikke kan parses til en int, er det ugyldigt.
                return false;
            }

            try
            {
                var customer = _customerAccess.GetCustomerById(id);
                // Hvis kunden ikke findes, skal GetCustomerById returnere null.
                return customer != null;
            }
            catch (Exception ex)
            {
                // Log exception (i en reel applikation, log til en fil eller fejllogningssystem)
                Debug.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }





        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}

