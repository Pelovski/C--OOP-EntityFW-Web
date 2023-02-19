using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        double cpuPrice = double.Parse(Console.ReadLine());
        double videoCardPrice = double.Parse(Console.ReadLine());
        double ramPrice = double.Parse(Console.ReadLine());
        double ramsCount = double.Parse(Console.ReadLine());
        double discount  = double.Parse(Console.ReadLine());

        double ramFinalPrice = ramPrice * ramsCount;

        double videoAndCpuPrices = cpuPrice + videoCardPrice;
        double finalDiscount = videoAndCpuPrices * discount;
        double dolarValue = 1.57;

        double finalPrice = ((videoAndCpuPrices - finalDiscount) + ramFinalPrice) * dolarValue;

        Console.WriteLine($"Money needed - {finalPrice:f2} leva.");

      
    }
}