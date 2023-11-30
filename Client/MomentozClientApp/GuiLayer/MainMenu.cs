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
        
        private Timer flightRefreshTimer;
        private List<FlightDto> flightsData;
        private bool isDataLoaded = false;
        private double originalPrice;
        private double basePrice; // Basispris for flyvningen
        private double returnTicketCost; // Ekstra omkostning for returbillet
        private double baggageCost; // Ekstra omkostning for bagage

        public MainMenu(string customerId)
        {
            InitializeComponent();
            loggedInCustomerId = customerId; // Gem kunde-ID i en lokal variabel
            label7.Text = customerId; // Opdater et label eller anden brugergr�nsefladekomponent med kunde-ID'en
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
            LoadFlightsAsync();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            LoadCustomersAsync();
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            UpdateTotalPrice();


        }



    

    public MainMenu()
        {
        }

        private void UpdateUI()
        {
            label1.Text = loggedInCustomerId;
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
                await LoadFlightsAsync(); // Brug "await" for at vente p�, at LoadFlightsAsync er f�rdig.
                isDataLoaded = true; // S�t flaget til sandt, n�r data er indl�st f�rste gang
                flightRefreshTimer.Start();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = loggedInCustomerId;
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
                        flightsData = JsonConvert.DeserializeObject<List<FlightDto>>(flightData);

                        if (flightsData != null && flightsData.Any())
                        {
                            comboBox1.DisplayMember = "CustomDisplay";
                            comboBox1.ValueMember = "Id";
                            comboBox1.DataSource = flightsData;
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
        private async Task LoadCustomersAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.GetAsync("api/customers"); // Opdater URL'en til kundernes API-endepunkt.

                    if (response.IsSuccessStatusCode)
                    {
                        var customerData = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(customerData);

                        if (customers != null && customers.Any())
                        {
                            comboBox4.DisplayMember = "FullName"; // Erstat med den egenskab, du vil vise i dropdown for kunder.
                            comboBox4.ValueMember = "Id"; // Antages at dit CustomerDto har en 'Id' egenskab.
                            comboBox4.DataSource = customers;
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


        private void InitializeYesNoComboBox()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Ja");
            comboBox2.Items.Add("Nej");
            comboBox2.SelectedIndex = -1;
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
            if (comboBox3.SelectedItem != null)
            {
                string choice = comboBox3.SelectedItem.ToString();
                switch (choice)
                {
                    case "2kg":
                        baggageCost = 20;
                        break;
                    case "5kg":
                        baggageCost = 50;
                        break;
                    case "10kg":
                        baggageCost = 100;
                        break;
                    case "15kg":
                        baggageCost = 150;
                        break;
                    default:
                        baggageCost = 0;
                        break;
                }
            }
            else
            {
                baggageCost = 0;
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice(double additionalCosts)
        {
            // Antager at 'label12' er din prislabel.
            double totalPrice = basePrice + additionalCosts;
            label12.Text = $"Pris: {totalPrice:C}";
        }

        // Metode, der skal kaldes, n�r en flyvning v�lges for at s�tte basisprisen
        private void SetBasePrice(double price)
        {
            basePrice = price;
            // Opdater prisen p� UI med det samme for at reflektere basisprisen
            label12.Text = $"Pris: {basePrice:C}";
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
                        flightsData = JsonConvert.DeserializeObject<List<FlightDto>>(flightData);

                        if (flightsData != null && flightsData.Any())
                        {
                            // �ndr 'CustomDisplay' til det faktiske navn p� egenskaben for destinationens adresse.
                            comboBox1.DisplayMember = "DestinationAddress";
                            comboBox1.ValueMember = "Id";
                            comboBox1.DataSource = flightsData;
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
            if (comboBox1.SelectedItem != null)
            {
                var selectedFlight = (FlightDto)comboBox1.SelectedItem;
                // Tjek for null eller tom DestinationAddress
                if (!string.IsNullOrEmpty(selectedFlight.DestinationAddress))
                {
                    label11.Text = selectedFlight.DestinationAddress;
                }
                else
                {
                    label11.Text = "Ingen adresse tilg�ngelig";
                }
            }
            else
            {
                MessageBox.Show("Ingen flyvning er valgt.");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var selectedFlight = (FlightDto)comboBox1.SelectedItem;
                // Tjek for null eller tom DestinationAddress
                if (!string.IsNullOrEmpty(selectedFlight.DestinationAddress))
                {
                    label11.Text = selectedFlight.DestinationAddress;
                }
                else
                {
                    label11.Text = "Ingen adresse tilg�ngelig";
                }

                // Opdater ogs� prisen, n�r en anden flyvning v�lges
                basePrice = selectedFlight.Price;
                UpdateTotalPrice();
            }
            else
            {
                label11.Text = "Ingen flyvning er valgt.";
            }
        }


        private void UpdatePriceBasedOnSelections()
        {
            // Beregn den nye pris baseret p� valg af returbillet og andet.
            double additionalCosts = 0;
          

            // Tjek om der er valgt en returbillet og l�g den ekstra omkostning til.
            if (comboBox2.SelectedIndex != -1 && comboBox2.SelectedItem.ToString() == "Ja")
            {
                additionalCosts += 150; // Ekstra omkostning for returbillet.
            }

            // Opdater label med den nye pris.
            label12.Text = $"Pris: {originalPrice + additionalCosts:C}";
        }

        // Husk at opdatere comboBox2's SelectedIndexChanged event ogs�, hvis det p�virker prisen:
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string choice = comboBox2.SelectedItem.ToString();
                returnTicketCost = choice == "Ja" ? 150 : 0;
            }
            else
            {
                returnTicketCost = 0;
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            // Samlede pris er summen af basisprisen, returbilletten og bagageomkostningerne
            double totalPrice = basePrice + returnTicketCost + baggageCost;
            label12.Text = $"Pris: {totalPrice:C}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Saml kvitteringsoplysningerne
            string customerInfo = "Kundeoplysninger:\n";

            if (comboBox4.SelectedItem != null)
            {
                var selectedCustomer = (CustomerDto)comboBox4.SelectedItem;
                customerInfo += $"Fornavn: {selectedCustomer.FirstName}\n";
                customerInfo += $"Efternavn: {selectedCustomer.LastName}\n";
                customerInfo += $"Mobiltelefon: {selectedCustomer.MobilePhone}\n";
                customerInfo += $"Email: {selectedCustomer.Email}\n";
            }
            else
            {
                customerInfo += "Ingen kunde valgt\n";
            }

            string departure = "Afgang: Aalborg";
            string returnTicket = "Returbillet: ";
            double price = 0; // Initialiser prisen

            // Hent flyoplysninger og basispris
            if (comboBox1.SelectedItem != null)
            {
                var selectedFlight = (FlightDto)comboBox1.SelectedItem;
                price += selectedFlight.Price; // Start med basisprisen for den valgte flyvning.
            }
            else
            {
                label12.Text = "Ingen flyvning valgt";
                return; // Hvis ingen flyvning er valgt, afbryd og vis besked.
            }

            string destination = "Valgt destination: " + (comboBox1.SelectedItem as FlightDto)?.DestinationAddress ?? "Ingen";

            // Tjek for returbillet og opdater pris
            if (comboBox2.SelectedIndex != -1 && comboBox2.SelectedItem.ToString() == "Ja")
            {
                returnTicket += "Ja";
                price += 150; // Tilf�j ekstra omkostninger for returbillet.
            }
            else
            {
                returnTicket += comboBox2.SelectedIndex != -1 ? comboBox2.SelectedItem.ToString() : "Ingen valgt";
            }

            string baggage = "Bagage: ";
            double baggageCost = 0;

            if (comboBox3.SelectedIndex != -1)
            {
                string selectedBaggage = comboBox3.SelectedItem.ToString();
                switch (selectedBaggage)
                {
                    case "2kg":
                        baggageCost = 20;
                        break;
                    case "5kg":
                        baggageCost = 50;
                        break;
                    case "10kg":
                        baggageCost = 100;
                        break;
                    case "15kg":
                        baggageCost = 150;
                        break;
                    default:
                        break;
                }
            }

            price += baggageCost;
            baggage += baggageCost > 0 ? comboBox3.SelectedItem.ToString() : "Ingen valgt";

            // Format�r den opdaterede pris som en valuta
            string formattedPrice = string.Format("{0:C}", price);

            // Opret en kvitteringstekst med den opdaterede pris
            string receiptText = $"{customerInfo}\n{departure}\n{returnTicket}\n{baggage}\nPris: {formattedPrice}\n{destination}";

            // Vis kvitteringsmeddelelsen som en MessageBox
            MessageBox.Show(receiptText, "Kvittering", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "MomentoZ er et mindre sv�veflyudlejningsselskab med afgangslokationer fra Aalborg, der tilbydes rejsedestinationer til alle klodens kontinenter, med mulighed for at flyve retur efter behov, virksomheden er stiftet 11.november 2023";
            string caption = "Om MomentoZ";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            // Kommenter alt indholdet i denne metode ud, eller fjern metoden helt,
            // hvis det ikke er n�dvendigt at have en Click event p� prislappen.

            // Eksempel p� at kommentere koden ud:
            /*
            if (comboBox1.SelectedItem != null)
            {
                var selectedFlight = (FlightDto)comboBox1.SelectedItem;
                label12.Text = $"Pris: {selectedFlight.Price:C}";
            }
            */
        }



        private bool customersLoaded = false; // Denne variable holder styr p�, om kunde-data er blevet indl�st
        private string loggedInCustomerId;

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                var selectedCustomer = (CustomerDto)comboBox4.SelectedItem;
                label14.Text = $"{selectedCustomer.FirstName}";
                label19.Text = $" {selectedCustomer.LastName}";
                label20.Text = $" {selectedCustomer.MobilePhone}";
                label21.Text = $" {selectedCustomer.Email}";


            }
            else
            {
                label14.Text = "Ingen kunde valgt";
                label19.Text = "Ingen kunde valgt";
                label20.Text = "Ingen kunde valgt";
                label21.Text = "Ingen kunde valgt";
            }
        }


        private async void comboBox4_DropDown(object sender, EventArgs e)
        {
            // For at undg� at hente data flere gange, kan du have en boolsk flag til at kontrollere dette.
            if (customersLoaded) return;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114/");
                    var response = await httpClient.GetAsync("api/customers"); // Opdater URL'en til din customers API
                    if (response.IsSuccessStatusCode)
                    {
                        var customerData = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(customerData); // Erstat 'CustomerDto' med din faktiske customer DTO klasse

                        if (customers != null && customers.Any())
                        {
                            comboBox4.DisplayMember = "FullName"; // Erstat 'FullName' med den egenskab du vil vise i dropdown
                            comboBox4.ValueMember = "Id"; // Antager at dit CustomerDto har en 'Id' egenskab
                            comboBox4.DataSource = customers;
                            customersLoaded = true; // S�t din boolske flag til true, s� data ikke genindl�ses
                        }
                        else
                        {
                            MessageBox.Show("Ingen kunder blev fundet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fejl i hentning af kundeinformation fra API.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl ved hentning af kunder: {ex.Message}");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
  }
