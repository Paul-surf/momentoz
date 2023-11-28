using MomentozClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.ModelConversion
{
    public class FlightDtoConvert
    {

        // Convert from Flight objects to FlightDTO objects
        public static List<DTOs.FlightDto>? FromFlightCollection(List<Flight> inFlights)
        {
            List<DTOs.FlightDto>? aFlightReadDtoList = null;
            if (inFlights != null)
            {
                aFlightReadDtoList = new List<DTOs.FlightDto>();
                DTOs.FlightDto? tempDto;
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

        // Convert from Flight object to FlightDTO object
        public static DTOs.FlightDto? FromFlight(Flight inFlight)
        {
            DTOs.FlightDto? aFlightReadDto = null;
            if (inFlight != null)
            {
                aFlightReadDto = new DTOs.FlightDto(inFlight.Address, inFlight.City, inFlight.Price, inFlight.DestinationAddress, inFlight.DestinationCountry);
            }
            return aFlightReadDto;
        }

        // Convert from FlightDTO object to Flight object
        public static Flight? ToFlight(DTOs.FlightDto inDto)
        {
            Flight? aFlight = null;
            if (inDto != null)
            {
                aFlight = new Flight(inDto.Address, inDto.City, inDto.Price, inDto.DestinationAddress, inDto.DestinationCountry);
            }
            return aFlight;
        }
    }
}
