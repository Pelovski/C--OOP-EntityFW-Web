using System;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        double avarageGrade = 0;
        double topStudents = 0;
        double avarageStudents = 0;
        double weaktudents = 0;
        double failedStudents = 0;


        for (int i = 0; i < studentsCount; i++)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5)
            {
                topStudents++;
            }
            else if (grade >= 4 && grade <= 4.99)
            {
                avarageStudents++;
            }

            else if (grade >= 3 && grade <= 3.99)
            {
                weaktudents++;
            }
            else
            {
                failedStudents++;
            }

            avarageGrade += grade;
        }

        Console.WriteLine($"Top students: {(topStudents / studentsCount) * 100:f2}%");
        Console.WriteLine($"Between 4.00 and 4.99: {(avarageStudents / studentsCount) * 100:f2}%");
        Console.WriteLine($"Between 3.00 and 3.99: {(weaktudents / studentsCount) * 100:f2}%");
        Console.WriteLine($"Fail: {(failedStudents / studentsCount) * 100:f2}%");
        Console.WriteLine($"Average: {avarageGrade / studentsCount:f2}");

    }
}
