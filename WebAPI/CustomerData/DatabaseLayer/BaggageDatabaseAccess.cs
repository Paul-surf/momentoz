using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DatabaseData.DatabaseLayer
{
    public class BaggageDatabaseAccess : IBaggageAccess
    {
        readonly string? _connectionString;

        public BaggageDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public BaggageDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateBaggage(Baggage aBaggage)
        {
            int insertedId = -1; // Antag at -1 repræsenterer en fejltilstand
            string insertString = @"INSERT INTO Baggage(TotalWeight, Price)  
                OUTPUT INSERTED.ID 
                 VALUES(@TotalWeight, @Price)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            
                using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
                {
                    // Opret og tilføj parametre til kommandoen
                    SqlParameter totalWeightParam = new SqlParameter("@TotalWeight", aBaggage.TotalWeight);
                    CreateCommand.Parameters.Add(totalWeightParam);
                    SqlParameter priceParam = new SqlParameter("@Price", aBaggage.Price);
                    CreateCommand.Parameters.Add(priceParam);

                    con.Open();
                    // Execute save and read generated key (ID)
                    insertedId = (int)CreateCommand.ExecuteScalar();
                }
                return insertedId;
            }




        


        public bool DeleteBaggageById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Baggage> GetBaggageAll()
        {
            List<Baggage> foundBaggages = new List<Baggage>();
            Baggage readBaggage;
            string queryString = "SELECT id, totalWeight, Price FROM Baggages";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader baggageReader = readCommand.ExecuteReader();
                foundBaggages = new List<Baggage>();
                while (baggageReader.Read())
                {
                    readBaggage = GetBaggageFromReader(baggageReader);
                    foundBaggages.Add(readBaggage);
                }
            }
            return foundBaggages;
        }

        private Baggage GetBaggageFromReader(SqlDataReader baggageReader)
        {
            Baggage foundBaggage;
            // Deklarer lokale variabler for at opbevare værdierne læst fra readeren
            int tempId;
            double tempTotalWeight;
            double tempPrice;

            // Læs værdierne ved hjælp af GetDouble og GetOrdinal metoderne
            tempId = baggageReader.GetInt32(baggageReader.GetOrdinal("id"));
            tempTotalWeight = baggageReader.GetDouble(baggageReader.GetOrdinal("totalWeight"));
            tempPrice = baggageReader.GetDouble(baggageReader.GetOrdinal("Price"));

            // Opret et nyt Baggage objekt med de læste værdier
             foundBaggage = new Baggage(tempId, tempTotalWeight, tempPrice);

            // Returner det oprettede Baggage objekt
            return foundBaggage;
        }


        public Baggage GetBaggageById(int findId)
        {
            try
            {
                string queryString = "SELECT id, totalWeight, price FROM Baggages WHERE id = @id";
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(queryString, con))
                {
                    SqlParameter idParam = new SqlParameter("@Id", findId);
                    readCommand.Parameters.Add(idParam);
                    con.Open();
                    using (SqlDataReader baggageReader = readCommand.ExecuteReader())
                    {
                        if (baggageReader.Read())
                        {
                            return GetBaggageFromReader(baggageReader);
                        }
                        else
                        {
                            return null; // eller kast en tilpasset exception
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log fejlen, og kast eventuelt videre eller returner null
                Debug.WriteLine("Database error: " + ex.Message);
                return null; // Eller kast en tilpasset exception
            }
        }


        public bool UpdateBaggage(Baggage BaggageToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
