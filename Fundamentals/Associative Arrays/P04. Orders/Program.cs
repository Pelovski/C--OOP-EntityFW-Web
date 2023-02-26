internal class Program
{
    private static void Main(string[] args)
    {
        var data = new Dictionary<string, Dictionary<double, int>>();

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "buy")
            {
                break;
            }

            string product = input[0];
            double price = double.Parse(input[1]);
            int quantity = int.Parse(input[2]);

            if (!data.ContainsKey(product))
            {
                var currentPriceAndQuantity = new Dictionary<double, int>();

                currentPriceAndQuantity.Add(price, quantity);

                data.Add(product, currentPriceAndQuantity);
            }

            else
            {
                double currentPrice = data[product].Keys.First();
                int value = data[product][currentPrice];

                data[product].Add(price, value);
                data[product].Remove(currentPrice);
                data[product][price] += quantity;
            }
        }

        foreach (var item in data)
        {
            foreach (var ex in data[item.Key])
            {
                Console.WriteLine($"{item.Key} -> {ex.Key * ex.Value:f2}");
            }
        }
    }
}