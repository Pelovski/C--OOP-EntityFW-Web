internal class Program
{
    private static void Main(string[] args)
    {
        int wagonNumber = int.Parse(Console.ReadLine());
        int[] people =  new int[wagonNumber];

        for (int i = 0; i < wagonNumber; i++)
        {
            int peopleNum = int.Parse(Console.ReadLine());
            people[i] = peopleNum;
        }

        Console.WriteLine(string.Join(" ", people));
        Console.WriteLine(people.Sum());
    }
}