internal class Program
{
    private static void Main(string[] args)
    {
        var data = new Dictionary<string, int>();

        while (true)
        {
            string resource = Console.ReadLine();

            if (resource == "stop")
            {
                break;
            }

            int quantity = int.Parse(Console.ReadLine());

            if (!data.ContainsKey(resource))
            {
                data.Add(resource, 0);
            }

            data[resource] += quantity;

        }

        foreach (var resource in data)
        {
            Console.WriteLine($"{resource.Key} -> {resource.Value}");
        }
    }
}