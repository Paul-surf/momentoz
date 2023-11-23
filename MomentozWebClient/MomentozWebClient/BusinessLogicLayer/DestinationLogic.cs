using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class DestinationLogic
    {


        private readonly DestinationService _destinationServiceAccess;

        public DestinationLogic(IConfiguration inConfiguration)
        {
            _destinationServiceAccess = new DestinationService(inConfiguration);
        }

        

        public async Task<List<Destination>> GetAllDestinations()
        {
            List<Destination> foundDestinations;
            try
            {
                foundDestinations = await _destinationServiceAccess.GetAllDestinations();
            }
            catch
            {
                foundDestinations = null;
            }
            return foundDestinations;
        }
    }
}
