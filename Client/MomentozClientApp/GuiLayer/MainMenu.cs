using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;
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
        private double basePrice;
        private double returnTicketCost; 
        private double baggageCost;
        private bool customersLoaded = false; 
        private bool flightsLoaded = false;
        private readonly string _customerId;
        private Customer loggedInCustomer;
        string departure = "Afgang: Aalborg";
        string returnTicket = "Returbillet: ";
        double price = 0;



        public MainMenu(Customer customer)
        {
            InitializeComponent();
            InitializeYesNoComboBox();
            InitializeBagageWeightCombobox();
            flightRefreshTimer = new System.Windows.Forms.Timer();
            flightRefreshTimer.Interval = 10000; // 10 sekunder
            flightRefreshTimer.Tick += new EventHandler(flightRefreshTimer_Tick);
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
            customerID.Text = loggedInCustomer.CustomerID.ToString();
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
        }
      
        private void CustomerIDLabel_Click(object sender, EventArgs e)
        {

        }
        private async void MainMenu_Shown(object sender, EventArgs e)
        {
            await LoadFlightsAsync();
            await LoadCustomersAsync();
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

        public void UpdateCustomerInfo(int customerID, string firstName, string lastName, string mobilePhone, string email)
        {
            this.customerID.Text = customerID.ToString();
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
            double totalPrice = basePrice + additionalCosts;
            SamletPris.Text = $"Pris: {totalPrice:C}";
        }

        private async void flightRefreshTimer_Tick(object sender, EventArgs e)
        {

            DestinationDropDown.Enabled = false;
            await LoadFlightsAsync();

            DestinationDropDown.Enabled = true;
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
                        DestinationDropDown.ValueMember = "flightId";
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

            comboBox.Enabled = false;

            try
            {
                List<Flight> updatedFlights = await GetUpdatedFlightsAsync();

                var flightDisplayItems = updatedFlights.Select(flight => new
                {
                    DisplayText = $"{flight.DestinationAddress}, {flight.DestinationCountry}",
                    Value = flight.FlightID 
                }).ToList();

                comboBox.DisplayMember = "DisplayText";
                comboBox.ValueMember = "Value";
                comboBox.DataSource = flightDisplayItems;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                comboBox.Enabled = true;
            }
        }


        private async Task<List<Flight>> GetUpdatedFlightsAsync()
        {
            return new List<Flight>();
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            UpdateTotalPrice(baggageCost);
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DestinationDropDown.SelectedItem != null)
            {
                var selectedFlight = (Flight)DestinationDropDown.SelectedItem;
                if (!string.IsNullOrEmpty(selectedFlight.DestinationAddress))
                {
                    Destination.Text = selectedFlight.DestinationAddress;
                }
                else
                {
                    Destination.Text = "Ingen adresse tilgængelig";
                }
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
                returnTicketCost = choice == "Ja" ? +basePrice * 1 : 0;
            }
            else
            {
                returnTicketCost = 0;
            }

            UpdateTotalPrice();
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


        private void UpdateTotalPrice()
        {
            double totalPrice = basePrice + returnTicketCost + baggageCost;
            SamletPris.Text = $"Pris: {totalPrice:C}";
        }


        private async void GodkendOrdreKnap(object sender, EventArgs e)
        {
            price = CalculatePrice();
            Customer customer = loggedInCustomer; // Det nuværende kundeobjekt

            if (DestinationDropDown.SelectedItem != null)
            {
                Flight selectedFlight = (Flight)DestinationDropDown.SelectedItem;

                Order newOrder = new Order
                {
                    TotalPrice = price,
                    PurchaseDate = DateTime.Now,
                    CustomerID = loggedInCustomer.CustomerID,
                    FlightID = selectedFlight.FlightID
                };

                OrderAccess _orderAccess = new OrderAccess(); // Oprettelse af en instans af OrderAccess udenfor try-catch blokken.
                try
                {
                    // Opret ordre, med alle oplysningerne (klar til brug)
                    Order createdOrderResult = await _orderAccess.CreateOrder(newOrder);

                    if (createdOrderResult != null)
                    {
                        // Opret en kvittering
                        string kvittering = $"Kvittering:\n\n" +
                        $"Kundeoplysninger:\n" +
                        $"Navn: {customer.FirstName} {customer.LastName}\n" +
                        $"Email: {customer.Email}\n" +
                        $"Telefon: {customer.MobilePhone}\n\n" +
                        $"Flyrejseoplysninger:\n" +
                        $"Afgang: {selectedFlight.Departure}\n" +
                        $"Ankomst: {selectedFlight.DestinationAddress}\n" +
                        $"Ankomst: {selectedFlight.DestinationCountry}\n" +
                        $"Pris: {selectedFlight.Price:C}\n\n" +
                        $"Ordreoplysninger:\n" +
                        $"Total Pris: {createdOrderResult.TotalPrice:C}\n" +
                        $"Købsdato: {createdOrderResult.PurchaseDate}\n";

                        MessageBox.Show(kvittering, "Ordrebekræftelse", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        bookFlight(selectedFlight);
                    }
                    else
                    {
                        MessageBox.Show("Det var ikke muligt at oprette ordren.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("En fejl opstod under oprettelsen af ordren: " + ex.Message, "Systemfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vælg venligst en flyvning først.", "Ingen flyvning valgt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bookFlight(Flight selectedFlight)
        {
            throw new NotImplementedException();
        }

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
    }
}
