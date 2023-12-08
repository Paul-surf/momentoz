namespace DatabaseData.ModelLayer
{
    public class Order
    {
        public Order() { }

        public Order(double totalPrice, DateTime purchaseDate, int? customerID, int? flightID)
        {
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            CustomerID = customerID;
            FlightID = flightID;
        }

        public Order(int orderID, double totalPrice, DateTime purchaseDate, int? customerID, int? flightID)
            : this(totalPrice, purchaseDate, customerID, flightID)
        {
            OrderID = orderID;
        }

        public int OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? FlightID { get; set; }
    }
}
