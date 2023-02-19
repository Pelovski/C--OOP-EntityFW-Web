using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        int daysOfStay = int.Parse(Console.ReadLine());
        string roomType = Console.ReadLine();
        string rate = Console.ReadLine();

        double roomForOnePerson = 18;
        double apartment = 25;
        double presidentApartment = 35;
        double finalPrice = 0;

        if (daysOfStay < 10)
        {
            apartment -= apartment * 0.30;
            presidentApartment -= presidentApartment * 0.10;
        }
        else if (daysOfStay >= 10 && daysOfStay <=15 )
        {
            apartment -= apartment * 0.35;
            presidentApartment -= presidentApartment * 0.15;
        }
        else
        {
            apartment -= apartment * 0.50;
            presidentApartment -= presidentApartment * 0.20;
        }

        if (roomType == "room for one person")
        {
            finalPrice = roomForOnePerson * (daysOfStay - 1);

        }
        else if (roomType == "apartment")
        {
            finalPrice = apartment * (daysOfStay - 1);


        }
        else
        {
            finalPrice = presidentApartment * (daysOfStay - 1);

        }

        if (rate == "positive")
        {
            finalPrice += finalPrice * 0.25;
        }
        else
        {
            finalPrice -= finalPrice * 0.10;
        }

        Console.WriteLine($"{finalPrice:f2}");
    }
}
