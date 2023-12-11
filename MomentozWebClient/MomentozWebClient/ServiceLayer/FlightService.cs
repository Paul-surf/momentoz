using MomentozWebClient.Models;
using Newtonsoft.Json;

namespace MomentozWebClient.ServiceLayer
{
    public class FlightService : IFlightAccess

    {
        readonly IServiceConnection _flightServiceConnection;

        public FlightService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _flightServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Flight>>? GetAllFlights()
        {
            List<Flight>? flightFromService = null;

            _flightServiceConnection.UseUrl = _flightServiceConnection.BaseUrl;
            _flightServiceConnection.UseUrl += "flights";


            if (_flightServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _flightServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        flightFromService = JsonConvert.DeserializeObject<List<Flight>>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            flightFromService = new List<Flight>();
                        }
                        else
                        {
                            flightFromService = null;
                        }
                    }
                }
                catch
                {
                    flightFromService = null;
                }
            }
            return flightFromService;
        }

        public bool AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetFlight(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        Task<Flight> IFlightAccess.GetFlight(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IFlightAccess.AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        Task<bool> IFlightAccess.UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        Task<bool> IFlightAccess.DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }
    }
}
