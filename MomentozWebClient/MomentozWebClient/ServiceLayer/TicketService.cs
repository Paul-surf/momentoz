using MomentozWebClient.ServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using MomentozWebClient.Models;
using Newtonsoft.Json;

namespace MomentozWebClient.ServiceLayer
{
    public class TicketService : ITicketAccess
    {
        readonly IServiceConnection _ticketServiceConnection;
        public TicketService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _ticketServiceConnection = new ServiceConnection(UseServiceUrl);
        }
        public string UseServiceUrl { get; set; }
        public Task<bool> AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>>? GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetTicketByFlightId(int flightId)
        {
            Ticket? ticketFromService = null;

            _ticketServiceConnection.UseUrl = _ticketServiceConnection.BaseUrl;
            _ticketServiceConnection.UseUrl += "Tickets/" + flightId;


            if (_ticketServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _ticketServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        ticketFromService = JsonConvert.DeserializeObject<Ticket>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            ticketFromService = new Ticket();
                        }
                        else
                        {
                            ticketFromService = null;
                        }
                    }
                }
                catch
                {
                    ticketFromService = null;
                }
            }
            return ticketFromService;
        }

        public Task<bool> UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
