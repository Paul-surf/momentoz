
        namespace RESTfulService.DTOs
        {
        public class OrderDto
        {
        public OrderDto() { }
        public OrderDto(double inTotalPrice, DateTime inPurchaseDate, int inCustomerID, int inTicketID, int inFlightID)
        {


            TotalPrice = inTotalPrice;
            PurchaseDate = inPurchaseDate;
            CustomerID = inCustomerID;
            TicketID = inTicketID;
        }
        public int ID { get; set; }
            public double TotalPrice { get; set; }
            public DateTime PurchaseDate { get; set; }
            public int? CustomerID { get; set; }
            public int? TicketID { get; set; }
            public int FlightId { get; set; }
            public bool IsBooked { get; set; }
    }
}

