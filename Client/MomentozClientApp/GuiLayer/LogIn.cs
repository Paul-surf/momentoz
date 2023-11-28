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
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(37, 122);
            button2.Name = "button2";
            button2.Size = new Size(91, 23);
            button2.TabIndex = 5;
            button2.Text = "Opret bruger";
            button2.UseVisualStyleBackColor = true;
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






        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = maskedTextBox1.Text;

            bool isValidUser = _customerAccess.ValidateLogin(username, password);

            if (isValidUser)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();

                var mainForm = new MainMenu(username);
                mainForm.Closed += (s, args) => Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Task<bool> ValidateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}

