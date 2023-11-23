namespace CustomerRestService.DTOs
{
        public class OrderDto
        {
            public int ID { get; set; }
            public double TotalPrice { get; set; }
            public DateTime DateForPurchase { get; set; }
            public int? CustomerID { get; set; }
            public int? TicketID { get; set; }
        }
}

