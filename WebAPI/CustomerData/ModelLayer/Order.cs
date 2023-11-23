using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DatabaseData.ModelLayer
{
    public class Order
    {
        public int ID { get; set; }    
        public double TotalPrice { get; set; }
        public DateTime DateForPurchase { get; set; }
        public int? CustomerID { get; set; }
        public int? TicketID { get; set; }

        public Order(double totalPrice, DateTime dateOfBuy, int? TicketID, int? CustomerID)
        {
            TotalPrice = totalPrice;
            DateForPurchase = dateOfBuy;
            this.TicketID = TicketID;
            this.CustomerID = CustomerID;

        }
        public Order(int ID, double TotalPrice, DateTime dateOfBuy, int? CustomerID, int? TicketID)
        {
            this.ID =ID;
            this.TotalPrice = TotalPrice;
            this.DateForPurchase = dateOfBuy;
            this.CustomerID = CustomerID;
            this.TicketID=TicketID;
        }
    }
}
