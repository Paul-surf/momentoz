using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.ModelLayer
{
    public class Baggage
    {

        public Baggage() { }

        public Baggage(double totalWeight, double price)
        {

            this.TotalWeight = totalWeight;
            this.Price = price;
            //     this.baggageID = baggageID;
            //   this.baggageId = baggageId;
        }
        public Baggage(int id, double totalWeight, double price) : this(totalWeight, price)
        {
            Id = id;


        }

        //   private int baggageID;
        // private int baggageId;




        //  public int BaggageId { get; set; }

        //public int BaggageId { get; set; }
        public int Id { get; set; }

        public double TotalWeight { get; set; }

        public double Price { get; set; }


    }
}
