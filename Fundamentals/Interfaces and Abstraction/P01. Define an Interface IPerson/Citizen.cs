namespace P01._Define_an_Interface_IPerson
{
    internal class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get;  set; }
    }
}
