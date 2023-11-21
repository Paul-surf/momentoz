namespace CustomerRestService.DTOs
{
    public class CustomerDtoo
    {

        public CustomerDtoo() { }

        public CustomerDtoo(string? inFirstName, string? inLastName, string? inMobilePhone, string? email)
        {
            FirstName = inFirstName;
            LastName = inLastName;
            MobilePhone = inMobilePhone;
            Email = email;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }

        public string? Email { get; set; }
        public string? FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
