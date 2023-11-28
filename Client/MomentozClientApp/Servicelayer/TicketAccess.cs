using MomentozClientApp.Model;
using MomentozClientApp.ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{
    public class TicketAccess : ITicketAccess
    {
        readonly IServiceConnection _ticketServiceConnection;
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");

        public TicketAccess()
        {
            _ticketServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public async Task<List<Ticket>> GetTicketAll()
        {
            List<Ticket> listFromService = new List<Ticket>();
            _ticketServiceConnection.UseUrl = _ticketServiceConnection.BaseUrl + "tickets";

            try
            {
                var serviceResponse = await _ticketServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Ticket>>(content) ?? listFromService;
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return listFromService;
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            Ticket foundTicket = null;
            _ticketServiceConnection.UseUrl = _ticketServiceConnection.BaseUrl + "tickets" + id;

            try
            {
                var serviceResponse = await _ticketServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundTicket = JsonConvert.DeserializeObject<Ticket>(content);
                }
            }
            catch
            {
                // Log the exception or handle it as needed
            }

            return foundTicket;
        }

        public Task<int> CreateTicket(string newUsername, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }



        public Task<int> CreateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        // ... Resten af dine metoder her ...

        // Implementer de andre metoder baseret på interfacets krav, som du har gjort med GetTickets og GetTicketById
        // Husk at implementere alle metoder fra interfacet, også dem du måske endnu ikke har brug for; du kan markere dem med NotImplementedException(), indtil du har deres implementering klar.
    }
}
