using MomentozClientApp.ModelLayer;
using MomentozClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.Servicelayer
{

    public interface IFlightAccess
    {
        Task<Flight> GetFlightById(int id);
        Task<List<Flight>> GetFlightAll();
        Task<int> CreateFlight(Flight flight);
        Task<bool> UpdateFlight(Flight flight);
        Task<bool> DeleteFlightById(int id);
        Task<Flight> GetFlightByUserId(string loginUserId);
    }
}

