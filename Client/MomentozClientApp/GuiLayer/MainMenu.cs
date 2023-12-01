using MomentozClientApp.Model;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.ServiceLayer;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Timer = System.Windows.Forms.Timer;


namespace MomentozClientApp
{
    public partial class MainMenu : Form
    {
        private readonly CustomerAccess _customerAccess;
        private Timer flightRefreshTimer;
        private List<Flight> flightsData;
        private bool isDataLoaded = false;
        private double originalPrice;
        private double basePrice; // Basispris for flyvningen
        private double returnTicketCost; // Ekstra omkostning for returbillet
        private double baggageCost; // Ekstra omkostning for bagage
        private bool customersLoaded = false; // Denne variable holder styr på, om kunde-data er blevet indlæst
        private bool flightsLoaded = false;
        private readonly string _customerId;
        private Customer loggedInCustomer;
        //   private Customer _customer;
        string departure = "Afgang: Aalborg";
        string returnTicket = "Returbillet: ";
        double price = 0; // Initialiser prisen
        public MainMenu(Customer customer)
        {
            InitializeComponent();
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
            LoadFlightsAsync();
            LoadCustomersAsync();
            UpdateTotalPrice();
            DestinationDropDown.DropDown += comboBox1_DropDown;
            ReturValgDropDown.DropDown += comboBox2_DropDown;
            BaggageDropDown.DropDown += comboBox3_DropDown;
            DestinationDropDown.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            UpdateCustomerInfo(customer.FirstName, customer.LastName, customer.MobilePhone, customer.Email);
        }

        public MainMenu()
        {
        }
        public void SetLoggedInCustomer(Customer customer)
        {
            loggedInCustomer = customer;
        }


        private void InitializeYesNoComboBox()
        {
            ReturValgDropDown.Items.Clear();
            ReturValgDropDown.Items.Add("Ja");
            ReturValgDropDown.Items.Add("Nej");
            ReturValgDropDown.SelectedIndex = -1;
        }

        private void InitializeBagageWeightCombobox()
        {
            BaggageDropDown.Items.Clear();
            BaggageDropDown.Items.Add("0kg");
            BaggageDropDown.Items.Add("1kg");
            BaggageDropDown.Items.Add("2kg");
            BaggageDropDown.Items.Add("5kg");
            BaggageDropDown.Items.Add("10kg");
            BaggageDropDown.Items.Add("15kg");
            BaggageDropDown.SelectedIndex = -1;
        }

        public void UpdateCustomerInfo(string firstName, string lastName, string mobilePhone, string email)
        {
            Fornavn.Text = firstName;
            this.lastName.Text = lastName;
            this.mobilePhone.Text = mobilePhone;
            Email.Text = email;
        }

        private void UpdateTotalPrice(double additionalCosts)
        {
            // Antager at 'label12' er din prislabel.
            double totalPrice = basePrice + additionalCosts;
            SamletPris.Text = $"Pris: {totalPrice:C}";
        }

