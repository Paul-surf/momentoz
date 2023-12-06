using Microsoft.Extensions.Configuration;
using DatabaseData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace DatabaseData.DatabaseLayer
{
    public class OrderDatabaseAccess : IOrderAccess
    {
        readonly string? _connectionString;

        public OrderDatabaseAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MomentozConnection");
        }

        public OrderDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        public int CreateOrder(Order aOrder)
        {
            int insertedId = -1;
            string insertString = @"insert into Orders(ticketID) 
                                    OUTPUT INSERTED.ID 
                                    values(@ticketID)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                
                SqlParameter FlightIDParam = new("@FlightID", aOrder.FlightID);
                CreateCommand.Parameters.Add(FlightIDParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public bool DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderAll()
        {
            List<Order> foundOrders = new List<Order>();
            Order readOrder;
            string queryString = "SELECT id, totalPrice, purchaseDate, customerID, FlightID FROM orders";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                SqlDataReader orderReader = readCommand.ExecuteReader();
                foundOrders = new List<Order>();
                while (orderReader.Read())
                {
                    readOrder = GetOrderFromReader(orderReader);
                    foundOrders.Add(GetOrderFromReader(orderReader));
                }
            }
            return foundOrders;
        }
        private Order GetOrderFromReader(SqlDataReader orderReader)
        {

            Order foundOrder;
            int tempId;
            double tempTotalPrice;
            DateTime tempPurchaseDate;
            int tempCustomerID;
            int tempFlightID;

            tempId = orderReader.GetInt32(orderReader.GetOrdinal("id"));
            tempTotalPrice = orderReader.GetDouble(orderReader.GetOrdinal("totalprice"));
            tempPurchaseDate = orderReader.GetDateTime(orderReader.GetOrdinal("purchasedate"));
            tempCustomerID = orderReader.GetInt32(orderReader.GetOrdinal("customerID"));
            tempFlightID = orderReader.GetInt32(orderReader.GetOrdinal("flightID"));


            foundOrder = new Order(tempId, tempTotalPrice, tempPurchaseDate, tempCustomerID, tempFlightID);
            return foundOrder;
        }

        public Order GetOrderById(int findId)
        {
            Order foundOrder;
         
            string queryString = "SELECT id, totalPrice, purchaseDate, customerID, flightID FROM orders WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                
                con.Open();
               
                SqlDataReader orderReader = readCommand.ExecuteReader();
                foundOrder = new Order();
                while (orderReader.Read())
                {
                    foundOrder = GetOrderFromReader(orderReader);
                }
            }
            return foundOrder;
        }

        public bool UpdateOrder(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        Order? IOrderAccess.GetOrderByCustomerId(int customerId)
        {
            Order foundOrder;

            string queryString = "SELECT id, totalPrice, purchaseDate, customerID, flightID FROM orders WHERE CustomerID = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@Id", "@Id");
                readCommand.Parameters.Add(idParam);

                con.Open();

                SqlDataReader orderReader = readCommand.ExecuteReader();
                foundOrder = new Order();
                while (orderReader.Read())
                {
                    foundOrder = GetOrderFromReader(orderReader);
                }
            }
            return foundOrder;
        }
    }
}

