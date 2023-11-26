﻿using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace DatabaseData.DatabaseLayer
{
    public class FlightDatabaseAccess : IFlightAccess
    {
        readonly string? _connectionString;

        public FlightDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public FlightDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateFlight(Flight aFlight)
        {
            int insertedId = -1;
            // Corrected the parameter names in the SQL command
            string insertString = "insert into Flight(address, city, price, destinationAddress, destinationCountry) OUTPUT INSERTED.ID values(@Address, @City, @Price, @DestinationAddress, @DestinationCountry)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Corrected the parameter names to match the SQL command
                SqlParameter AddressParam = new("@Address", aFlight.Address);
                CreateCommand.Parameters.Add(AddressParam);
                SqlParameter CityParam = new("@City", aFlight.City);
                CreateCommand.Parameters.Add(CityParam);
                SqlParameter PriceParam = new("@Price", aFlight.Price);
                CreateCommand.Parameters.Add(PriceParam);
                SqlParameter dAddressParam = new("@DestinationAddress", aFlight.DestinationAddress);
                CreateCommand.Parameters.Add(dAddressParam);
                SqlParameter dCountryParam = new("@DestinationCountry", aFlight.DestinationCountry);
                CreateCommand.Parameters.Add(dCountryParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public bool DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetFlightAll()
        {
            List<Flight> foundFlights;
            Flight readFlight;
            string queryString = "select id, address, city, price, destinationAddress, destinationCountry from Flights";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader flightReader = readCommand.ExecuteReader();
                foundFlights = new List<Flight>();
                while (flightReader.Read())
                {
                    readFlight = GetFlightFromReader(flightReader);
                    foundFlights.Add(readFlight);
                }
            }
            return foundFlights;
        }

        private Flight GetFlightFromReader(SqlDataReader flightReader)
        {
            Flight foundFlight;
            int tempId;
            string tempAddress;
            string tempCity;
            double tempPrice;
            string tempDestinationAddress;
            string tempDestinationCountry;

            tempId = flightReader.GetInt32(flightReader.GetOrdinal("id"));
            tempAddress = flightReader.GetString(flightReader.GetOrdinal("address"));
            tempCity = flightReader.GetString(flightReader.GetOrdinal("city"));
            tempPrice = flightReader.GetDouble(flightReader.GetOrdinal("price"));
            tempDestinationAddress = flightReader.GetString(flightReader.GetOrdinal("destinationAddress"));
            tempDestinationCountry = flightReader.GetString(flightReader.GetOrdinal("destinationCountry"));

            foundFlight = new Flight(tempId, tempAddress, tempCity, tempPrice, tempDestinationAddress, tempDestinationCountry);
            return foundFlight;
        }

        public Flight GetFlightById(int findId)
        {
            Flight foundFlight;
            string queryString = "select id, address, city, price, destinationAddress, destinationCountry from Flights where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);

                con.Open();
                SqlDataReader flightReader = readCommand.ExecuteReader();

                if (flightReader.Read())
                {
                    foundFlight = GetFlightFromReader(flightReader);
                }
                else
                {
                    return null; // No record found
                }
            }
            return foundFlight;
        }

        public bool UpdateFlight(Flight FlightToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
