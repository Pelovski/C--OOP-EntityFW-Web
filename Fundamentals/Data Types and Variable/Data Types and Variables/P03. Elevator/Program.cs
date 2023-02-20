internal class Program
{
    private static void Main(string[] args)
    {
        double numbersOfPeople = int.Parse(Console.ReadLine());
        double capacity = int.Parse(Console.ReadLine());

        double result = Math.Ceiling(numbersOfPeople / capacity);

        Console.WriteLine(result);
    }
}