using System.Globalization;
using System.Windows.Controls;

namespace PresentationUI.Validation
{
    public class SurnameRule : ValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, $"Please enter your surname.");
            }

            return ValidationResult.ValidResult;
        }
    }
}