namespace P07._Order_by_Age
{
    public class Person
    {

        public Person(string name, string iD, int age)
        {
            this.Name = name;
            this.ID = iD;
            this.Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }
}
