using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P03._Shopping_Spree.Common
{
    public static class GlobalConstants
    {
        public static decimal COST_MIN_VALUE = 0;
        public static decimal MONEY_MIN_VALUE = 0;

        public static string InvalidNameExceptionMessage = "Name cannot be empty";
        public static string NegativeNumberExceptionMessage = "Cost cannot be a negative number";
        public static string InsufficientMoneyExceptionMessage = "{0} can't afford {1}";
    
    }
}
