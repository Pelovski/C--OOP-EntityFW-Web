namespace P02._Generic_Box_of_Integer
{
    internal class Box<T>
    {
        public Box(int number)
        {
            this.Number = number;
        }

        public int Number { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().GetGenericArguments()[0]}: {this.Number}";
        }
    }
}
