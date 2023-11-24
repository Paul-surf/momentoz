﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.ModelLayer
{
    public class Flight
    {
        public Flight() { } 

        public Flight(string? address, string? city, double price, string? destinationAddress, string? destinationCountry)
        {
            Address = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }
        public Flight(int id, string? address, string? city, double price, string? destinationAddress, string? destinationCountry)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public double Price { get; set; }
        public string? DestinationAddress { get; set;}
        public string? DestinationCountry { get; set;}
    }
}