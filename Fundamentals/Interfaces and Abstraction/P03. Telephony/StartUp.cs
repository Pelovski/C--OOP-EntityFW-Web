using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using P03._Telephony;

internal class StartUp
{
    private static void Main(string[] args)
    {
       string[] phoneNumbers = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries);

        string[] websites = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        ISmartphone smartPhone = new Smartphone();
        IStationaryPhone stationaryphone = new StationaryPhone();

        for (int i = 0; i < phoneNumbers.Length; i++)
        {
            string context = phoneNumbers[i];

            if (context.Length == 10)
            {

                smartPhone.PhoneNumber(context);
                continue;

            }

                stationaryphone.PhoneNumber(context);

        }

        foreach (var website in websites)
        {
            smartPhone.Browsing(website);
        }
    }
}