using MomentozClientApp.ModelLayer;
using Newtonsoft.Json;
using System.Configuration;
namespace MomentozClientApp.Servicelayer
{
    public class BaggageAccess : IBaggageAccess
    {
        readonly IServiceConnection _baggageServiceConnection;
        readonly string? _serviceBaseUrl = ConfigurationManager.AppSettings.Get("ServiceUrlToUse");
        public BaggageAccess()
        {
            _baggageServiceConnection = new ServiceConnection(_serviceBaseUrl);
        }
        public async Task<List<Baggage>> GetBaggageAll()
        {
            List<Baggage> listFromService = new List<Baggage>();
            _baggageServiceConnection.UseUrl = _baggageServiceConnection.BaseUrl + "baggages";
            try
            {
                var serviceResponse = await _baggageServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    listFromService = JsonConvert.DeserializeObject<List<Baggage>>(content) ?? listFromService;
                }
            }
            catch
            {
            }
            return listFromService;
        }
        public async Task<Baggage> GetBaggageById(int id)
        {
            Baggage foundBaggage = null;
            _baggageServiceConnection.UseUrl = _baggageServiceConnection.BaseUrl + "baggages/" + id;
            try
            {
                var serviceResponse = await _baggageServiceConnection.CallServiceGet();
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    foundBaggage = JsonConvert.DeserializeObject<Baggage>(content);
                }
            }
            catch
            {
            }
            return foundBaggage;
        }
        public Task<int> CreateBaggage(string newUsername, Baggage baggage)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateBaggage(Baggage baggage)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBaggageById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> CreateBaggage(Baggage baggage)
        {
            throw new NotImplementedException();
        }
    }
}