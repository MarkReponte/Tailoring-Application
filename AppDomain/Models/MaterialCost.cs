using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppDomain.Models
{
    public class MaterialCost : BaseClass
    {
        
        public string Item { get; set; }
        public double Meters { get; set; }
        public double CostPerMeter { get; set; }


    }
}
