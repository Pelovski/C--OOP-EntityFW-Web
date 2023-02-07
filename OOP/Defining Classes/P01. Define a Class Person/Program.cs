using P01._Define_a_Class_Person;

internal class Program
{
    private static void Main(string[] args)
    {
        Family family = new Family();
        Person person = new Person("Pesho", 3);
        Person secondPerson = new Person("Pavel", 29);

        family.AddMember(person);
        family.AddMember(secondPerson);

        family.GetOldestMember();
    }
}