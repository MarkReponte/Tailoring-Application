using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Models
{
    public class OrderSummary : BaseClass
    {
        public double MaterialTotal { get; set; }
        public double LaborCost { get; set; }
        public int Quantity { get; set; }
        public double TotalLaborCost { get; set; }
        public double GrandToaCost { get; set; }
    }
}
