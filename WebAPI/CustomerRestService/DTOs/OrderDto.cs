namespace RESTfulService.DTOs

        {
        public class OrderDto
    { 
      //  public OrderDto() { }
        
        public OrderDto(int inOrderID, double inTotalPrice, DateTime inPurchaseDate, int inCustomerID, int inFlightID) { 


            OrderID = inOrderID;
            TotalPrice = inTotalPrice;
            PurchaseDate = inPurchaseDate;
            CustomerID = inCustomerID;
            FlightID = inFlightID;
        }
            public int OrderID { get; set; }
            public double TotalPrice { get; set; }
            public DateTime PurchaseDate { get; set; }
            public int CustomerID { get; set; }
            public int FlightID { get; set; }
            
    }
}

//public OrderDto(int inOrderID, double inTotalPrice, DateTime inPurchaseDate, int inCustomerID, int inFlightID)
//{