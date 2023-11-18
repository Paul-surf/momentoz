namespace CustomerRestService.DTOs
{
    public class TicketDto
    {
        public TicketDto() { }

        public TicketDto(string? inFirstName, string? inLastName, string? inMobilePhone)
        {
            FirstName = inFirstName;
            LastName = inLastName;
            MobilePhone = inMobilePhone;
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}

 