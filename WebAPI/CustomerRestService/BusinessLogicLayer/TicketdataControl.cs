using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;
using System;
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


        public int Add(TicketDto newTicket)
        {
            int insertedId = 0;
            try
            {
                Ticket? foundTicket = ModelConversion.TicketDtoConvert.ToTicket(newTicket);
                if (foundTicket != null)
                {
                    insertedId = _ticketAccess.CreateTicket(foundTicket);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }


        public bool Put(TicketDto ticketToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
