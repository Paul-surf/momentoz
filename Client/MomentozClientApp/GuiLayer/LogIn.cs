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

            // Opret en instans af CustomerAccess-klassen, som bruges til at få adgang til kundeoplysninger.
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
            button1.Click += LoginKnap;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 48);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "KundeID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // LogIn
            // 
            ClientSize = new Size(294, 166);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LogIn";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        // Denne metode bliver kaldt, når brugeren klikker på login-knappen.
        private async void LoginKnap(object sender, EventArgs e)
        {
            var customerId = textBox1.Text;

            try
            {
                // Konverter customerId til en integer
                if (int.TryParse(customerId, out int id) && await IsValidCustomerId(id))
                {
                    // Skjuler login-formularen.
                    Hide();

                    // Opretter MainMenu-formularen og overfører den validerede kunde.
                    var customer = await _customerAccess.GetCustomerById(id);
                    if (customer != null) 
                    {
                        var mainMenu = new MainMenu(customer);
                        mainMenu.Closed += (s, args) => Close(); // Lukker login-formularen, når MainMenu lukkes
                        mainMenu.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Login mislykkedes. Kontroller venligst din kunde-ID.", "Login mislykkedes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Der opstod en fejl ved forbindelsen til serveren. Tjek din internetforbindelse og prøv igen senere.", "Forbindelsesfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en ukendt fejl: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Denne metode validerer kunde-ID.
        private async Task<bool> IsValidCustomerId(int customerId)
        {
            if (customerId <= 0)
            {
                MessageBox.Show("Kunde-ID skal være et positivt heltal.", "Ugyldig indtastning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // Forsøger at hente kundeoplysninger baseret på kunde-ID.
                var customer = await _customerAccess.GetCustomerById(customerId);
                return customer != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der opstod en fejl under verifikation af kunde-ID. Prøv igen senere.", "Login-fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Der opstod en fejl under adgang til databasen: {ex.Message}");
                return false;
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
