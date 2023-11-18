
namespace TicketData.ModelLayer
{
    public class Ticket
    {

        public Ticket() { }

        public Ticket(string? firstName, string? lastName, string? mobilePhone)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
        }

        public Ticket(int id, string? firstName, string? lastName, string? mobilePhone) : this(firstName, lastName, mobilePhone)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }

        public bool IsTicketEmpty
        {
            get
            {
                bool ticketIsEmpty = false;
                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
                {
                    ticketIsEmpty = true;
                }
                return ticketIsEmpty;
            }
        }
    }
}
