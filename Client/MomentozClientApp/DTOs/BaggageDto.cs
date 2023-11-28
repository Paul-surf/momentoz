using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.DTOs
{
    public class BaggageDto
    {

        public BaggageDto() { }

        public BaggageDto(double inTotalWeight, double inPrice)
        {

            TotalWeight = inTotalWeight;
            Price = inPrice;
            //    HandBaggageId = inHandBaggageID;
            //  CheckedBaggageId = inCheckedBaggageId;
        }
        public int Id { get; set; }
        public double TotalWeight { get; set; }
        public double Price { get; set; }

        //    public int HandBaggageId { get; set; }
        //  public int CheckedBaggageId { get; set; }
    }
}
