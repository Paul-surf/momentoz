namespace MomentozWebClient.Controllers
{
    public class DestinationLogic
    {


        private readonly DestinationService _destinationServiceAccess;

        public Destination(IConfiguration inConfiguration)
        {
            _destinationServiceAccess = new DestinationService(inConfiguration);
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            List<Destination> foundDestinations;
            try
            {
                foundDestinations = await _destinationServiceAccess.GetAlDestinations();
            }
            catch
            {
                foundDestinations = null;
            }
            return foundDestinations;
        }
    }
}
