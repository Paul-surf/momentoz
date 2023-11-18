namespace CustomerRestService.DTOs
{
    public class CustomerDto
    { 
        public CustomerDto() { }

        public CustomerDto(string? firstName, string? lastName, string? mobilePhone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        public CustomerDto(int id, string? inFirstName, string? inLastName, string? inMobilePhone, string? email)
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
