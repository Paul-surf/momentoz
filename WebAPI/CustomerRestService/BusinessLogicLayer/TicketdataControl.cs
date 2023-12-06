using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;
namespace RESTfulService.BusinesslogicLayer
{

    public class TicketdataControl : ITicketdata
    {
        private readonly ITicketAccess _ticketAccess;

        public TicketdataControl(ITicketAccess inTicketAccess)
        {
            _ticketAccess = inTicketAccess;
        }

        public TicketDto? Get(int idToMatch)
        {
            TicketDto? foundTicketDto;
            try
            {
                Ticket? foundTicket = _ticketAccess.GetTicketById(idToMatch);
                foundTicketDto = ModelConversion.TicketDtoConvert.FromTicket(foundTicket);
            }
            catch
            {
                foundTicketDto = null;
            }
            return foundTicketDto;
        }

        public List<TicketDto>? Get()
        {
            List<TicketDto>? foundDtos;
            try
            {
                List<Ticket>? foundTickets = _ticketAccess.GetTicketAll();
                foundDtos = ModelConversion.TicketDtoConvert.FromTicketCollection(foundTickets);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }

        public TicketDto Add(TicketDto newTicket)
        {
            TicketDto? ticketFromService = null;
            try
            {
                Ticket? foundTicket = ModelConversion.TicketDtoConvert.ToTicket(newTicket);
                if (foundTicket != null)
                {
                    Ticket createdDbTicket = _ticketAccess.CreateTicket(foundTicket);
                    ticketFromService = ModelConversion.TicketDtoConvert.FromTicket(createdDbTicket);
                }
            }
            catch
            {
                ticketFromService = null;
            }
            return ticketFromService;
        }


        public TicketDto Put(TicketDto ticketToUpdate)
        {
            TicketDto? createdTicket = null;
            try
            {
                Ticket? dbTicket = ModelConversion.TicketDtoConvert.ToTicket(ticketToUpdate);
                if (dbTicket is not null)
                {
                    Ticket createdDbTicket = _ticketAccess.UpdateTicket(dbTicket);
                    createdTicket = ModelConversion.TicketDtoConvert.FromTicket(createdDbTicket);
                }
            }
            catch
            {

                createdTicket = null;
            }
            return createdTicket;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TicketDto? GetTicketByFlightId(int flightId)
        {
            TicketDto? foundTicketDto;
            try
            {
                Ticket? foundTicket = _ticketAccess.GetTicketByFlightId(flightId);
                foundTicketDto = ModelConversion.TicketDtoConvert.FromTicket(foundTicket);
            }
            catch
            {
                foundTicketDto = null;
            }
            return foundTicketDto;
        }
    }
}
