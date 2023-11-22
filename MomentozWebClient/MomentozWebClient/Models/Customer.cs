﻿namespace WebserverMomentoz.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }

        public Customer()
        {

        }
        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;

        }

    }
}