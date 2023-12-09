using Newtonsoft.Json;

namespace MomentozClientApp.Model
{
    public class Customer
    {
        // Standardkonstruktør uden parametre.
        public Customer() { }

        // Udvidet konstruktør, der inkluderer alle egenskaber.
        public Customer(int customerID, string firstName, string lastName, string mobilePhone, string email, string loginUserId, string fullName)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            LoginUserId = loginUserId;
            FullName = fullName;
        }

        [JsonProperty("customerid")]
        public int CustomerID { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("loginUserId")]
        public string LoginUserId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
