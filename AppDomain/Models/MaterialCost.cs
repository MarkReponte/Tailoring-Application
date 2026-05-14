using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppDomain.Models
{
    public class MaterialCost : BaseClass
    {
        
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public double Meters { get; set; }
        public decimal Price { get; set; }
        public decimal MaterialTotal {get; set; }
        public decimal LaborCost { get; set; }
        public double Quantity { get; set; }
        public decimal TotalLabor { get; set; } 
        public decimal GrandTotalCost { get; set; }
    }
}
