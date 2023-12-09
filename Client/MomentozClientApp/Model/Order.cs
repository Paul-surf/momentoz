// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Model
{
    // Order-klassen repræsenterer en ordre med totalpris, købsdato og relaterede ID'er til kunde og billet.
    public class Order
    {
        // Standardkonstruktør uden parametre.
        public Order() { }

        // Konstruktør, der initialiserer en ny Order-instans med totalpris, købsdato, kunde-ID og billet-ID.
        public Order(double totalPrice, DateTime purchaseDate, int customerID, int flightID)
        {
            // Sætter egenskaberne TotalPrice, PurchaseDate, CustomerID og TicketID til de givne værdier.
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        //public Order(int orderID, double totalPrice, DateTime purchaseDate, int customerID, int flightID)
        //    : this(totalPrice, purchaseDate, customerID, flightID)
        //{
        //    OrderID = orderID;
        //}

        public int OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
    }
}
