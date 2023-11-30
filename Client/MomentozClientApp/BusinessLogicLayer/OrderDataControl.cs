// Inkluderer nødvendige navneområder for DTOs, modellaget og servicelaget.
using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
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
        public OrderDto? Get(int id)
        {
            OrderDto? foundOrderDto;
            try
            {
                // Forsøger at hente ordren fra data laget og konvertere til OrderDto.
                var foundOrder = _orderAccess.GetOrderById(id).Result;
                return ModelConversion.OrderDtoConvert.FromOrder(foundOrder);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                foundOrderDto = null;
            }
            return foundOrderDto;
        }

        // Metode til at hente alle ordrer og konvertere dem til en liste af OrderDto'er.
        public List<OrderDto>? Get()
        {
            List<OrderDto>? foundDtos;
            try
            {
                // Forsøger at hente alle ordrer og konvertere til OrderDto-liste.
                List<Order>? foundOrders = _orderAccess.GetOrderAll().Result;
                foundDtos = ModelConversion.OrderDtoConvert.FromOrderCollection(foundOrders);
            }
            catch
            {
                // Returnerer null, hvis der opstår en fejl.
                foundDtos = null;
            }
            return foundDtos;
        }

        // Metode til at tilføje en ny ordre og returnere det nye id for den oprettede ordre.
        public int Add(OrderDto orderToAdd)
        {
            int insertedId = 0;
            try
            {
                // Konverterer OrderDto til Order og forsøger at oprette den i databasen.
                Order? foundOrder = ModelConversion.OrderDtoConvert.ToOrder(orderToAdd);
                if (foundOrder != null)
                {
                    return _orderAccess.CreateOrder(foundOrder).Result;
                }
            }
            catch
            {
                // Returnerer -1 som indikator for fejl.
                insertedId = -1;
            }
            return insertedId;
        }

        // Metoder, der endnu ikke er implementeret, og som kaster NotImplementedException.
        public bool Put(OrderDto orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
