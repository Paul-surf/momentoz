        namespace RESTfulService.DTOs
{
        public class FlightDto
        {

      //  public FlightDto() { }

        public FlightDto(int inFlightID, string? inDeparture,  string? inDestinationAddress, string? inDestinationCountry, DateTime? homeTrip, double inPrice)
        {
            FlightID = inFlightID;
            Departure = inDeparture;
            DestinationAddress = inDestinationAddress;
            DestinationCountry = inDestinationCountry;
            HomeTrip = homeTrip;
            Price = inPrice;
        }
        public int FlightID { get; set; }
        public string? Departure { get; set; }
        public string? City { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }
        public DateTime? HomeTrip { get; set; }
        public double Price { get; set; }
        public string CustomDisplay => $"{Departure}, {DestinationAddress}, {DestinationCountry}";
    }
}