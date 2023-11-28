using MomentozClientApp.DTOs;
using MomentozClientApp.Model;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.ServiceLayer;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;


namespace MomentozClientApp
{
    public partial class MainMenu : Form
    {
        private readonly CustomerAccess _customerAccess;
        private string loggedInUsername;
        private Timer flightRefreshTimer;

        private bool isDataLoaded = false; // En flag til at spore om data allerede er indlæst

        public MainMenu(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            label7.Text =  loggedInUsername;
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);

            // Binde event handleren til comboBox1's SelectedIndexChanged event

            // Call LoadFlightsAsync to fetch and populate flights
            //   LoadFlightsAsync();
        }

        private void UpdateUI()
        {
            // Vis brugernavnet i din form (f.eks. i en label)
            label1.Text =  loggedInUsername;
        }

        private async void flightRefreshTimer_Tick(object sender, EventArgs e)
        {
            // Deaktiver comboBox1 for at forhindre flere anmodninger, indtil data er indlæst
            comboBox1.Enabled = false;
            await LoadFlightsAsync();
            // Aktivér comboBox1 igen, når data er indlæst
            comboBox1.Enabled = true;
        }


        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text =  loggedInUsername;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeBagageWeightCombobox();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync(); // Brug "await" for at vente på, at LoadFlightsAsync er færdig.
                isDataLoaded = true; // Sæt flaget til sandt, når data er indlæst første gang
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
                    // Det er en god praksis at sætte BaseAddress i HttpClient-konstruktøren eller inden det bruges.
                    httpClient.BaseAddress = new Uri("https://localhost:5114");

                    // Du kan også tilføje accept header for at sikre, at du forventer JSON
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



        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eller hvis du har et specifikt felt i dit dataobjekt, du vil vise:
            // ordreRubrik.Text = ((FlightDto)comboBox1.SelectedItem).SomeProperty;

            try
            {
                // Her opdateres ComboBox-navnet til comboBox1
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114/"); // Erstat med den korrekte API-adresse
                    var response = await httpClient.GetAsync("api/flights"); // Erstat med den korrekte API-rute
                    if (response.IsSuccessStatusCode)
                    {
                        var flightData = await response.Content.ReadAsStringAsync();
                        var flights = JsonConvert.DeserializeObject<List<FlightDto>>(flightData);

                        if (flights != null && flights.Any())
                        {
                            // Antager at 'CustomDisplay' er egenskaben, der indeholder flyets displayværdi.
                            comboBox1.DataSource = flights.Select(f => f.CustomDisplay).ToList();
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
    }
}
