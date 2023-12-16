using MomentozAPITests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MomentozAPITests
{
    public class FlightApiTests
    {
        [Fact]
        public async void GetFlights_Should_Return_Ok()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/flights";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            // You can further assert the content, assuming it's JSON
            var content = await response.Content.ReadAsStringAsync();
            var flightList = System.Text.Json.JsonSerializer.Deserialize<List<FlightDto>>(content);
            Assert.NotNull(flightList);
            Assert.True(flightList.Count > 0);
        }
        [Fact]
        public async void GetFlightsWithoutTestFlights()
        {
            // Arrange
            using var client = new HttpClient();
            var apiUrl = "https://localhost:5114/api/flights";
            FlightDto flight = new FlightDto();
            flight.Departure = "test";
            flight.Price = 1234;
            flight.DestinationAddress = "test123";
            flight.DestinationCountry = "test";

            // Act
            var response = await client.GetAsync(apiUrl);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            // setup flight til JSON format
            var JSONflight = JsonConvert.SerializeObject(flight);
            var inContent = new StringContent(JSONflight, Encoding.UTF8, "application/json");
            // Post flight til DB
            var serviceResponse = await client.PostAsync(apiUrl, inContent);

            // Assert
            Assert.True(serviceResponse.IsSuccessStatusCode);


            /*var content = await response.Content.ReadAsStringAsync();
            var flightList = JsonSerializer.Deserialize<List<FlightDto>>(content);
            Assert.NotNull(flightList);
            Assert.True(flightList.Count > 0);*/
        }
    }
}
