internal class Program
{
    private static void Main(string[] args)
    {
        var data = new Dictionary<string, List<string>>();

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "end")
            {
                break;
            }

            string courceName = input[0];
            string studentName = input[1];

            if (!data.ContainsKey(courceName))
            {
                data.Add(courceName, new List<string>());
            }

                data[courceName].Add(studentName);
        }

        foreach (var item in data.OrderByDescending(x => x.Value.Count))
        {
            Console.WriteLine($"{item.Key}: {item.Value.Count}");

            data[item.Key].Sort();

            foreach (var studentName in data[item.Key])
            {
                Console.WriteLine($"-- {studentName}");
            }
        }
    }
}