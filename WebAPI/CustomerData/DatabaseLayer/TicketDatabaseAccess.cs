using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace DatabaseData.DatabaseLayer
{
    public class TicketDatabaseAccess : ITicketAccess
    {
        readonly string? _connectionString;

        public TicketDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public TicketDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateTicket(Ticket aTicket)
        {
            int insertedId = -1;
            string insertString = @"insert into Ticket(TicketType, TicketNumber) 
                                    OUTPUT INSERTED.ID 
                                    values(@TicketType, @TicketNumber)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                CreateCommand.Parameters.Add(new SqlParameter("@TicketType", aTicket.Type));
                CreateCommand.Parameters.Add(new SqlParameter("@TicketNumber", aTicket.TicketNumber));
/*              CreateCommand.Parameters.Add(new SqlParameter("@Baggage", aTicket.Baggage));
                CreateCommand.Parameters.Add(new SqlParameter("@Flight", aTicket.Flight));*/

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public bool DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        // Other methods like DeleteTicketById, UpdateTicket would be here.

        public List<Ticket> GetTicketAll()
        {
            List<Ticket> foundTickets = new List<Ticket>();
            string queryString = "SELECT id, baggageid, flightid, ticketNumber, type FROM Tickets";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader ticketReader = readCommand.ExecuteReader();
                while (ticketReader.Read())
                {
                    foundTickets.Add(GetTicketFromReader(ticketReader));
                }
            }
            return foundTickets;
        }

        public Ticket GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTicket(Ticket ticketToUpdate)
        {
            throw new NotImplementedException();
        }

        private Ticket GetTicketFromReader(SqlDataReader ticketReader)
        {
            int tempId = ticketReader.GetInt32(ticketReader.GetOrdinal("Id"));
            string tempTicketType = ticketReader.GetString(ticketReader.GetOrdinal("Type"));
            int tempTicketNumber = ticketReader.GetInt32(ticketReader.GetOrdinal("TicketNumber"));

            // Checker om der er bagage på ticket
            int? tempBaggageID = ticketReader.IsDBNull(ticketReader.GetOrdinal("BaggageID"))
            ? (int?)null : ticketReader.GetInt32(ticketReader.GetOrdinal("BaggageID"));

            // Checker om der er FlightID på ticket
            int? tempFlightID = ticketReader.IsDBNull(ticketReader.GetOrdinal("FlightID"))
            ? (int?)null : ticketReader.GetInt32(ticketReader.GetOrdinal("FlightID"));


            return new Ticket(tempId, tempTicketType, tempTicketNumber, tempBaggageID, tempFlightID);
        }

        // The method GetTicketById would be here, similar to GetTicketAll, but with parameterized SQL for a single ID.

    }
}
