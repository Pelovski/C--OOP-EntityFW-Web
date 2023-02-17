using System;
public class Program
{
    private static void Main(string[] args)
    {
        double budget = double.Parse(Console.ReadLine());
        int videoCardsCount = int.Parse(Console.ReadLine());
        int processorsCount = int.Parse(Console.ReadLine());
        int ramsCount = int.Parse(Console.ReadLine());

        int videoCardPrice = 250 * videoCardsCount;
        double processorPrice = (videoCardPrice * 0.35) * processorsCount;
        double ramPrice = (videoCardPrice * 0.10) * ramsCount;

        double finalPrice = videoCardPrice + processorPrice + ramPrice;

        if (videoCardsCount > processorsCount)
        {
            finalPrice -= finalPrice * 0.15;
        }

        double finalBudget = Math.Abs(budget - finalPrice);

        if (budget >= finalPrice)
        {
            Console.WriteLine($"You have {finalBudget:f2} leva left!"); 
        }

        else
        {
            Console.WriteLine($"Not enough money! You need {finalBudget:f2} leva more!");
        }
    }
}