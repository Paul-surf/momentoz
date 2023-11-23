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
        public int TotalPrice { get; set; }
        public DateTime DateOfBuy { get; set; }

        public Ticket Ticket { get; set; }

        public Order(int totalPrice, DateTime dateOfBuy, Ticket ticket)
        {
            TotalPrice = totalPrice;
            DateOfBuy = dateOfBuy;
            Ticket = ticket;
        }
        public Order(int ID, int totalPrice, DateTime dateOfBuy, Ticket ticket)
        {
            this.ID = ID;
            TotalPrice = totalPrice;
            DateOfBuy = dateOfBuy;
            Ticket = ticket;
        }
    }
}
