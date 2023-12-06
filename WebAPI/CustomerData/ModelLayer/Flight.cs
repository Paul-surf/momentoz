namespace DatabaseData.ModelLayer
{
    public class Flight
    {
        public Flight() { } 

     public Flight(string? departure, double price, string? destinationAddress, string? destinationCountry)
        {
            Departure = departure;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

        public Flight(int id, string? departure, double price, string? destinationAddress, string? destinationCountry)
        {
            Id = id;
            Departure = departure;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }
        public int Id { get; set; }
        public string? Departure { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set;}
        public string? DestinationCountry { get; set;}
        public string CustomDisplay => $"{Departure}, {DestinationAddress}, {DestinationCountry}";
    }
}
