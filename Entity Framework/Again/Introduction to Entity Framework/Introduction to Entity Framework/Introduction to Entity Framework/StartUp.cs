using P01._Import_the_SoftUni_Database.Data;
using System.Text;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var context = new SoftUniContext();

        string result = GetEmployeesFullInformation(context);


        Console.WriteLine(result);

    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(x => string.IsNullOrEmpty(x.MiddleName) )
            .Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.MiddleName,
                e.LastName,
                e.JobTitle,
                e.Salary

            }).ToList();

        foreach (var employee in employees) 
        {
            sb.AppendLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName}" +
                              $" - Job Titile: {employee.JobTitle} - Salary: {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }
}