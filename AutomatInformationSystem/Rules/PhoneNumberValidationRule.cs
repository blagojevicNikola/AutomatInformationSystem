using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutomatInformationSystem
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        private readonly Regex r = new Regex(@"(^$)|(^[0-9]{3}\/[0-9]{3}-[0-9]{3}$)");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if(!r.IsMatch(input))
            {
                return new ValidationResult(false, "Format broja telefona je nevalidan!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
