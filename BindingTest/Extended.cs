using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }
    }
}
