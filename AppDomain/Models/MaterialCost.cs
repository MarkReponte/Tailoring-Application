using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppDomain.Models
{
    public class MaterialCost : BaseClass
    {

        public string CustomerNameCost { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal MaterialTotal {get; set; }
        public decimal LaborCost { get; set; }
        public double Quantity { get; set; }
        public decimal TotalLabor { get; set; } 
        public decimal GrandTotalCost { get; set; }

        public virtual ICollection<MaterialItem> Items { get; set; } = new List<MaterialItem>();
    }
}
