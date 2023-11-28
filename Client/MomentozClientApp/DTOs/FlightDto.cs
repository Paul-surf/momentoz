using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.DTOs
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
       
            public int Id { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public double Price { get; set; }
            public string DestinationAddress { get; set; }
            public string DestinationCountry { get; set; }

            // Brugerdefineret attribut, der kombinerer de ønskede attributter
            public string CustomDisplay => $"{Address}, {City}, {DestinationAddress}, {DestinationCountry}";
     }
}