        private async void flightRefreshTimer_Tick(object sender, EventArgs e)
        {

            DestinationDropDown.Enabled = false;
            await LoadFlightsAsync();

            DestinationDropDown.Enabled = true;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!isDataLoaded)
            {
                await LoadFlightsAsync();
                isDataLoaded = true;
                flightRefreshTimer.Start();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            InitializeBagageWeightCombobox();
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

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:5114");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("api/flights");

                if (response.IsSuccessStatusCode)
                {
                    var flightData = await response.Content.ReadAsStringAsync();
                    flightsData = JsonConvert.DeserializeObject<List<Flight>>(flightData);

                    if (flightsData != null && flightsData.Any())
                    {
                        DestinationDropDown.DisplayMember = "CustomDisplay";
                        DestinationDropDown.ValueMember = "Id";
                        DestinationDropDown.DataSource = flightsData;
                    }
                    else
                    {
                        MessageBox.Show("Ingen flights blev fundet.");
                    }
                }
            }
        }
        private async Task LoadCustomersAsync()
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
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);

                    if (customers != null && customers.Any())
                    {
                        //    // label14_Click.DisplayMember = "FullName"; // Erstat med den egenskab, du vil vise i dropdown for kunder.
                        //      comboBox4.ValueMember = "Id"; // Antages at dit CustomerDto har en 'Id' egenskab.
                        //    comboBox4.DataSource = customers;
                    }
                    else
                    {
                        MessageBox.Show("Ingen kunder blev fundet.");
                    }
                }
            }
        }
        private async void comboBox1_DropDown(object sender, EventArgs e)
        {

            //   LoadFlightsAsync();

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
                        flightsData = JsonConvert.DeserializeObject<List<Flight>>(flightData);

                        if (flightsData != null && flightsData.Any())
                        {
                            // Ændr 'CustomDisplay' til det faktiske navn på egenskaben for destinationens adresse.
                            DestinationDropDown.DisplayMember = "DestinationAddress";
                            DestinationDropDown.ValueMember = "Id";
                            DestinationDropDown.DataSource = flightsData;
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
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            // Opdater returbilletten ved dropdown
            UpdateTotalPrice();
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            // Opdater bagageomkostningerne ved dropdown
            UpdateTotalPrice(baggageCost);
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DestinationDropDown.SelectedItem != null)
            {
                var selectedFlight = (Flight)DestinationDropDown.SelectedItem;
                // Tjek for null eller tom DestinationAddress
                if (!string.IsNullOrEmpty(selectedFlight.DestinationAddress))
                {
                    Destination.Text = selectedFlight.DestinationAddress;
                }
                else
                {
                    Destination.Text = "Ingen adresse tilgængelig";
                }

                // Opdater også prisen, når en anden flyvning vælges
                basePrice = selectedFlight.Price;
                UpdateTotalPrice();
            }
            else
            {
                Destination.Text = "Ingen flyvning er valgt.";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReturValgDropDown.SelectedItem != null)
            {
                string choice = ReturValgDropDown.SelectedItem.ToString();
                returnTicketCost = choice == "Ja" ? 150 : 0;
            }
            else
            {
                returnTicketCost = 0;
            }

            UpdateTotalPrice();
        }
        private void UpdatePriceBasedOnSelections()
        {
            // Beregn den nye pris baseret på valg af returbillet og andet.
            double additionalCosts = 0;


            // Tjek om der er valgt en returbillet og læg den ekstra omkostning til.
            if (ReturValgDropDown.SelectedIndex != -1 && ReturValgDropDown.SelectedItem.ToString() == "Ja")
            {
                additionalCosts += 150; // Ekstra omkostning for returbillet.
            }

            // Opdater label med den nye pris.
            SamletPris.Text = $"Pris: {originalPrice + additionalCosts:C}";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BaggageDropDown.SelectedItem != null)
            {
                string choice = BaggageDropDown.SelectedItem.ToString();
                switch (choice)
                {
                    case "0kg":
                        baggageCost = 0;
                        break;
                    case "1kg":
                        baggageCost = 10;
                        break;
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

        // Metode, der skal kaldes, når en flyvning vælges for at sætte basisprisen
        private void SetBasePrice(double price)
        {
            basePrice = price;
            // Opdater prisen på GUI med det samme for at reflektere basisprisen
            SamletPris.Text = $"Pris: {basePrice:C}";
        }

        private void UpdateTotalPrice()
        {
            // Samlede pris er summen af basisprisen, returbilletten og bagageomkostningerne
            double totalPrice = basePrice + returnTicketCost + baggageCost;
            SamletPris.Text = $"Pris: {totalPrice:C}";
        }

        private async Task<bool> LockFlight()
        {
            try
            {
                // Erstat med det faktiske ID for det valgte flysæde
                var selectedFlightId = 1;

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:5114/");

                    // Antager, at API'et har en endpoint til at låse et sæde
                    var response = await httpClient.GetAsync($"api/flights/{selectedFlightId}");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        // Antager, at API'et returnerer en boolsk værdi, der indikerer, om låsningen lykkedes
                        return bool.Parse(content);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)

        {
            price = 0;
            returnTicket = "";
            var isFlightLocked = await LockFlight();

            if (!isFlightLocked)
            {
                MessageBox.Show("Sædet er allerede booket. Vælg venligst en anden flyvning.", "Bookingfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Saml kvitteringsoplysningerne
            string customerInfo = "Kundeoplysninger:\n" +
                              "Fornavn: " + Fornavn.Text + "\n" +
                              "Efternavn: " + lastName.Text + "\n" +
                              "Mobil: " + mobilePhone.Text + "\n" +
                              "Email: " + Email.Text + "\n";

            if (DestinationDropDown.SelectedItem != null)
            {
                var selectedFlight = (Flight)DestinationDropDown.SelectedItem;
                price += selectedFlight.Price; // Start med basisprisen for den valgte flyvning.
            }
            else
            {
                SamletPris.Text = "Ingen flyvning valgt";
                return; // Hvis ingen flyvning er valgt, afbryd og vis besked.
            }

            string destination = "Valgt destination: " + (DestinationDropDown.SelectedItem as Flight)?.DestinationAddress ?? "Ingen";

            // Tjek for returbillet og opdater pris
            if (ReturValgDropDown.SelectedIndex != -1 && ReturValgDropDown.SelectedItem.ToString() == "Ja")
            {
                returnTicket += "Ja";
                price += 150; // Tilføj ekstra omkostninger for returbillet.
            }
            else
            {
                returnTicket += ReturValgDropDown.SelectedIndex != -1 ? ReturValgDropDown.SelectedItem.ToString() : "Ingen valgt";
            }

            string baggage = "Bagage: ";
            double baggageCost = 0;

            if (BaggageDropDown.SelectedIndex != -1)
            {
                string selectedBaggage = BaggageDropDown.SelectedItem.ToString();
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
            baggage += baggageCost > 0 ? BaggageDropDown.SelectedItem.ToString() : "Ingen valgt";

            // Formatér den opdaterede pris som en valuta
            string formattedPrice = string.Format("{0:C}", price);

            // Opret en kvitteringstekst med den opdaterede pris
            string receiptText = $"{customerInfo}\n{departure}\n{returnTicket}\n{baggage}\nPris: {formattedPrice}\n{destination}";

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

        private void label10_Click(object sender, EventArgs e)
        {
            AfgangsDestination.Text = "Aalborg";
        }
        private void label11_Click(object sender, EventArgs e)
        {
            if (DestinationDropDown.SelectedItem != null)
            {
                var selectedFlight = (Flight)DestinationDropDown.SelectedItem;
                // Tjek for null eller tom DestinationAddress
                if (!string.IsNullOrEmpty(selectedFlight.DestinationAddress))
                {
                    Destination.Text = selectedFlight.DestinationAddress;
                }
                else
                {
                    Destination.Text = "Ingen adresse tilgængelig";
                }
            }
            else
            {
                MessageBox.Show("Ingen flyvning er valgt.");
            }
        }

        public void forNavn(object sender, EventArgs e)
        {
            if (loggedInCustomer != null)
            {
                Fornavn.Text = loggedInCustomer.FirstName;
            }

        }

        private void lastNameLabel_Click(object sender, EventArgs e)
        {
            if (loggedInCustomer != null)
            {
                lastName.Text = loggedInCustomer.LastName;
            }
        }
        private void mobilePhoneLabel_Click(object sender, EventArgs e)
        {
            if (loggedInCustomer != null)
            {
                mobilePhone.Text = loggedInCustomer.MobilePhone;
            }
        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {
            if (loggedInCustomer != null)
            {
                Email.Text = loggedInCustomer.Email;
            }
        }

    
    }
}
