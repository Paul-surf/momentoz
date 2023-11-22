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

        internal static Task<List<Destination>?> GetAllDestinations()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Destination>> GetAllDestination()
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
