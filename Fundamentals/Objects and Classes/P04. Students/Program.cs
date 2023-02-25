using P04._Students;

internal class Program
{
    private static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        var students = new List<Student>();

        for (int i = 0; i < studentsCount; i++)
        {
            string[] inputStudents = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = inputStudents[0];
            string lastName = inputStudents[1];
            double grade = double.Parse(inputStudents[2]);

            var student = new Student(firstName, lastName, grade);

            students.Add(student);
        }

        foreach (var student in students.OrderByDescending(x => x.Grade))
        {
            Console.WriteLine(student.ToString());
        }
    }
}