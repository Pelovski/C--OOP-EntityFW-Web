using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());

        var students =  new Dictionary<string, List<double>>();
        var finalGrades = new Dictionary<string, double>();

        for (int i = 0; i < rows; i++)
        {
            string studentName = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            if (!students.ContainsKey(studentName))
            {
                students.Add(studentName, new List<double>());
                students[studentName].Add(grade);

            }
            else
            {
                students[studentName].Add(grade);
            }
            
        }


        foreach (var item in students.OrderByDescending(x => x.Value.Average()))
        {
           var average =  item.Value.Average();

            if (average >= 4.50)
            {
                Console.WriteLine($"{item.Key} -> {average:f2}");
            }
            
        }
    }
}