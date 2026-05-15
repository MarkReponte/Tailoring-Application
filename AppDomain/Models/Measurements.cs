using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Models
{
    public class Measurements : BaseClass
    {
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated {  get; set; } = DateTime.Now;
        public DateTime OrderDeadline { get; set; }
        public string Status { get; set; }

        //Torso Measurements
        public double Shoulder { get; set; }
        public double UpperBust { get; set; }
        public double Bust { get; set; }
        public double LowerBust { get; set; }

        public double FrontFigure { get; set; }
        public double BackFigure { get; set; }
        public double FrontChest { get; set; }
        public double BackChest { get; set; }

        public double UpperHips { get; set; }
        public double Waistline { get; set; }
        public double NeckDip { get; set; }
        public double ArmHole { get; set; }
        public double ArmCircumference { get; set; }
        public double SleeveLength { get; set; }

        //Pants Measurements

        public double LowerHips { get; set; }
        public double Crotch { get; set; }
        public double CalfCircumference { get; set; }

        public double Length { get; set; }
        public double Thigh { get; set; }

    }
}
