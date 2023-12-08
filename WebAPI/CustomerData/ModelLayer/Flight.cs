namespace DatabaseData.ModelLayer
{
    public class Flight
    {
        public Flight() { }

        public Flight(string departure, string destinationAddress, string destinationCountry, DateTime? homeTrip, double price)
        {
            Departure = departure;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
            HomeTrip = homeTrip;
        }

        public Flight(int flightID, string departure, string destinationAddress, string destinationCountry, DateTime? homeTrip, double price)
            : this( departure, destinationAddress, destinationCountry, homeTrip, price)
        {
            FlightID = flightID;
            
        }
          
        public int FlightID { get; set; }
        public string Departure { get; set; }
        public double Price { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime? HomeTrip { get; set; }
        public string? CustomDisplay => $"{Departure}, {DestinationAddress}, {DestinationCountry}";
    }
}
