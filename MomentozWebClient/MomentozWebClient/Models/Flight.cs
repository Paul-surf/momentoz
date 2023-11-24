namespace MomentozWebClient.Models
{
    public class Flight
    {
       public int Id{ get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public double Price { get; set; }
       public string DestinationAddress { get; set; }
       public string? DestinationCountry { get; set; }

        public Flight(int id, string? address, string? city, double price, string? destinationAddress, string? destinationCountry)

        {
            Id = id;
            Address = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }

    }
}
