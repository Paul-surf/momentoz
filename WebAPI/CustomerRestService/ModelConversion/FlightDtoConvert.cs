        using DatabaseData.ModelLayer;
using RESTfulService.DTOs;

namespace RESTfulService.ModelConversion
        {
        public class FlightDtoConvert
        {
        public static List<FlightDto>? FromFlightCollection(List<Flight> inFlights)
        {
            List<FlightDto>? aFlightReadDtoList = null;
            if (inFlights != null)
            {
               FlightDto? tempDto;
                foreach (Flight aFlight in inFlights)
                {
                    if (aFlight != null)
                    {
                        tempDto = FromFlight(aFlight);
                        aFlightReadDtoList.Add(tempDto);
                    }
                }
            }
            return aFlightReadDtoList;
        }
        public static DTOs.FlightDto? FromFlight(Flight inFlight)
        {
            DTOs.FlightDto? aFlightReadDto = null;
            if (inFlight != null)
            {
                aFlightReadDto = new DTOs.FlightDto(inFlight.FlightID, inFlight.Departure, inFlight.DestinationAddress, inFlight.DestinationCountry, inFlight.HomeTrip, inFlight.Price);
            }
            return aFlightReadDto;
        }
        public static Flight? ToFlight(FlightDto inDto)
        {
            Flight? aFlight = null;
            if (inDto != null)
            {
                aFlight = new Flight(inDto.Departure,  inDto.DestinationAddress, inDto.DestinationCountry, inDto.HomeTrip, inDto.Price);
            }
            return aFlight;
        }
    }
}
