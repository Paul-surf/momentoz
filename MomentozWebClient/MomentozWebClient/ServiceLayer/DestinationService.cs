using MomentozWebClient.Models;
using Newtonsoft.Json;

namespace MomentozWebClient.ServiceLayer
{
    public class DestinationService : IDestinationAccess

    {
        readonly IServiceConnection _destinationServiceConnection;

        public DestinationService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _destinationServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Destination>>? GetAllDestinations()
        {
            List<Destination>? destinationsFromService = null;

            _destinationServiceConnection.UseUrl = _destinationServiceConnection.BaseUrl;
            _destinationServiceConnection.UseUrl += "destinations";


            if (_destinationServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _destinationServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        destinationsFromService = JsonConvert.DeserializeObject<List<Destination>>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            destinationsFromService = new List<Destination>();
                        }
                        else
                        {
                            destinationsFromService = null;
                        }
                    }
                }
                catch
                {
                    destinationsFromService = null;
                }
            }
            return destinationsFromService;
        }









        public bool AddDestination(Destination destination)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDestination(int id)
        {
            throw new NotImplementedException();
        }



        public Customer GetDestination(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDestination(Destination destination)
        {
            throw new NotImplementedException();
        }

        Task<Customer> IDestinationAccess.GetDestination(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDestinationAccess.AddDestination(Destination destination)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDestinationAccess.UpdateDestination(Destination destination)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDestinationAccess.DeleteDestination(int id)
        {
            throw new NotImplementedException();
        }
    }
}
