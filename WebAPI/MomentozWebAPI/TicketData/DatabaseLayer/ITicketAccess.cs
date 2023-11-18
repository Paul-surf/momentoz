<<<<<<< Updated upstream
﻿using TicketData.ModelLayer;
using System;
=======
﻿

using System.Net.Sockets;
using TicketData.ModelLayer;

>>>>>>> Stashed changes

namespace TicketData.DatabaseLayer
{

    public interface ITicketAccess
    {

<<<<<<< Updated upstream
        
=======
>>>>>>> Stashed changes
        Ticket GetTicketById(int id);
        List<Ticket> GetTicketAll();
        int CreateTicket(Ticket ticketToAdd);
        bool UpdateTicket(Ticket ticketToUpdate);
        bool DeleteTicketById(int id);

    }
}
