using System.Globalization;
using P01._Define_a_Class_Person;

internal class Program
{
    private static void Main(string[] args)
    {
        string firstInput = Console.ReadLine();
        string secondInput = Console.ReadLine();
        DateModifier dateModifier = new DateModifier();

        DateTime firstDate = DateTime.Parse(firstInput, CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.Parse(secondInput, CultureInfo.InvariantCulture);

   

        dateModifier.DifferenceBetweenTwoDates(firstDate, secondDate);


    }
}