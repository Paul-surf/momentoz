using MomentozClientApp.ModelLayer;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class TicketdataControl : ITicketdata
    {
        private readonly ITicketAccess _ticketAccess;

        public TicketdataControl(ITicketAccess inTicketAccess)
        {
            _ticketAccess = inTicketAccess;
        }

        public Ticket? Get(int id)
        {
            try
            {
                return _ticketAccess.GetTicketById(id).Result;
            }
            catch
            {
                return null;
            }
        }

        public List<Ticket>? Get()
        {
            try
            {
                return _ticketAccess.GetTicketAll().Result;
            }
            catch
            {
                return null;
            }
        }

        public int Add(Ticket ticketToAdd)
        {
            try
            {
                if (ticketToAdd != null)
                {
                    return _ticketAccess.CreateTicket(ticketToAdd).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool Put(Ticket ticketToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket? GetTicketById(int id)
        {
            try
            {
                return _ticketAccess.GetTicketById(id).Result;
            }
            catch
            {
                return null;
            }
        }
    }
}
