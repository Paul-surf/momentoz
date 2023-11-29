namespace DatabaseData.ModelLayer
{
    public class Order
    {
        public Order() {}
        public Order( double totalPrice, DateTime purchaseDate, int? CustomerID, int? TicketID)
        {  
            this.TotalPrice = TotalPrice;
            this.PurchaseDate = purchaseDate;
            this.CustomerID = CustomerID;
            this.TicketID = TicketID;
        }

        public Order(int id, double totalPrice, DateTime purchaseDate, int? CustomerID, int? TicketID) : this(totalPrice, purchaseDate, CustomerID, TicketID)
        {
            ID = id;
        }

        public int ID { get; set; }    
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? TicketID { get; set; }
    }
}
