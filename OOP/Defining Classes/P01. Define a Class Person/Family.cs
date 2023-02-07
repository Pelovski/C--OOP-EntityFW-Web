namespace P01._Define_a_Class_Person
{
    public  class Family
    {
        public Family()
        {
            this.Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public void AddMember(Person person)
        {
            this.Persons.Add(person);
        }

        public void GetOldestMember()
        {
            int maxAge = this.Persons.Max(x => x.Age);

            Person person = this.Persons.First(x => x.Age == maxAge);

            Console.WriteLine($"{person.Name} {person.Age}"); 
 
        }
    }
}
