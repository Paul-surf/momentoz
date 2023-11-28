using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.ServiceLayer;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using Timer = System.Windows.Forms.Timer;


namespace MomentozClientApp
{
    public partial class MainMenu : Form
    {

        private readonly CustomerAccess _customerAccess;
        private string loggedInUsername;
        private Timer flightRefreshTimer;

        private bool isDataLoaded = false;

        public MainMenu(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            label7.Text = loggedInUsername;
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_DropDown);
            LoadFlightsAsync();
        }

        public MainMenu()
        {
        }

        private void UpdateUI()
        {
            label1.Text = loggedInUsername;
        }

        private async void flightRefreshTimer_Tick(object sender, EventArgs e)
        {

            comboBox1.Enabled = false;
            await LoadFlightsAsync();

            comboBox1.Enabled = true;
        }
        private async void MainMenu_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync(); // Brug "await" for at vente på, at LoadFlightsAsync er færdig.
                isDataLoaded = true; // Sæt flaget til sandt, når data er indlæst første gang
                flightRefreshTimer.Start();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = loggedInUsername;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeBagageWeightCombobox();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync();
                isDataLoaded = true;
                flightRefreshTimer.Start();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }




        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (flightRefreshTimer != null)
            {
                flightRefreshTimer.Stop();
                flightRefreshTimer.Dispose();
            }
        }
        private async Task LoadFlightsAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114");

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.GetAsync("api/flights");

                    if (response.IsSuccessStatusCode)
                    {
                        var flightData = await response.Content.ReadAsStringAsync();
                        var flights = JsonConvert.DeserializeObject<List<FlightDto>>(flightData);

                        if (flights != null && flights.Any())
                        {
                            comboBox1.DisplayMember = "CustomDisplay";
                            comboBox1.ValueMember = "Id";
                            comboBox1.DataSource = flights;
                        }
                        else
                        {
                            MessageBox.Show("Ingen flights blev fundet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fejl i hentning fra API.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl ved hentning af flights: {ex.Message}");
            }
        }
        private void InitializeYesNoComboBox()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Ja");
            comboBox2.Items.Add("Nej");
            comboBox2.SelectedIndex = -1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                string choice = comboBox2.SelectedItem.ToString();
                MessageBox.Show("Du har valgt: " + choice);
            }
        }

        private void InitializeBagageWeightCombobox()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("2kg");
            comboBox3.Items.Add("5kg");
            comboBox3.Items.Add("10kg");
            comboBox3.Items.Add("15kg");
            comboBox3.SelectedIndex = -1;
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                string choice = comboBox3.SelectedItem.ToString();
                MessageBox.Show("Du har valgt: " + choice);
            }
        }
        private bool flightsLoaded = false;

        private async void comboBox1_DropDown(object sender, EventArgs e)
        {

            if (flightsLoaded) return;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114/");
                    var response = await httpClient.GetAsync("api/flights");
                    if (response.IsSuccessStatusCode)
                    {
                        var flightData = await response.Content.ReadAsStringAsync();
                        var flights = JsonConvert.DeserializeObject<List<FlightDto>>(flightData);

                        if (flights != null && flights.Any())
                        {
                            comboBox1.DisplayMember = "CustomDisplay";
                            comboBox1.ValueMember = "Id";
                            comboBox1.DataSource = flights;
                            flightsLoaded = true;
                        }
                        else
                        {
                            MessageBox.Show("Ingen flyvninger blev fundet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fejl i hentning fra API.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl ved hentning af flyvninger: {ex.Message}");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label10.Text = "Aalborg";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Saml kvitteringsoplysningerne
            string customer = "Kunde: John Doe";
            string departure = "Afgang: Aalborg";
            string returnTicket = "Returbillet: " + (comboBox2.SelectedIndex != -1 ? comboBox2.SelectedItem.ToString() : "Ingen valgt");
            string baggage = "Bagage: " + (comboBox3.SelectedIndex != -1 ? comboBox3.SelectedItem.ToString() : "Ingen valgt");
            string price = "Pris: $100";
            string destination = "Valgt destination: New York";

            // Opret en kvitteringstekst
            string receiptText = $"{customer}\n{departure}\n{returnTicket}\n{baggage}\n{price}\n{destination}";

            // Vis kvitteringsmeddelelsen som en MessageBox
            MessageBox.Show(receiptText, "Kvittering", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "MomentoZ er et mindre svæveflyudlejningsselskab med afgangslokationer fra Aalborg, der tilbydes rejsedestinationer til alle klodens kontinenter, med mulighed for at flyve retur efter behov, virksomheden er stiftet 11.november 2023";
            string caption = "Om MomentoZ";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }

    }
}
