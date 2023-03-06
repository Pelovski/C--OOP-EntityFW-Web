
using System.Runtime.CompilerServices;

namespace P01._Generic_Box_of_String
{
    internal class Box<T>
    {
        public Box(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().GetGenericArguments()[0]}: {this.Text}";
        }
    }
}
