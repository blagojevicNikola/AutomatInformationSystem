using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutomatInformationSystem
{
    public class SeriesNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if(string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Serijski broj nije validan!");
            }
            if (input.Any(x => char.IsLetter(x)))
            {
                return new ValidationResult(false, "Serijski broj nije validan!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
