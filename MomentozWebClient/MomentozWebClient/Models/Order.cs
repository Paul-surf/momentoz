namespace MomentozWebClient.Models
{
    public class Order
    {
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CustomerID { get; set; }
        public int? TicketID { get; set; }

        public Order(int? TicketID, int? CustomerID)
        {
            this.TicketID = TicketID;
            this.CustomerID = CustomerID;
        }
        public Order() { }
        public Order(int ticketId) 
        {
            TicketID = ticketId;
        }
    }
}