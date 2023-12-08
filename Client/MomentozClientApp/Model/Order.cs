// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.Model
{
    // Order-klassen repræsenterer en ordre med totalpris, købsdato og relaterede ID'er til kunde og billet.
    public class Order
    {
        // Standardkonstruktør uden parametre.
        public Order() { }

        // Konstruktør, der initialiserer en ny Order-instans med totalpris, købsdato, kunde-ID og billet-ID.
        public Order(double totalPrice, DateTime purchaseDate, int? customerID, int? flightID)
        {
            // Sætter egenskaberne TotalPrice, PurchaseDate, CustomerID og TicketID til de givne værdier.
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        // Udvidet konstruktør, der inkluderer et id samt de andre parametre.
  
        public Order(int id, double totalPrice, DateTime purchaseDate, int? customerID, int? flightID)
        {
            // Sætter egenskaben ID til den givne værdi.
            ID = id;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
            
        }

        // Egenskaber for at holde ordreinformationer såsom ID, totalpris, købsdato, kunde-ID og billet-ID.
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? FlightID { get; set; }
    }
}
