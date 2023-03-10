namespace P02._Multiple_Implementation
{
    internal class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string birthdate, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }

        public string Id { get; set; }
    }
}
