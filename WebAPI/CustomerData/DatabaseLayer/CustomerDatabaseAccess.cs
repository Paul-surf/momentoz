using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseData.DatabaseLayer
{
    public class CustomerDatabaseAccess : ICustomerAccess
    {
        readonly string? _connectionString;


        public CustomerDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        // For test
        public CustomerDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }


        public int CreateCustomer(Customer aCustomer)
        {
            int insertedId = -1;
            //
            string insertString = "INSERT INTO Customers(firstName, lastName, mobilePhone, email) OUTPUT INSERTED.ID values(@FirstNam, @LastNam, @MobilePhon, @Emai)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter fNameParam = new("@FirstNam", aCustomer.FirstName);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@LastNam", aCustomer.LastName);
                CreateCommand.Parameters.Add(lNameParam);
                SqlParameter mPhoneParam = new("@MobilePhon", aCustomer.MobilePhone);
                CreateCommand.Parameters.Add(mPhoneParam);
                SqlParameter mEmailParam = new("@Emai", aCustomer.Email);
                CreateCommand.Parameters.Add(mEmailParam);
                //
                con.Open();
                // Execute save and read generated key (ID)
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }


        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
          * A List<Person> with content
          * A List<Person> with no content (no rows found in table)
          * Null - Some error occurred
          */
        public List<Customer> GetCustomerAll()
        {
            List<Customer> foundCustomers;
            Customer readCustomer;
            //
            string queryString = "SELECT id, firstName, lastName, mobilePhone, email, loginUserId FROM Customers";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                // Collect data
                foundCustomers = new List<Customer>();
                while (customerReader.Read())
                {
                    readCustomer = GetCustomerFromReader(customerReader);
                    foundCustomers.Add(readCustomer);
                }
            }
            return foundCustomers;
        }

        private Customer GetCustomerFromReader(SqlDataReader customerReader)
        {
            Customer foundCustomer;
            int tempId;
            bool isNotNull;     // Test for null value in mobilePhone
            string? tempMobilePhone;
            string? tempEmail;
            string? tempFirstName, tempLastName, tempUserId;
             
            // Fetch values
            tempId = customerReader.GetInt32(customerReader.GetOrdinal("id"));
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("firstName"));
            tempFirstName = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("firstName")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("lastName"));
            tempLastName = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("lastName")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("mobilePhone"));
            tempMobilePhone = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("mobilePhone")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("email"));
            tempEmail = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("email")) : null;
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("loginUserId"));
            tempUserId = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("loginUserId")) : null;
           
            // Create object
            foundCustomer = new Customer(tempId, tempFirstName, tempLastName, tempMobilePhone, tempEmail, tempUserId);
            return foundCustomer;
        }


        /* Three possible returns:
         * A Person object
         * An empty Person object (no match on id)
         * Null - Some error occurred
        */
        public Customer GetCustomerById(int findId)
        {
            Customer foundCustomer;
            //
            string queryString = "SELECT id, firstName, lastName, mobilePhone, email FROM Customers WHERE id = @Id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetCustomerFromReader(customerReader);
                }
            }
            return foundCustomer;
        }


        public bool UpdateCustomer(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }


        // Finds the customer by loginUserId and NOT id 
        public Customer GetCustomerByUserId(string? findUserId)
        {
            Customer foundCustomer;
            //
            string queryString = "select Id, email from AspNetUsers where loginUserId = @UserId";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@UserId", findUserId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader customerReader = readCommand.ExecuteReader();
                foundCustomer = new Customer();
                while (customerReader.Read())
                {
                    foundCustomer = GetUserFromReader(customerReader);
                }
            }
            return foundCustomer;
        }

        private Customer GetUserFromReader(SqlDataReader customerReader)
        {
            string tempUserId;
            string? tempEmail;
            bool isNotNull;

            tempUserId = customerReader.GetString(customerReader.GetOrdinal("Id"));
            isNotNull = !customerReader.IsDBNull(customerReader.GetOrdinal("email"));
            tempEmail = isNotNull ? customerReader.GetString(customerReader.GetOrdinal("email")) : null;
            
            return new Customer(null, null, null, tempEmail, tempUserId);
        }


        // Save customer with loginUserId and email only
        public Customer CreateCustomerMinimal(Customer aMinimalCustomer)
        {
            Customer createdCustomer;
            //
            string insertString = "insert into Customer(loginUserId, email) values(@loginUserI, @emai)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Prepace SQL
                SqlParameter fNameParam = new("@loginUserI", aMinimalCustomer.LoginUserId);
                CreateCommand.Parameters.Add(fNameParam);
                SqlParameter lNameParam = new("@emai", aMinimalCustomer.Email);
                CreateCommand.Parameters.Add(lNameParam);
                //
                con.Open();
                // Execute save
                CreateCommand.ExecuteNonQuery();
                // Read customer to verify saving was ok
                createdCustomer = GetCustomerByUserId(aMinimalCustomer.LoginUserId);
            }
            return createdCustomer;
        }
    }



}
