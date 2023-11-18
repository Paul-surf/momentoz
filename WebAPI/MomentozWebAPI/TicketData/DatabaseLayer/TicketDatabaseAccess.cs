using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TicketData.ModelLayer;

namespace TicketData.DatabaseLayer
{
    public class TicketDatabaseAccess : ITicketAccess
    {
        readonly string? _connectionString;

        public TicketDatabaseAccess (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Momentoz");
        }

        //for test
        public TicketDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }
        public int CreateTicket(Ticket aTicket)
        {
            int insertedId = -1;
            //
            string insertString = "insert into Person(firstName, lastName, mobilePhone) OUTPUT INSERTED.ID values(@FirstNam, @LastNam, @MobilePhon)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter fNameParam = new("@FirstNam", aTicket.FirstName);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@LastNam", aTicket.LastName);
                CreateCommand.Parameters.Add(lNameParam);
                SqlParameter mPhoneParam = new("@MobilePhon", aTicket.MobilePhone);
                CreateCommand.Parameters.Add(mPhoneParam);
                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }


        public bool DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
  * A List<Person> with content
  * A List<Person> with no content (no rows found in table)
  * Null - Some error occurred
  */
        public List<Ticket> GetTicketAll()
        {
            List<Ticket> foundTickets;
            Ticket readTicket;
            //
            string queryString = "select id, firstName, lastName, mobilePhone from Ticket";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader ticketReader = readCommand.ExecuteReader();
                // Collect data
                foundTickets = new List<Ticket>();
                while (ticketReader.Read())
                {
                    readTicket = GetTicketFromReader(ticketReader);
                    foundTickets.Add(readTicket);
                }
            }
            return foundTickets;
        }

        private Ticket GetTicketFromReader(SqlDataReader ticketReader)
        {
            Ticket foundTicket;
            int tempId;
            bool isNotNull;     // Test for null value in mobilePhone
            string? tempMobilePhone;
            string tempFirstName, tempLastName;
            // Fetch values
            tempId = ticketReader.GetInt32(ticketReader.GetOrdinal("id"));
            tempFirstName = ticketReader.GetString(ticketReader.GetOrdinal("firstName"));
            tempLastName = ticketReader.GetString(ticketReader.GetOrdinal("lastName"));
            isNotNull = !ticketReader.IsDBNull(ticketReader.GetOrdinal("mobilePhone"));
            tempMobilePhone = isNotNull ? ticketReader.GetString(ticketReader.GetOrdinal("mobilePhone")) : null;
            // Create object
            foundTicket = new Ticket(tempId, tempFirstName, tempLastName, tempMobilePhone);
            return foundTicket;
        }


        /* Three possible returns:
         * A Ticket object
         * An empty Ticket object (no match on id)
         * Null - Some error occurred
        */
        public Ticket GetTicketById(int findId)
        {
            Ticket foundTicket;
            //
            string queryString = "select id, firstName, lastName, mobilePhone from Ticket where id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader ticketReader = readCommand.ExecuteReader();
                foundTicket = new Ticket();
                while (ticketReader.Read())
                {
                    foundTicket = GetTicketFromReader(ticketReader);
                }
            }
            return foundTicket;
        }


        public bool UpdateTicket(Ticket ticketToUpdate)
        {
            throw new NotImplementedException();
        }

    }
}
