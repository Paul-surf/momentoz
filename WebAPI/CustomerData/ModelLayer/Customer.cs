namespace CustomerData.ModelLayer
{
    public class Customer
    {
        public int Id { get; set; } // Add this line if it's missing and you want to include the Id property in the Customer class
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }

        public Customer() { }

        public Customer(string? firstName, string? lastName, string? mobilePhone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        // Add this constructor if you want to be able to create a Customer with an Id
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
