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

            string insertString = "INSERT INTO Flight(departure, price, destinationAddress, destinationCountry) OUTPUT INSERTED.ID values(@Address, @City, @Price, @DestinationAddress, @DestinationCountry)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter AddressParam = new("@Departure", aFlight.Departure);
                CreateCommand.Parameters.Add(AddressParam);
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
            List<Flight> foundFlights = new List<Flight>();

            try
            {
                string info = "FlightID, Departure, DestinationAddress, DestinationCountry, Price";
                string table = "Flights";
                string whereStatement = "FlightID not in (SELECT FlightID From Orders)";

                string queryString = "SELECT " + info + " FROM " + table + " WHERE " + whereStatement;

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(queryString, con))
                {
                    con.Open();
                    SqlDataReader flightReader = readCommand.ExecuteReader();

                    while (flightReader.Read())
                    {
                        Flight readFlight = GetFlightFromReader(flightReader);
                        foundFlights.Add(readFlight);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return foundFlights;
        }


        private Flight GetFlightFromReader(SqlDataReader flightReader)
        {
            Flight foundFlight;
            int tempFlightID;
            string tempDeparture;
            double tempPrice;
            string tempDestinationAddress;
            string tempDestinationCountry;
            bool isNotNull;

            tempFlightID = flightReader.GetInt32(flightReader.GetOrdinal("FlightID"));
            tempDeparture = flightReader.GetString(flightReader.GetOrdinal("Departure"));
            tempDestinationAddress = flightReader.GetString(flightReader.GetOrdinal("DestinationAddress"));
            tempDestinationCountry = flightReader.GetString(flightReader.GetOrdinal("DestinationCountry"));

            tempPrice = flightReader.GetDouble(flightReader.GetOrdinal("Price"));
            foundFlight = new Flight(tempFlightID, tempDeparture, tempDestinationAddress, tempDestinationCountry, tempPrice);
            return foundFlight;
        }

        public Flight GetFlightById(int flightId)
        {
            Flight foundFlight = new Flight();
            string queryString = "SELECT flightid, departure, price, destinationAddress, destinationCountry FROM Flights WHERE Id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                readCommand.Parameters.AddWithValue("@Id", flightId);

                using (SqlDataReader reader = readCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        foundFlight.FlightID = reader.GetInt32(reader.GetOrdinal("Id"));
                        foundFlight.Departure = reader.GetString(reader.GetOrdinal("Departure"));
                        foundFlight.DestinationAddress = reader.GetString(reader.GetOrdinal("DestinationAddress"));
                        foundFlight.DestinationCountry = reader.GetString(reader.GetOrdinal("DestinationCountry"));

                    }
                }
            }
            return foundFlight;
        }



    }
}
