using Microsoft.Extensions.Configuration;
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
            List<Flight> foundFlights;
            Flight readFlight;
            string queryString = "SELECT id, departure, price, destinationAddress, destinationCountry FROM Flights";
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
            int tempFlightID;
            string tempDeparture;
            string tempCity;
            double tempPrice;
            string tempDestinationAddress;
            string tempDestinationCountry;
            DateTime tempHomeTrip;

            tempFlightID = flightReader.GetInt32(flightReader.GetOrdinal("orderid"));
            tempDeparture = flightReader.GetString(flightReader.GetOrdinal("departure"));
            tempPrice = flightReader.GetDouble(flightReader.GetOrdinal("price"));
            tempDestinationAddress = flightReader.GetString(flightReader.GetOrdinal("destinationAddress"));
            tempDestinationCountry = flightReader.GetString(flightReader.GetOrdinal("destinationCountry"));
            tempHomeTrip = flightReader.GetDateTime(flightReader.GetOrdinal("tempcity"));

            foundFlight = new Flight(tempDeparture, tempPrice, tempDestinationAddress, tempDestinationCountry, tempHomeTrip);
            return foundFlight;
        }//      public Flight(string departure, double price, string destinationAddress, string destinationCountry, string? homeTrip)

        public Flight GetFlightById(int flightId)
        {
            Flight foundFlight = new Flight();
            string queryString = "SELECT id, departure, price, destinationAddress, destinationCountry FROM Flights WHERE Id = @Id";

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
                     //   foundFlight.IsBooked = reader.GetBoolean(reader.GetOrdinal("IsBooked"));

                    }
                }
            }
            return foundFlight;
        }

        public bool UpdateFlight(Flight flightToUpdate)
        {
            int rowsAffected = 0;
            string updateString = "UPDATE Flights SET IsBooked = @IsBooked WHERE Id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand updateCommand = new SqlCommand(updateString, con))
            {
                con.Open();
           //     updateCommand.Parameters.AddWithValue("@IsBooked", flightToUpdate.IsBooked);
                updateCommand.Parameters.AddWithValue("@Id", flightToUpdate.FlightID);

                rowsAffected = updateCommand.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }

  

    }
}
