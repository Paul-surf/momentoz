using MomentozClientApp.Model;
using MomentozClientApp.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MomentozClientApp.BusinessLogicLayer
{
    // Implementer IOrderdata-interfacet
    public class OrderData : IOrderdata
    {
        private readonly IOrderAccess _orderAccess;

        public OrderData(IOrderAccess orderAccess)
        {
            _orderAccess = orderAccess;
        }

        public Order? Get(int id)
        {
            // Implementer logik for at hente en ordre baseret på ID
            throw new NotImplementedException();
        }

        public List<Order>? Get()
        {
            // Implementer logik for at hente en liste af ordrer
            throw new NotImplementedException();
        }

        public int Add(Order orderToAdd)
        {
            try
            {
                if (orderToAdd != null)
                {
                    // Implementer kode til at tilføje ordren og returnere den indsættelse ID
                    // f.eks., hvis du bruger en database, kan du indsætte ordren og få ID'en
                    int insertedId = -1; /* Dine databaseindsætningsoperationer her */
                    return insertedId;
                }
                return 0;
            }
            catch (Exception ex)
            {
                // Håndter fejl, log fejlen, eller returner en fejlkode efter behov
                return -1;
            }
        }

        public bool Put(Order orderToUpdate)
        {
            // Implementer logik for at opdatere en eksisterende ordre
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            // Implementer logik for at slette en ordre baseret på ID
            throw new NotImplementedException();
        }
    }
}
