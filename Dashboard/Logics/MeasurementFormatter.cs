using AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Formatter
{
    public static class MeasurementFormatter
    {
        public static string ToDisplayString(Measurements measurements)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine("Torso Measurements:");
            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine($"Shoulder: {measurements.Shoulder} cm");
            sb.AppendLine($"Upper Bust: {measurements.UpperBust} cm");
            sb.AppendLine($"Bust: {measurements.Bust} cm");
            sb.AppendLine($"Lower Bust: {measurements.LowerBust} cm");
            sb.AppendLine($"Front Figure: {measurements.FrontFigure} cm");
            sb.AppendLine($"Back Figure: {measurements.BackFigure} cm");
            sb.AppendLine($"Front Chest: {measurements.FrontChest} cm");
            sb.AppendLine($"Back Chest: {measurements.BackChest} cm");
            sb.AppendLine($"Upper Hips: {measurements.UpperHips} cm");
            sb.AppendLine($"Waistline: {measurements.Waistline} cm");
            sb.AppendLine($"Neck Dip: {measurements.NeckDip} cm");
            sb.AppendLine($"Arm Hole: {measurements.ArmHole} cm");
            sb.AppendLine($"Arm Circumference: {measurements.ArmCircumference} cm");
            sb.AppendLine($"Sleeve Length: {measurements.SleeveLength} cm");

            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine("Pants Measurements:");
            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine($"Lower Hips: {measurements.LowerHips} cm");
            sb.AppendLine($"Crotch: {measurements.Crotch} cm");
            sb.AppendLine($"Thigh: {measurements.Thigh} cm");
            sb.AppendLine($"Calf Circumference: {measurements.CalfCircumference} cm");
            sb.AppendLine($"Length: {measurements.Length} cm");

            return sb.ToString();
        }
    }
}
