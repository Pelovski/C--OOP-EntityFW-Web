internal class Program
{
    private static void Main(string[] args)
    {
       int n  = int.Parse(Console.ReadLine());
        Math.Pow(2, n);

        string bestKeg = "";
        double bigestKeg = 0;
        

        for (int i = 0; i < n; i++)
        {
            string model = Console.ReadLine();
            double radius = double.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double currentKeg = Math.PI * Math.Pow(2, radius) * height;

            if (currentKeg > bigestKeg)
            {
                bestKeg = model;
                bigestKeg = currentKeg;
            }
           
        }

        Console.WriteLine(bestKeg);
    }
}