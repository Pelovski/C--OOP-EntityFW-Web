internal class Program
{
    private static void Main(string[] args)
    {
        int startIndex = int.Parse(Console.ReadLine());
        int endIndex = int.Parse(Console.ReadLine());

        string output = "";

        for (int i = startIndex; i <= endIndex; i++)
        {
            char ASCIIsymbol = Convert.ToChar(i);

            output+= ASCIIsymbol + " ";
        }

        Console.WriteLine(output);
    }
}