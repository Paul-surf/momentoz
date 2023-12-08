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
                
            string insertString = @"INSERT INTO Orders (TotalPrice, PurchaseDate, CustomerID, FlightID) 
                        OUTPUT INSERTED.OrderID 
                        VALUES (@TotalPrice, @PurchaseDate, @CustomerID, @FlightID)";


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                SqlParameter TotalPriceParam = new("@totalPrice", aOrder.TotalPrice);
                CreateCommand.Parameters.Add(TotalPriceParam);
                SqlParameter PurchaseDateParam = new("@purchaseDate", aOrder.PurchaseDate);
                CreateCommand.Parameters.Add(PurchaseDateParam);
                SqlParameter FlightIDParam = new("@flightID", aOrder.FlightID);
                CreateCommand.Parameters.Add(FlightIDParam);
                SqlParameter CustomerIDParam = new("@customerID", aOrder.CustomerID);
                CreateCommand.Parameters.Add(CustomerIDParam);

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
            string queryString = "SELECT OrderID, TotalPrice, PurchaseDate, CustomerID, FlightID FROM Orders";

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
            int tempOrderID;
            double tempTotalPrice;
            DateTime tempPurchaseDate;
            int tempCustomerID;
            int tempFlightID;

            tempOrderID = orderReader.GetInt32(orderReader.GetOrdinal("OrderID"));
            tempTotalPrice = orderReader.GetDouble(orderReader.GetOrdinal("TotalPrice"));
            tempPurchaseDate = orderReader.GetDateTime(orderReader.GetOrdinal("PurchaseDate"));
            tempCustomerID = orderReader.GetInt32(orderReader.GetOrdinal("CustomerID"));
            tempFlightID = orderReader.GetInt32(orderReader.GetOrdinal("FlightID"));


            foundOrder = new Order(tempOrderID, tempTotalPrice, tempPurchaseDate, tempCustomerID, tempFlightID);
            return foundOrder;
        }

        public Order GetOrderById(int findId)
        {
            Order foundOrder;
         
            string queryString = "SELECT OrderID, TotalPrice, PurchaseDate, CustomerID, FlightID FROM orders WHERE OrderID = @OrderID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@OrderID", findId);
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

            string queryString = "SELECT OrderID, TotalPrice, PurchaseDate, CustomerID, FlightID FROM Orders WHERE CustomerID = @CustomerID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                SqlParameter idParam = new SqlParameter("@CustomerID", customerId);
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

