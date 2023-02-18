using System;
using System.Linq.Expressions;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int wantedProfit = int.Parse(Console.ReadLine());
        double currentProfit = 0;

        while (true)
        {
            string coctail = Console.ReadLine();

            if (coctail == "Party!")
            {
                double neededIncome = wantedProfit - currentProfit;

                Console.WriteLine($"We need {neededIncome:f2} leva more.");
                Console.WriteLine($"Club income - {currentProfit:f2} leva.");

                break;
            }

            int coctailCount = int.Parse(Console.ReadLine());

            

            double coctailPrice = coctail.Length * coctailCount;

            if (coctailPrice % 2 != 0)
            {
                coctailPrice -= coctailPrice * 0.25;

                currentProfit += coctailPrice;
            }
            else
            {
                currentProfit += coctailPrice;
            }


            if (currentProfit >= wantedProfit)
            {
                Console.WriteLine("Target acquired.");
                Console.WriteLine($"Club income - {currentProfit:f2} leva");
                break;
            }
        }

    }
}