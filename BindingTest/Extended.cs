using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingTest
{
    public class Extended
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
}
