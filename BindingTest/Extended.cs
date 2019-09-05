using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;

namespace BindingTest
{
    public partial class Extended
    {
        public static string Extra = "Onboard";
        public class SUBs
        {
            public string Klasse
            {
                get
                {
                    return "Ja";
                }
            }
        }
    }
    
    public class InputValidations: ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string person = value as string;
            if (CheckForNumbers(person))
            {
                return new ValidationResult(isValid: true, errorContent: null);
            }
            else
            {
                return new ValidationResult(isValid: false, errorContent: null);
            }
        }
        public static bool CheckForNumbers(string text)
        {
            return text.All(x => x <= '9') && text.All(x => x >= '0');
        }
    }
}
