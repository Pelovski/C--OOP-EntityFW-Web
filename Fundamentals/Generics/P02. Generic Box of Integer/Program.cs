using P02._Generic_Box_of_Integer;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var data = new List<Box<int>>();

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            var box = new Box<int>(input);

            data.Add(box);
        }

        foreach (var item in data)
        {
            Console.WriteLine(item.ToString());
        }
    }
}