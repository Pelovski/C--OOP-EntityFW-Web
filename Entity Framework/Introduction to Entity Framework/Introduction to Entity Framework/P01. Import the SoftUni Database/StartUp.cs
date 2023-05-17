using System.Text;
using P01._Import_the_SoftUni_Database.Data;
using P01._Import_the_SoftUni_Database.Data.Models;

internal class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        string result = GetEmployeesFullInformation(context);

        Console.WriteLine(result);
    }

    // P03.Employees Full Information

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.EmployeeId)
            .ToList();


        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                          $" {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // P04. Employees with Salary Over 50 000

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb =  new StringBuilder();

        var employees = context
            .Employees
            .Where(x => x.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(x => x.FirstName)
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}.");
        }

        return sb.ToString().TrimEnd();
    }
}