using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var items = new Dictionary<string, int>();
        var junk = new Dictionary<string, int>();

        string[] input = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length; i+=2)
        {
            int quantity = int.Parse(input[i]);
            string material = input[i+1].ToLower();

            if (material == "motes" || material == "fragments" || material == "shards")
            {
                if (!items.ContainsKey(material))
                {
                    items.Add(material, 0);
                }

                items[material] += quantity;
            }

            else
            {
                if (!junk.ContainsKey(material))
                {
                    junk.Add(material, 0);
                }

                junk[material] += quantity;
            }

            if (items.Any(x => x.Value >= 250))
            {
                var item = items.FirstOrDefault(x => x.Value >= 250);
                string itemKey = item.Key;

                items[itemKey] -= 250;

                Console.WriteLine($"{itemKey} obtained!");
                break;
            }
        }

        foreach (var item in items.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        foreach (var item in junk.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

    }
}