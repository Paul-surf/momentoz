namespace MomentozWebClient.Models
{
    public class Flight
    {
       public string id{ get; set; }
       public string address { get; set; }

       public string city { get; set; }

       public int price { get; set; }

       public DateTime destinationAddress { get; set; }

        public string? destinationCountry { get; set; }

        public Flight(int id, string? address, string? city, double price, string? destinationAddress, string? destinationCountry)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }
    }
    }

