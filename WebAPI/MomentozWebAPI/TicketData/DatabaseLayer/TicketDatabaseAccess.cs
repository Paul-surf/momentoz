<<<<<<< Updated upstream
﻿using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TicketData.ModelLayer;
=======
﻿using Microsoft.Extensions.Configuration;
using TicketData.ModelLayer;
using Microsoft.Data.SqlClient;
using System.Net.Sockets;
>>>>>>> Stashed changes

namespace TicketData.DatabaseLayer
{
    public class TicketDatabaseAccess : ITicketAccess
    {
        readonly string? _connectionString;

<<<<<<< Updated upstream
        public TicketDatabaseAccess (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Momentoz");
        }

        //for test
=======

        public TicketDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        // For test
>>>>>>> Stashed changes
        public TicketDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }
<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
        public int CreateTicket(Ticket aTicket)
        {
            int insertedId = -1;
            //
<<<<<<< Updated upstream
            string insertString = "insert into Person(firstName, lastName, mobilePhone) OUTPUT INSERTED.ID values(@FirstNam, @LastNam, @MobilePhon)";
=======
            string insertString = "insert into Ticket(firstName, lastName, mobilePhone, email) OUTPUT INSERTED.ID values(@FirstNam, @LastNam, @MobilePhon, @Emai)";
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
                SqlParameter mEmailParam = new("@Emai", aTicket.Email);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
  * A List<Person> with content
  * A List<Person> with no content (no rows found in table)
  * Null - Some error occurred
  */
=======
          * A List<Person> with content
          * A List<Person> with no content (no rows found in table)
          * Null - Some error occurred
          */
>>>>>>> Stashed changes
        public List<Ticket> GetTicketAll()
        {
            List<Ticket> foundTickets;
            Ticket readTicket;
            //
<<<<<<< Updated upstream
            string queryString = "select id, firstName, lastName, mobilePhone from Ticket";
=======
            string queryString = "select id, firstName, lastName, mobilePhone, email from Ticket";
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
            string? tempEmail;
>>>>>>> Stashed changes
            string tempFirstName, tempLastName;
            // Fetch values
            tempId = ticketReader.GetInt32(ticketReader.GetOrdinal("id"));
            tempFirstName = ticketReader.GetString(ticketReader.GetOrdinal("firstName"));
            tempLastName = ticketReader.GetString(ticketReader.GetOrdinal("lastName"));
            isNotNull = !ticketReader.IsDBNull(ticketReader.GetOrdinal("mobilePhone"));
<<<<<<< Updated upstream
            tempMobilePhone = isNotNull ? ticketReader.GetString(ticketReader.GetOrdinal("mobilePhone")) : null;
            // Create object
            foundTicket = new Ticket(tempId, tempFirstName, tempLastName, tempMobilePhone);
=======
            tempEmail = ticketReader.GetString(ticketReader.GetOrdinal("email"));
            tempMobilePhone = isNotNull ? ticketReader.GetString(ticketReader.GetOrdinal("mobilePhone")) : null;

            // Create object
            foundTicket = new Ticket(tempId, tempFirstName, tempLastName, tempMobilePhone, tempEmail);
>>>>>>> Stashed changes
            return foundTicket;
        }


        /* Three possible returns:
<<<<<<< Updated upstream
         * A Ticket object
         * An empty Ticket object (no match on id)
=======
         * A Person object
         * An empty Person object (no match on id)
>>>>>>> Stashed changes
         * Null - Some error occurred
        */
        public Ticket GetTicketById(int findId)
        {
            Ticket foundTicket;
            //
<<<<<<< Updated upstream
            string queryString = "select id, firstName, lastName, mobilePhone from Ticket where id = @Id";
=======
            string queryString = "select id, firstName, lastName, mobilePhone, email from Ticket where id = @Id";
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======



>>>>>>> Stashed changes
}
