namespace P01._Define_a_Class_Person
{
    public  class Person
    {

        public Person()
        {
            this.Age = 1;
        }

        public Person(int age)
        {
            this.Age+= age;
            this.Name = "No Name";
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

    }
}
