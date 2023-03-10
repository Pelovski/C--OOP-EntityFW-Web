using System.Text;

namespace P03._Generic_Swap_Method_Strings
{
    internal class Box<T>
    {
        public Box(List<T> data)
        {
            this.Values = data;
        }
        public List<T> Values { get; set; }

        public void Swap(List<T> data, int firstIndex, int secondIntex)
        {
            T templateValue = data[firstIndex];

            data[firstIndex] = data[secondIntex];
            data[secondIntex] = templateValue;

        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach (var item in this.Values)
            {
                stringBuilder.AppendLine($"{item.GetType()}: {item}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
