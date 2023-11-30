        namespace RESTfulService.DTOs
{
        public class FlightDto
        {

        public FlightDto() { }

        public FlightDto(string? inAddress, string? inCity, double inPrice, string? inDestinationAddress, string? inDestinationCountry)
        {
            Address = inAddress;
            City = inCity;
            Price = inPrice;
            DestinationAddress = inDestinationAddress;
            DestinationCountry = inDestinationCountry;
        }
        public bool IsLocked { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }

        public string CustomDisplay => $"{Address}, {City}, {DestinationAddress}, {DestinationCountry}";
    }
}