namespace DatabaseData.ModelLayer
{
    public class Customer
    {

        public Customer() { }

        public Customer(string? firstName, string? lastName, string? mobilePhone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email) : this(firstName, lastName, mobilePhone, email)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }

        public string? Email { get; set; }  

        public bool IsCustomerEmpty
        {
            get
            {
                bool customerIsEmpty = false;
                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
                {
                    customerIsEmpty = true;
                }
                return customerIsEmpty;
            }
        }
    }
}
