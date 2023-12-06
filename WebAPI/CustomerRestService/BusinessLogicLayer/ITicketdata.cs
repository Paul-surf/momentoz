using RESTfulService.DTOs;

namespace RESTfulService.BusinessLogicLayer
{

    public interface ITicketdata
    {
        TicketDto? Get(int id);
        List<TicketDto>? Get();
        TicketDto Add(TicketDto ticketToAdd);
        TicketDto Put(TicketDto ticketToUpdate);
        bool Delete(int id);
        TicketDto? GetTicketByFlightId(int flightId);
    }
}
