
using CustomerRestService.DTOs;
using TicketData.ModelLayer;

namespace CustomerRestService.ModelConversion
{

    public class TicketDtoConvert
    {

        // Convert from Ticket objects to TicketDTO objects
        public static List<TicketDto>? FromTicketCollection(List<Ticket> inTickets)
        {
            List<TicketDto>? aTicketReadDtoList = null;
            if (inTickets != null)
            {
                aTicketReadDtoList = new List<TicketDto>();
                TicketDto? tempDto;
                foreach (Ticket aTicket in inTickets)
                {
                    if (aTicket != null)
                    {
                        tempDto = FromTicket(aTicket);
                        aTicketReadDtoList.Add(tempDto);
                    }
                }
            }
            return aTicketReadDtoList;
        }

        // Convert from Ticket object to PersonDTO object
        public static Ticket? FromTicket(Ticket inTicket)
        {
            Ticket? aTicketReadDto = null;
            if (inTicket != null)
            {
                aTicketReadDto = new Ticket(inTicket.FirstName, inTicket.LastName, inTicket.MobilePhone);
            }
            return aTicketReadDto;
        }

        // Convert from PersonDTO object to Ticket object
        public static Ticket? ToTicket(Ticket inDto)
        {
            Ticket? aTicket = null;
            if (inDto != null)
            {
                aTicket = new Ticket(inDto.FirstName, inDto.LastName, inDto.MobilePhone);
            }
            return aTicket;
        }
    }

}