using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MomentozClientApp.Model
{

    public class Customer
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        
        public int? Id { get; set; }
        public Customer(string username, string password) {

            Username = username;
            PasswordHash = password;
            Id = Id;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
        public Customer(int id, string firstName, string lastName, string mobilePhone) { 
            FirstName = firstName; 
            LastName = lastName; 
            MobilePhone = mobilePhone;
            Id = id;
        }
        public Customer(int id, string firstName, string lastName, string fullName, string mobilePhone) : this(id, firstName, lastName, fullName) { MobilePhone = mobilePhone; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("mobilePhone")]
        public string? MobilePhone { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("fullName")]
        public string? FullName { 
            get { 
                return $"{FirstName} {LastName}"; 
            }
        }
        public override string? ToString() { 
            string? pText = FullName; 
            if (MobilePhone != null) { 
                pText += " - mobil no: " + MobilePhone; 
            } 
            return pText; 
        }
    }
}
