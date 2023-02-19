using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        double pocketMoney = double.Parse(Console.ReadLine());
        double earndMoneyPerDay = double.Parse(Console.ReadLine());
        double costs = double.Parse(Console.ReadLine());
        double presentPrice = double.Parse(Console.ReadLine());

        double savedMoney = ((pocketMoney + earndMoneyPerDay) * 5) - costs;

        if (savedMoney >= presentPrice)
        {
            Console.WriteLine($"Profit: {savedMoney:f2} BGN, the gift has been purchased.");
        }

        else
        {
            double neededAmount = presentPrice - savedMoney;

            Console.WriteLine($"Insufficient money: {neededAmount:f2} BGN.");
        }
    }
}