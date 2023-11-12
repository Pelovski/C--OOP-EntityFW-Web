using Microsoft.EntityFrameworkCore;
using P01._Import_the_SoftUni_Database.Data;
using P01._Import_the_SoftUni_Database.Data.Models;
using System.Text;

internal class StartUp
{
    private static void Main(string[] args)
    {
        var context = new SoftUniContext();

        string result = AddNewAddressToEmployee(context);


        Console.WriteLine(result);

    }

    // 3.	Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(x => string.IsNullOrEmpty(x.MiddleName))
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

    // 4.	Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)


    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.Salary >= 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ToList();    

        foreach( var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // 5.	Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development ")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();


        foreach ( var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
        }


        return sb.ToString().TrimEnd();
    }

    //6.	Adding a New Address and Updating Employee

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var person = context.Employees.First(x => x.LastName == "Abbas");

        var adress = new Addresse()
        {
            AddressId = 4,
            AddressText = "Vitoshka 15"
        };


        person.Address = adress;

        context.Update(person);
        context.SaveChanges();

        var employees = context
            .Employees
            .Select(e => new
            {
                e.Address.AddressId,
                e.Address.AddressText
            })
            .OrderByDescending(e => e.AddressId)
            .ToList();


        foreach ( var employee in employees)
        {
            sb.AppendLine($"{employee.AddressText}");
        }


        return sb.ToString().TrimEnd();
    }
}