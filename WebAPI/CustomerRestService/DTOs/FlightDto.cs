﻿using Microsoft.Identity.Client;

namespace CustomerRestService.DTOs
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
        public string? Address { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationCountry { get; set; }

    }
}