using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03._Telephony
{
    public  class Smartphone: ISmartphone
    {

        public void PhoneNumber(string phoneNumber)
        {
            string type = "Calling";
            Console.WriteLine(Validator.PhoneNumberIsIncorrect(phoneNumber, type));

        }
        public void Browsing(string website)
        {
            Console.WriteLine(Validator.WebsiteIsIncorrect(website));
        }
    }
}
