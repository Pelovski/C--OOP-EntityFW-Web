internal class Program
{
    private static void Main(string[] args)
    {
        var companies = new Dictionary<string, List<string>>();

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "End")
            {
                break;
            }

            string companyName = input[0];
            string employeeId = input[1];

            if (!companies.ContainsKey(companyName))
            {
                companies.Add(companyName, new List<string>());
                companies[companyName].Add(employeeId);
            }
            else
            {
                var currentCompany = companies[companyName];
                if (!currentCompany.Any(x => x == employeeId))
                {
                    currentCompany.Add(employeeId);               
                }
            }
        }

        foreach (var item in companies.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{item.Key}");

            foreach (var employee in companies[item.Key])
            {
                Console.WriteLine($"-- {employee}");
            }
        }
    }
}