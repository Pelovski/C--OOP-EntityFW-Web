using P07._Order_by_Age;

internal class Program
{
    private static void Main(string[] args)
    {
        var persons = new List<Person>();
        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "End")
            {
                break;
            }

            string name = input[0];
            string id = input[1];
            int age = int.Parse(input[2]);

            var person = new Person(name, id, age);

            persons.Add(person);
        }

        foreach (var person in persons.OrderBy(x => x.Age))
        {
            Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
        }
    }
}