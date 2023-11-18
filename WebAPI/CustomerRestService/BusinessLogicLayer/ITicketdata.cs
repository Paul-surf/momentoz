using CustomerRestService.DTOs;

namespace CustomerRestService.BusinessLogicLayer
{

    public interface ITicketdata
    {

        TicketDto? Get(int id);
        List<TicketDto>? Get();
        int Add(TicketDto ticketToAdd);
        bool Put(TicketDto ticketToUpdate);
        bool Delete(int id);

    }
}
