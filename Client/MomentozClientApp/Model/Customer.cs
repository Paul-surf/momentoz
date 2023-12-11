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

      
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }   
        public string Email { get; set; }  
        public string LoginUserId { get; set; }
        public string FullName { get; set; }
    }
}
