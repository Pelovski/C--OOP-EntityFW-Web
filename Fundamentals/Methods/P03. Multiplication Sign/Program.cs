internal class Program
{
    private static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        Sign(firstNumber,secondNumber,thirdNumber);

    }

    public static void Sign (int firstNumber, int secondNumber, int thirdNumber)
    {
        string isNegative = firstNumber < 0 || secondNumber < 0 || thirdNumber < 0 ? "negative" : "positive";

        Console.WriteLine(isNegative);
    }
}