namespace MomentozWebClient.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? Zipcode { get; set; }

        public string? LoginUserId { get; set; }

        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email, string? loginUserId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            LoginUserId = loginUserId;
        }
        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email, string? street, string? zipcode, string? loginUserId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            Street = street;
            Zipcode = zipcode;
            LoginUserId = loginUserId;
        }

        public Customer()
        {
        }
        public Customer(IFormCollection form)
        {
            FirstName = form["FirstName"];
            LastName = form["LastName"];
            MobilePhone = form["MobilePhone"];
            LoginUserId = form["LoginUserId"];
        }


        public Customer(string? inEmail, string? inLoginUserId)
        {
            Email = inEmail;
            LoginUserId = inLoginUserId;
        }
    }
}
