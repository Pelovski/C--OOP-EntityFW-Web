using P02._Multiple_Implementation;

internal class StartUp
{
    private static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();

        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);

        Console.WriteLine(identifiable.Id);
        Console.WriteLine(birthable.Birthdate);

    }
}