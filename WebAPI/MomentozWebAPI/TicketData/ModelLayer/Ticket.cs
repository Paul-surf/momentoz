<<<<<<< Updated upstream
﻿
namespace TicketData.ModelLayer
=======
﻿namespace TicketData.ModelLayer
>>>>>>> Stashed changes
{
    public class Ticket
    {

        public Ticket() { }

<<<<<<< Updated upstream
        public Ticket(string? firstName, string? lastName, string? mobilePhone)
=======
        public Ticket(string? firstName, string? lastName, string? mobilePhone, string? email)
>>>>>>> Stashed changes
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
<<<<<<< Updated upstream
        }

        public Ticket(int id, string? firstName, string? lastName, string? mobilePhone) : this(firstName, lastName, mobilePhone)
=======
            Email = email;
        }

        public Ticket(int id, string? firstName, string? lastName, string? mobilePhone, string? email) : this(firstName, lastName, mobilePhone, email)
>>>>>>> Stashed changes
        {
            Id = id;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
<<<<<<< Updated upstream
=======
        public string? Email { get; set; }
>>>>>>> Stashed changes

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
