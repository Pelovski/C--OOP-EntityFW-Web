using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string chefName = "";
        int chefRate = 0;

        string currentChefName = "";
        int currentChefRate = 0;

        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine();

            currentChefName = name;
            currentChefRate = 0;

            while (true)
            {
                string rate = Console.ReadLine();

                if (rate == "Stop")
                {
                    Console.WriteLine($"{currentChefName} has {currentChefRate} points.");
                    break;
                }

                currentChefRate += int.Parse(rate);
            }

            if (i == 0 || currentChefRate > chefRate)
            {
                chefName = currentChefName;
                chefRate = currentChefRate;

                Console.WriteLine($"{chefName} is the new number 1!");
            }
        }

        Console.WriteLine($"{chefName} won competition with {chefRate} points!");
    }
}