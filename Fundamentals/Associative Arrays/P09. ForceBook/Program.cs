internal class Program
{
    private static void Main(string[] args)
    {
        var listOfData = new Dictionary<string, List<string>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Lumpawaroo")
            {
                break;
            }

            if (input.Contains(" | "))
            {
                string[] data = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                string forceSide = data[0];
                string foreUser = data[1];
    

                if (!listOfData.ContainsKey(forceSide))
                {
                    listOfData.Add(forceSide, new List<string>());
                    listOfData[forceSide].Add(foreUser);
                }

                else 
                {
                    if (!listOfData[forceSide].Contains(foreUser))
                    {
                        listOfData[forceSide].Add(foreUser);
                    }
                }
            }

            if (input.Contains(" -> "))
            {
                string[] data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string forceUser = data[0];
                string forceSide = data[1];
                bool isUserExist = false;
                string currentSide = "";

                foreach (var item in listOfData)
                {
                    foreach (var user in listOfData[item.Key])
                    {
                        if (user == forceUser)
                        {
                            isUserExist = true;
                            currentSide = item.Key;
                            break;
                        }
                    }
                }

                if (!isUserExist)
                {
                    listOfData[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }
                else
                {
                    listOfData[currentSide].Remove(forceUser);
                    listOfData[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }
        }

        foreach (var item in listOfData
            .OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
        {
            var usersCount = item.Value.Count();

            listOfData[item.Key].Sort();

            if (usersCount != 0)
            {
                Console.WriteLine($"Side: {item.Key}, Members: {usersCount}");

                foreach (var user in listOfData[item.Key])
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}