using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MomentozClientApp.Servicelayer
{
    public interface IBaggageAccess
    {
        Task<Baggage> GetBaggageById(int id);
        Task<List<Baggage>> GetBaggageAll();
        Task<int> CreateBaggage(Baggage baggage);
        Task<bool> UpdateBaggage(Baggage baggage);
        Task<bool> DeleteBaggageById(int id);
    }
} 