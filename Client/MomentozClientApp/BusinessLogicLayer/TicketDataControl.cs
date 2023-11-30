using MomentozClientApp.DTOs;
using MomentozClientApp.Servicelayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    // Klassen TicketdataControl implementerer ITicketdata-interfacet og styrer billetdata
    public class TicketdataControl : ITicketdata
    {
        private readonly ITicketAccess _ticketAccess;

        // Konstruktør, der modtager en ITicketAccess som parameter
        public TicketdataControl(ITicketAccess inTicketAccess)
        {
            _ticketAccess = inTicketAccess;
        }

        // Metode til at hente en billet baseret på ID
        public TicketDto? Get(int id)
        {
            try
            {
                // Forsøger at hente en billet baseret på ID
                var foundTicket = _ticketAccess.GetTicketById(id).Result;
                return ModelConversion.TicketDtoConvert.FromTicket(foundTicket); // Konverterer til TicketDto og returnerer
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }

        // Metode til at hente en liste af billetter
        public List<TicketDto>? Get()
        {
            try
            {
                // Forsøger at hente alle billetter
                var foundTickets = _ticketAccess.GetTicketAll().Result;
                return ModelConversion.TicketDtoConvert.FromTicketCollection(foundTickets); // Konverterer til en liste af TicketDto'er og returnerer
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }

        // Metode til at tilføje en ny billet
        public int Add(TicketDto ticketToAdd)
        {
            try
            {
                // Forsøger at konvertere TicketDto til en billet og oprette den
                var newTicket = ModelConversion.TicketDtoConvert.ToTicket(ticketToAdd);
                if (newTicket != null)
                {
                    return _ticketAccess.CreateTicket(newTicket).Result; // Oprettelse af billet og returnerer dens ID
                }
                return 0; // Returnerer 0, hvis konverteringen mislykkes
            }
            catch
            {
                return -1; // Håndterer eventuelle fejl ved at returnere -1
            }
        }

        // Metode til at opdatere en eksisterende billet (ikke implementeret)
        public bool Put(TicketDto ticketToUpdate)
        {
            {
                throw new NotImplementedException(); // Kaster en NotImplementedException, da metoden ikke er implementeret endnu
            }
        }

        // Metode til at slette en billet baseret på ID (ikke implementeret)
        public bool Delete(int id)
        {
            throw new NotImplementedException(); // Kaster en NotImplementedException, da metoden ikke er implementeret endnu
        }

        // Metode til at hente en billet baseret på ID
        public TicketDto? GetTicketById(int id)
        {
            try
            {
                // Forsøger at hente en billet baseret på ID
                var foundTicket = _ticketAccess.GetTicketById(id).Result;
                return foundTicket != null ? ModelConversion.TicketDtoConvert.FromTicket(foundTicket) : null; // Konverterer til TicketDto og returnerer eller returnerer null hvis billetten ikke findes
            }
            catch
            {
                return null; // Håndterer eventuelle fejl ved at returnere null
            }
        }
    }
}
