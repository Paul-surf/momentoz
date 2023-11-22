using MomentozWebClient.Models;

namespace MomentozWebClient.ServiceLayer
{
    public interface IDestinationAccess
    {

        Task<List<Destination>>? GetAllDestinations();

        Task<Customer> GetDestination(int id);

        Task<bool> AddDestination(Destination destination);

        Task<bool> UpdateDestination(Destination destination);

        Task<bool> DeleteDestination(int id);
    }
}

