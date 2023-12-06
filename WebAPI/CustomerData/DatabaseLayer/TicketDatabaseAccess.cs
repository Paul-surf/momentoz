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

        public Ticket CreateTicket(Ticket aTicket)
        {
            Ticket? createdTicket;
            string insertString = @"insert into Tickets(flightID) 
                                    OUTPUT INSERTED.ID 
                                    values(@Flight)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            { 
                CreateCommand.Parameters.Add(new SqlParameter("@Flight", aTicket.FlightID));

                con.Open();
                CreateCommand.ExecuteScalar();

                createdTicket = GetTicketByFlightId((int)aTicket.FlightID);
            }
            return createdTicket;
        }

        public bool DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }


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

        public Ticket UpdateTicket(Ticket ticketToUpdate)
        {
            Ticket updatedTicket;

            string setVariables = "SET Type = @typ, TicketNumber = @num;";
            string condition = "WHERE FlightID = @id";

            string queryString = "UPDATE Tickets " + setVariables + " " + condition;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepare SQL
                SqlParameter flightParam = new SqlParameter("@id", ticketToUpdate.FlightID);
                SqlParameter typeParam = new SqlParameter("@typ", "test");
                SqlParameter numParam = new SqlParameter("@num", 1069);
                readCommand.Parameters.Add(typeParam);
                readCommand.Parameters.Add(numParam);
                //
                con.Open(); 
                // Execute read
                SqlDataReader ticketReader = readCommand.ExecuteReader();
                updatedTicket = new Ticket();
                while (ticketReader.Read())
                {
                    updatedTicket = GetTicketByFlightId((int)ticketToUpdate.FlightID);
                }
            }
            return updatedTicket;
        }

        public Ticket? GetTicketByFlightId(int flightId)
        {
            Ticket foundTicket;

            string queryString = "SELECT id, type, ticketNumber, baggageId, flightId FROM Tickets WHERE flightId = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", flightId);
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader TicketReader = readCommand.ExecuteReader();
                foundTicket = new Ticket();
                while (TicketReader.Read())
                {
                    foundTicket = GetTicketFromReader(TicketReader);
                }
            }
            return foundTicket;
        }

        private Ticket GetTicketFromReader(SqlDataReader ticketReader)
        {
            int tempId = ticketReader.GetInt32(ticketReader.GetOrdinal("Id"));
            string tempTicketType = ticketReader.GetString(ticketReader.GetOrdinal("Type"));
            int tempTicketNumber = ticketReader.GetInt32(ticketReader.GetOrdinal("TicketNumber"));
            int? tempBaggageID = ticketReader.IsDBNull(ticketReader.GetOrdinal("BaggageID"))
            ? (int?)null : ticketReader.GetInt32(ticketReader.GetOrdinal("BaggageID"));
            int? tempFlightID = ticketReader.IsDBNull(ticketReader.GetOrdinal("FlightID"))
            ? (int?)null : ticketReader.GetInt32(ticketReader.GetOrdinal("FlightID"));


            return new Ticket(tempId, tempTicketType, tempTicketNumber, tempBaggageID, tempFlightID);
        }
    }
}
