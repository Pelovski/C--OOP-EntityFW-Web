using System;
public class Program
{
    private static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());
        double entryPrice = double.Parse(Console.ReadLine());
        double loungerPrice = double.Parse(Console.ReadLine());
        double umbrellaPrice = double.Parse(Console.ReadLine());

        double loungerCount = Math.Ceiling(people * 0.75);
        double umbrellaCount = Math.Ceiling(people / 2.0);

        double entryProfit = people * entryPrice;
        double loungerProfit = loungerCount * loungerPrice;
        double umbrellaProfit = umbrellaCount * umbrellaPrice;

        double result = entryProfit + loungerProfit + umbrellaProfit;

        Console.WriteLine($"{result:f2} lv.");
    }
}