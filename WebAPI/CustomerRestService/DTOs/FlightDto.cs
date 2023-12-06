        namespace RESTfulService.DTOs
{
        public class FlightDto
        {

        public FlightDto() { }

        public FlightDto(int id, string? inDeparture, double inPrice, string? inDestinationAddress, string? inDestinationCountry)
        {
            Id = id;
            Departure = inDeparture;
            Price = inPrice;
            DestinationAddress = inDestinationAddress;
            DestinationCountry = inDestinationCountry;
        }
        public int Id { get; set; }
        public string? Departure { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }
        public bool IsBooked { get; set; }

        public string CustomDisplay => $"{Departure}, {DestinationAddress}, {DestinationCountry}";
    }
}