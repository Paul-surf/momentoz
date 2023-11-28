using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.ServiceLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MomentozClientApp
{
    public partial class MainMenu : Form
    {
        private readonly CustomerAccess _customerAccess;
        private string loggedInUsername;

        public MainMenu(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            label7.Text = "                " + loggedInUsername;
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            InitializeFlightomboBox();
            // Binde event handleren til comboBox1's SelectedIndexChanged event

            // Call LoadFlightsAsync to fetch and populate flights
            //   LoadFlightsAsync();
        }

        private void UpdateUI()
        {
            // Vis brugernavnet i din form (f.eks. i en label)
            label1.Text = "                " + loggedInUsername;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = "                " + loggedInUsername;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeBagageWeightCombobox();
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private async void GETbtn_Click_1(object sender, EventArgs e)
        {
            string processText = "OK";
            List<Customer>? fetchedCustomers = await _customerAccess.GetCustomerAll();

            if (fetchedCustomers != null)
            {
                if (fetchedCustomers.Count >= 1)
                {
                    processText = "Ok";
                }
                else
                {
                    processText = "No persons found";
                }
            }
            else
            {
                processText = "Failure: An error occurred";
            }
            // label2.Text = processText;
            // ListBoxCustomers.DataSource = fetchedCustomers;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private async void InitializeFlightomboBox()
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync();
                isDataLoaded = true; // Sæt flaget til sandt, når data er indlæst første gang
            }
        }


        private bool isDataLoaded = true; // En flag til at spore om data allerede er indlæst

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync();
                isDataLoaded = true; // Sæt flaget til sandt, når data er indlæst første gang
            }
        }

        private async Task LoadFlightsAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114");
                    var flights = await httpClient.GetFromJsonAsync<List<FlightDto>>("api/flights");

                    if (flights != null && flights.Any())
                    {
                        comboBox1.DisplayMember = "CustomDisplay"; // Bruger en brugerdefineret tekst som DisplayMember
                        comboBox1.ValueMember = "Id";
                        comboBox1.DataSource = flights;
                        comboBox1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Ingen flights blev fundet.");
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

        private async void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114/"); // Erstat med den korrekte API-adresse
                    var response = await httpClient.GetAsync("api/customers"); // Erstat med den korrekte API-rute
                    if (response.IsSuccessStatusCode)
                    {
                        var customerData = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(customerData);

                        if (customers != null && customers.Any())
                        {
                            // Antager at 'FullName' er egenskaben, der indeholder kundens fulde navn.
                            comboBox4.DataSource = customers.Select(c => c.FullName).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Ingen kunder blev fundet.");
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
                MessageBox.Show($"Der opstod en fejl ved hentning af kunder: {ex.Message}");
            }
        }


    }
}
