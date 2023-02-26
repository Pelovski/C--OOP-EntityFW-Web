internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var parkingDictionary = new Dictionary<string, string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = input[0];
            string username = input[1];

            bool isContainKey = parkingDictionary.ContainsKey(username);

            if (isContainKey && action == "register")
            {
                Console.WriteLine($"ERROR: already registered with plate number {parkingDictionary[username]}");
            }

            else if (!isContainKey && action == "register")
            {
                string plateNumber = input[2];
                parkingDictionary.Add(username, plateNumber);

                Console.WriteLine($"{username} registered {plateNumber} successfully");
            }

            else if (!isContainKey && action == "unregister")
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }

            else if (isContainKey && action == "unregister")
            {
                parkingDictionary.Remove(username);

                Console.WriteLine($"{username} unregistered successfully");
            }

        }

        foreach (var item in parkingDictionary)
        {
            Console.WriteLine($"{item.Key} => {item.Value}");
        }
    }
}