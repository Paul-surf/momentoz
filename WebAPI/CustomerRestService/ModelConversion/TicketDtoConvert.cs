using CustomerRestService.DTOs;
using DatabaseData.ModelLayer;
using System.Collections.Generic;

namespace CustomerRestService.ModelConversion
{
    public class TicketDtoConvert
    {
        // Convert from Ticket objects to TicketDTO objects
        public static List<TicketDto> FromTicketCollection(List<Ticket> inTickets)
        {
            var aTicketReadDtoList = new List<TicketDto>();
            foreach (Ticket aTicket in inTickets)
            {
                var tempDto = FromTicket(aTicket);
                aTicketReadDtoList.Add(tempDto);
            }
            return aTicketReadDtoList;
        }

        // Convert from Ticket object to TicketDTO object
        public static TicketDto FromTicket(Ticket inTicket)
        {
            return new TicketDto
            {
                Id = inTicket.Id,
                FirstName = inTicket.FirstName,
                LastName = inTicket.LastName,
                MobilePhone = inTicket.MobilePhone,
                Email = inTicket.Email
            };
        }

        // Convert from TicketDTO object to Ticket object
        public static Ticket ToTicket(TicketDto inDto)
        {
            return new Ticket(inDto.Id, inDto.FirstName, inDto.LastName, inDto.MobilePhone, inDto.Email);
        }
    }
}
