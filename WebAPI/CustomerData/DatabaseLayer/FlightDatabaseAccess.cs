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

        // For test
        public FlightDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }


        public int CreateFlight(Flight aFlight)
        {
            int insertedId = -1;
            //
            string insertString = "insert into Flight(address, city, price, destinationAddress, destinationCountry) OUTPUT INSERTED.ID values(@Addres, @Cit, @Pric, @DestinationAddres, @DestinationCountr)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter AddressParam = new("@Addres", aFlight.Address);
                CreateCommand.Parameters.Add(AddressParam);
                SqlParameter CityParam = new("@Cit", aFlight.City);
                CreateCommand.Parameters.Add(CityParam);
                SqlParameter PriceParam = new("@Pric", aFlight.Price);
                CreateCommand.Parameters.Add(PriceParam);
                SqlParameter dAddressParam = new("@DestinationAddress", aFlight.DestinationAddress);
                CreateCommand.Parameters.Add(dAddressParam);
                SqlParameter dCountryParam = new("@DestinationCoutr", aFlight.DestinationCountry);
                CreateCommand.Parameters.Add(dCountryParam);
                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }


        public bool DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
          * A List<Person> with content
          * A List<Person> with no content (no rows found in table)
          * Null - Some error occurred
          */
        public List<Flight> GetFlightAll()
        {
            List<Flight> foundFlights;
            Flight readFlight;
            //
            string queryString = "select id, address, city, Price, destinationAddress, destinationCountry from Flight";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader flightReader = readCommand.ExecuteReader();
                // Collect data
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
            // Fetch values
            tempId = flightReader.GetInt32(flightReader.GetOrdinal("id"));
            tempAddress = flightReader.GetString(flightReader.GetOrdinal("address"));
            tempCity = flightReader.GetString(flightReader.GetOrdinal("city"));
            tempPrice = flightReader.GetDouble(flightReader.GetOrdinal("price"));
            tempDestinationAddress = flightReader.GetString(flightReader.GetOrdinal("destinationAddress"));
            tempDestinationCountry = flightReader.GetString(flightReader.GetOrdinal("destinationCountry"));
            // Create object
            foundFlight = new Flight(tempId, tempAddress, tempCity, tempPrice, tempDestinationAddress, tempDestinationCountry);
            return foundFlight;
        }


        /* Three possible returns:
         * A Person object
         * An empty Person object (no match on id)
         * Null - Some error occurred
        */



        public bool UpdateFlight(Flight FlightToUpdate)
        {
            throw new NotImplementedException();
        }

    }



}