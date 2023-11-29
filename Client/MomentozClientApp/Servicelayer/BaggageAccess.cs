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
                // Log the exception or handle it as needed
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
                // Log the exception or handle it as needed
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
        // ... Resten af dine metoder her ...
        // Implementer de andre metoder baseret på interfacets krav, som du har gjort med GetBaggages og GetBaggageById
        // Husk at implementere alle metoder fra interfacet, også dem du måske endnu ikke har brug for; du kan markere dem med NotImplementedException(), indtil du har deres implementering klar.
    }
}