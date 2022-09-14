using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutomatInformationSystem
{
    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if(string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Nevalidan format datuma!");
            }
            bool parse = DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            if(!parse)
            {
                return new ValidationResult(false, "Nevalidan format datuma!");
            }

            return ValidationResult.ValidResult;

            
        }
    }
}
