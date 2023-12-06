// Inkluderer nødvendige navneområder for DTOs, modellaget og servicelaget.

using MomentozClientApp.Model;
using MomentozClientApp.ServiceLayer;

// Definerer navneområdet for forretningslogiklaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // OrderdataControl-klassen implementerer IOrderdata-interface og håndterer logikken omkring ordrer.
    public class OrderdataControl : IOrderdata
    {
        // En skrivebeskyttet reference til IOrderAccess for at interagere med ordre data.
        private readonly IOrderAccess _orderAccess;

        // Konstruktøren initialiserer OrderdataControl med en IOrderAccess instans.
        public OrderdataControl(IOrderAccess inOrderAccess)
        {
            _orderAccess = inOrderAccess;
        }

        // Metode til at hente en specifik ordre baseret på dens id og konvertere den til en OrderDto.
        public Order? Get(int id)
        {
            
            try
            {
                // Forsøger at hente ordren fra data laget og konvertere til OrderDto.
                return _orderAccess.GetOrderById(id).Result;
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                return null;
            }
          
        }

        // Metode til at hente alle ordrer og konvertere dem til en liste af OrderDto'er.
        public List<Order>? Get()
        {
            List<Order>? foundOrders;
            try
            {
                return _orderAccess.GetOrderAll().Result;
            }
            catch
            {
                return null;
            }
        }

        // Metode til at tilføje en ny ordre og returnere det nye id for den oprettede ordre.
        public int Add(Order orderToAdd)
        {

            try
            {
                if (orderToAdd != null)
                {
                    return _orderAccess.CreateOrder(orderToAdd).Result;
                }
                return 0;
            }
            catch
                {
                return -1;
                }
            }
          
        

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public bool Put(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order? GetOrderById(int id)
        {
            try
            {
                return _orderAccess.GetOrderById(id).Result;
            }
            catch
            {
                return null;
            }
        }
    }


}
