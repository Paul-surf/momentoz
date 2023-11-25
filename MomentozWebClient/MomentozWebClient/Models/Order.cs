namespace MomentozWebClient.Models
{
    public class Order
    {
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? TicketID { get; set; }

        public Order(double totalPrice, DateTime dateOfBuy, int? TicketID, int? CustomerID)
        {
            TotalPrice = totalPrice;
            PurchaseDate = dateOfBuy;
            this.TicketID = TicketID;
            this.CustomerID = CustomerID;

        }
    }
}