using System;
using System.Linq.Expressions;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string cityName = Console.ReadLine();
        string package = Console.ReadLine();
        string vipDiscount = Console.ReadLine();
        int stayDays = int.Parse(Console.ReadLine());

        double pricePerNight = 0;
        double finalDiscount = 0;

        if (stayDays < 1)
        {
            Console.WriteLine("Days must be positive number!");
            return;
        }

        if (cityName == "Bansko" || cityName == "Borovets")
        {
            if (package == "noEquipment")
            {
                if (vipDiscount == "yes")
                {
                    finalDiscount = 0.05;
                }

                pricePerNight = 80;
            }

            else if (package == "withEquipment")
            {
                if (vipDiscount == "yes")
                {
                    finalDiscount = 0.10;
                }

                pricePerNight = 100;
            }

            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
        }

        else if (cityName == "Varna" || cityName == "Burgas")
        {

            if (package == "withBreakfast")
            {
                if (vipDiscount == "yes")
                {
                    finalDiscount = 0.12;
                }
                pricePerNight = 130;
            }
            else if (package == "noBreakfast")
            {
                if (vipDiscount == "yes")
                {
                    finalDiscount = 0.07;
                }
                pricePerNight = 100;
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
        }

        else
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        double allNightsPrice = stayDays * pricePerNight;

        if (finalDiscount !=0)
        {
            pricePerNight -= pricePerNight * finalDiscount;
            allNightsPrice = pricePerNight  * stayDays;
        }

        if (stayDays > 7)
        {
            allNightsPrice -= pricePerNight;
        }

        Console.WriteLine($"The price is {allNightsPrice:f2}lv! Have a nice time!");
    }
}