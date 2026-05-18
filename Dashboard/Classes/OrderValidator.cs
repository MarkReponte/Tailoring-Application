namespace Dashboard.Classes
{
    public class OrderValidator
    {
        private readonly Action<string> _showWarning;
        private readonly Action<string> _showError;

        public OrderValidator(Action<string> showWarning, Action<string> showError)
        {
            _showWarning = showWarning;
            _showError = showError;
        }

        public bool Validate(string customerName, object selectedGender, DateTime deadline)
        {
            if (selectedGender == null)
            {
                _showWarning("Select a Gender before submitting.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(customerName))
            {
                _showWarning("Enter the Customer's Name.");
                return false;
            }

            if (deadline.Date < DateTime.Today)
            {
                _showError("The deadline cannot be a date in the past!");
                return false;
            }

            if (deadline.Date == DateTime.Today)
            {
                var result = MessageBox.Show("The deadline is set to Today. Is this correct?",
                    "Confirm Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return false;
            }

            return true;
        }
    }
}