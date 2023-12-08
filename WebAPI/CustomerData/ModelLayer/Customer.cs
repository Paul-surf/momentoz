namespace DatabaseData.ModelLayer
{
    public class Customer
    {
        public Customer() { }

        public Customer(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = streetName;
            ZipCode = zipCode;
        }

       
        public Customer(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string? loginUserId)
        {
        
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = streetName;
            ZipCode = zipCode;
            LoginUserId = loginUserId;
        }
        public Customer(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string? tempLoginUserId)
           : this(firstName, lastName, mobilePhone, email, streetName, zipCode) {
            CustomerID = customerID;
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string LoginUserId { get; set; }

        public string? Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
