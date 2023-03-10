using P01._Define_an_Interface_IPerson;

internal class StartUp
{
    private static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        IPerson person = new Citizen(name, age);

        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);

    }
}