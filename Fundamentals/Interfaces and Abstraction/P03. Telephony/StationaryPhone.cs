using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03._Telephony
{
    internal class StationaryPhone : IStationaryPhone
    {
        public void PhoneNumber(string phoneNumber)
        {
            string type = "Dialing";
            Console.WriteLine(Validator.PhoneNumberIsIncorrect(phoneNumber, type));

        }
    }
}
