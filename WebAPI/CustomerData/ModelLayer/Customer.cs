namespace DatabaseData.ModelLayer
{
    public class Customer
    {

        public Customer(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
        }

       
        public Customer(int CustomerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string? loginUserId)
        {
            this.CustomerID = CustomerID;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
            LoginUserId = loginUserId;
        }
        public Customer(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
           : this(firstName, lastName, mobilePhone, email, streetName, zipCode) {
            CustomerID = customerID;
        }

        public Customer()
        {
        }

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string? Street { get; set; } 
        public string? ZipCode { get; set; }
        public string? LoginUserId { get; set; }

        //public bool IsCustomerEmpty
        //{
        //    get
        //    {
        //        return string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName);
        //    }
        //}
    }
}
