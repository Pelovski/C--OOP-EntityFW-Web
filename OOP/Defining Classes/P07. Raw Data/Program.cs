using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        int peakMeters = 8848;
        int currentMeters = 5364;
        int days = 1;

        while (true)
        {
            if (currentMeters >= peakMeters)
            {
                Console.WriteLine($"Goal reached for {days} days!");
                break;
            }

            string pause = Console.ReadLine();

            

            if (pause == "Yes")
            {
                days++;
            }

            if (pause == "END" || days > 5)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(currentMeters);
                break;
            }


            int climbedMeters = int.Parse(Console.ReadLine());

            currentMeters += climbedMeters;
        }

    }
}
