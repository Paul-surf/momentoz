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
            string insertString = @"insert into Order(totalPrice, purchaseDate, customerID, ticketID) 
                                    OUTPUT INSERTED.ID 
                                    values(@totalPrice, @purchateDate, @customerID, @ticketID)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
            {
                // Corrected the parameter names to match the SQL command
                SqlParameter TotalPriceParam = new("@TotalPrice", aOrder.TotalPrice);
                CreateCommand.Parameters.Add(TotalPriceParam);
                SqlParameter PurchaseDateParam = new("@PurchaseDate", aOrder.PurchaseDate);
                CreateCommand.Parameters.Add(PurchaseDateParam);
                SqlParameter CustomerIDParam = new("@CustomerID", aOrder.CustomerID);
                CreateCommand.Parameters.Add(CustomerIDParam);
                SqlParameter TicketIDParam = new("@TicketID", aOrder.TicketID);
                CreateCommand.Parameters.Add(TicketIDParam);

                con.Open();
                insertedId = (int)CreateCommand.ExecuteScalar();
            }
            return insertedId;
        }

        public bool DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        // Other methods like DeleteOrderById, UpdateTicket would be here.

        public List<Order> GetOrderAll()
        {
            List<Order> foundOrders = new List<Order>();
            Order readOrder;
            string queryString = "SELECT id, totalPrice, purchaseDate, customerID, ticketid FROM orders";

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
            int tempTicketID;

            tempId = orderReader.GetInt32(orderReader.GetOrdinal("id"));
            tempTotalPrice = orderReader.GetDouble(orderReader.GetOrdinal("totalprice"));
            tempPurchaseDate = orderReader.GetDateTime(orderReader.GetOrdinal("purchasedate"));
            tempCustomerID = orderReader.GetInt32(orderReader.GetOrdinal("customerID"));
            tempTicketID = orderReader.GetInt32(orderReader.GetOrdinal("TicketID"));


            foundOrder = new Order(tempId, tempTotalPrice, tempPurchaseDate, tempCustomerID, tempTicketID);
            return foundOrder;
        }

        public Order GetOrderById(int findId)
        {
            Order foundOrder;
            //
            string queryString = "SELECT id, totalPrice, purchaseDate, customerID, ticketid FROM orders WHERE id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", findId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
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
    }
}

