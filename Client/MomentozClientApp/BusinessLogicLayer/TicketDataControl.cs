using MomentozClientApp.DTOs;
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
        public TicketDto? Get(int id)
        {
            try
            {
                var foundTicket = _ticketAccess.GetTicketById(id).Result; ;
                return ModelConversion.TicketDtoConvert.FromTicket(foundTicket);
            }
            catch
            {
                return null;
            }
        }
        public List<TicketDto>? Get()
        {
            try
            {
                var foundTickets = _ticketAccess.GetTicketAll().Result;
                return ModelConversion.TicketDtoConvert.FromTicketCollection(foundTickets);
            }
            catch
            {
                return null;
            }
        }
        public int Add(TicketDto ticketToAdd)
        {
            try
            {
                var newTicket = ModelConversion.TicketDtoConvert.ToTicket(ticketToAdd);
                if (newTicket != null)
                {
                    return _ticketAccess.CreateTicket(newTicket).Result;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        public bool Put(TicketDto ticketToUpdate)
        {
            {
                throw new NotImplementedException();
            }
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
        public TicketDto? GetTicketById(int id)
        {
            try
            {
                var foundTicket = _ticketAccess.GetTicketById(id).Result;
                return foundTicket != null ? ModelConversion.TicketDtoConvert.FromTicket(foundTicket) : null;
            }
            catch
            {
                return null;
            }
        }
    }
}