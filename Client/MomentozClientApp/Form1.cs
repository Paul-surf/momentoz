using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MomentozClientApp
{
    public partial class Form1 : Form
    {
        private const string BaseUrl = "https://localhost:5114/api/";
        private const string Endpoint = "customers";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void GETbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Concatenate the base URL and endpoint
                    string apiUrl = $"{BaseUrl}{Endpoint}";

                    // Make a GET request to the API endpoint
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response content
                        string content = await response.Content.ReadAsStringAsync();
                        
                        // Update the panel with the retrieved information
                        UpdatePanel(content);
                    }
                    else
                    {
                        // Display the error status code
                        MessageBox.Show($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }
        private void UpdatePanel(string content)
        {
            // Clear existing controls in the panel
            panel1.Controls.Clear();

            // Create a label to display the retrieved information
            Label label = new Label
            {
                Text = content,
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            // Add the label to the panel
            panel1.Controls.Add(label);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}