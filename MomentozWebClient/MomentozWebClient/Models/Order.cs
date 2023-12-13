namespace MomentozWebClient.Models
{
    public class Order
    {
        public int? OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
        public Customer Customer { get; set; }
        public Flight Flight { get; set; }

        public Order(int FlightID, double price)
        {
            this.FlightID = FlightID;
            TotalPrice += price;
        }
        public Order() { }
    }
}