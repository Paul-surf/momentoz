namespace DatabaseData.ModelLayer
{
    public class Order
    {
        public Order() {}
        public Order( double totalPrice, DateTime purchaseDate, int? CustomerID, int? FlightID)
        {  
            this.TotalPrice = TotalPrice;
            this.PurchaseDate = purchaseDate;
            this.CustomerID = CustomerID;
            this.FlightID = FlightID;
        }

        public Order(int id, double totalPrice, DateTime purchaseDate, int? CustomerID, int? FlightID) : this(totalPrice, purchaseDate, CustomerID, FlightID)
        {
            ID = id;
        }

        public int ID { get; set; }    
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? FlightID { get; set; }
    }
}
