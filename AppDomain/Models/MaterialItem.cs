using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Models
{
    public class MaterialItem : BaseClass
    {
        public string ItemName { get; set; }
        public string Meters { get; set; }
        public string Price { get; set; }

       
        public Guid MaterialCostId { get; set; }
    }
}
