namespace RESTfulService.DTOs
{
    public class CustomerDto
    {
        public CustomerDto() { }
        // Match konstruktørerne til Customer klassen.
        public CustomerDto(string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
        }
        public CustomerDto(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode)
        {
            Id = customerID;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
        }
        public CustomerDto(int customerID, string firstName, string lastName, string mobilePhone, string email, string? streetName, string? zipCode, string? loginUserId)
        {
            Id = customerID;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
            LoginUserId = loginUserId;
        }

        public CustomerDto(string? firstName, string? lastName, string? mobilePhone, string? email, string? streetName, string? zipCode, string? loginUserId)
        {
           
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = streetName;
            ZipCode = zipCode;
            LoginUserId = loginUserId;
        }
       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? LoginUserId { get; set; }
        public int Id { get; set; }

       public string? Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
