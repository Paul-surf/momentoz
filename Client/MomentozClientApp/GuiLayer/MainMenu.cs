using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Timer = System.Windows.Forms.Timer;


namespace MomentozClientApp
{
    public partial class MainMenu : Form
    {
        private IServiceConnection _orderServiceConnection;
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
        private IServiceConnection? orderServiceConnection;

        //  public MainMenu(Customer customer)
        public MainMenu(Customer customer)
        {
            InitializeComponent();
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
            _orderServiceConnection = orderServiceConnection;
            UpdateTotalPrice();
            DestinationDropDown.DropDown += flightsDropDown;
            ReturValgDropDown.DropDown += comboBox2_DropDown;
            BaggageDropDown.DropDown += comboBox3_DropDown;
            DestinationDropDown.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            loggedInCustomer = customer;
            labelCustomerName.Text = loggedInCustomer.FirstName;
            lastName.Text = loggedInCustomer.LastName;
            mobilePhone.Text = loggedInCustomer.MobilePhone;
            email.Text = loggedInCustomer.Email;

            this.Shown += new System.EventHandler(this.MainMenu_Shown);


            //_flightAccess = new FlightAccess();
        }

        private async void MainMenu_Shown(object sender, EventArgs e)
        {
            await LoadFlightsAsync();
            await LoadCustomersAsync();
            // Eventuelt yderligere initialisering...
        }

        public void SetLoggedInCustomer(Customer customer)
        {
            loggedInCustomer = customer;
            UpdateCustomerInfo(customer.FirstName, customer.LastName, customer.MobilePhone, customer.Email);

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
            if (firstName == null)
                this.labelCustomerName.Text = firstName;
            this.lastName.Text = lastName;
            this.mobilePhone.Text = mobilePhone;
            this.email.Text = email;
            {
                throw new ArgumentNullException(nameof(firstName));
            }
        }


        private void UpdateTotalPrice(double additionalCosts)
        {
            // Antager at 'label12' er din prislabel.
            double totalPrice = basePrice + additionalCosts;
            SamletPris.Text = $"Pris: {totalPrice:C}";
        }
        private async void PopulateDestinationDropDown()
        {
            // Forudsat at GetFlightAll er en statisk metode i klassen 'FlightService',
            // og at den returnerer en liste af Flight objekter eller en tilsvarende type.
         //   var flightList = await FlightAccess.GetFlightAll();

            // Her tilføjer du flyvningerne til din dropdown.
            // Resten af din kode...
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


        private async void flightsDropDown(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;

            // Disable the combobox to prevent multiple clicks during data loading
            comboBox.Enabled = false;

            try
            {
                // Get updated flights data from the database asynchronously
                List<Flight> updatedFlights = await GetUpdatedFlightsAsync();

                // Create a list of anonymous objects with just the destination address and country
                var flightDisplayItems = updatedFlights.Select(flight => new
                {
                    DisplayText = $"{flight.DestinationAddress}, {flight.DestinationCountry}",
                    Value = flight.Id // Assuming there's an Id property to identify each flight uniquely
                }).ToList();

                // Update the ComboBox with the new data
                comboBox.DisplayMember = "DisplayText";
                comboBox.ValueMember = "Value";
                comboBox.DataSource = flightDisplayItems;
            }
            catch (Exception ex)
            {
                // Handle exceptions (if any) here
            //    MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Re-enable the combobox after data loading
                comboBox.Enabled = true;
            }
        }


        private async Task<List<Flight>> GetUpdatedFlightsAsync()
        {
            // Implement this method to retrieve updated flights from the database
            // This is a placeholder for the actual database call
            return new List<Flight>();
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
                returnTicketCost = choice == "Ja" ? +basePrice*1 : 0;
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
                additionalCosts += basePrice; // Ekstra omkostning for returbillet.
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


        private async void GodkendOrdreKnap(object sender, EventArgs e)
        {
            // Antager at 'price', 'returnTicket' og 'Customer' er defineret et sted i din klasse
            price = CalculatePrice(); // En metode, der beregner prisen baseret på brugerens valg
          //  returnTicket = DetermineReturnTicket(); // En metode, der bestemmer, om der er en returbillet
            Customer customer = loggedInCustomer; // Metode til at hente den nuværende kundeobjekt
            Order newOrder = null;

            if (DestinationDropDown.SelectedItem != null)
            {
                Flight selectedFlight = (Flight)DestinationDropDown.SelectedItem;

                // Opret et nyt Order objekt
                newOrder = new Order
                {
                    CustomerID = customer.Id, // Antager at Customer objektet har en Id property
                    FlightID = selectedFlight.Id, // Antager at Flight objektet har en Id property
                    TotalPrice = selectedFlight.Price,
                    
                    // Sæt yderligere Order egenskaber her
                };

                try
                {
                    // Kalder backend service for at oprette ordren
                    bool success = await _orderServiceConnection.CreateOrder(newOrder);

                    if (success)
                    {
                        // Vis kvitteringsoplysningerne, hvis ordren blev oprettet succesfuldt
                        string customerInfo = $"Kundeoplysninger:\nFornavn: {customer.FirstName}\nEfternavn: {customer.LastName}\nMobil: {customer.MobilePhone}\nEmail: {customer.Email}\n";
                        string orderDetails = $"Ordre detaljer:\nFlyvning: {selectedFlight.DestinationAddress}\nPris: {price}\n";
                        MessageBox.Show(customerInfo + orderDetails, "Ordrebekræftelse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kunne ikke oprette ordren, da billetten muligvis allerede er booket.", "Bookingfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Log exception og/eller vis fejlmeddelelse
                    MessageBox.Show("En fejl opstod under oprettelsen af ordren: " + ex.Message, "Systemfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vælg venligst en flyvning først.", "Ingen flyvning valgt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Husk at implementere metoderne CalculatePrice og DetermineReturnTicket

        private double CalculatePrice()
        {
            // Implementer logikken til at beregne prisen her
            double totalPrice = basePrice + returnTicketCost + baggageCost;
            return totalPrice;
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
                labelCustomerName.Text = loggedInCustomer.FirstName;
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
                email.Text = loggedInCustomer.Email;
            }
        }
        public interface IServiceConnection
        {
            // Andre metoder og egenskaber
            Task<bool> CreateOrder(Order order);
        }




    }

}
