using System.Windows.Forms;

namespace Dashboard.Classes
{
    public static class CostCalculator
    {
        public static (decimal materialSum, decimal totalLabor, decimal grandTotal)
            Calculate(DataGridViewRowCollection rows, string laborText, string quantityText)
        {
            decimal materialSum = 0;

            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells[3].Value != null)
                {
                    decimal.TryParse(row.Cells[3].Value.ToString(), out decimal rowVal);
                    materialSum += rowVal;
                }
            }

            decimal.TryParse(laborText, out decimal labor);
            decimal.TryParse(quantityText, out decimal quantity);

            decimal totalLabor = labor * quantity;
            return (materialSum, totalLabor, materialSum + totalLabor);
        }
    }
}