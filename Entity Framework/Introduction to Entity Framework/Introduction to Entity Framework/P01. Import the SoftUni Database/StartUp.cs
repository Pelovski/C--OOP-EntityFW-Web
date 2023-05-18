using System.Globalization;
using System.Text;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using P01._Import_the_SoftUni_Database.Data;
using P01._Import_the_SoftUni_Database.Data.Models;

internal class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();

        string result = GetAddressesByTown(context);

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
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.EmployeeId)
            .ToList();


        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName}" +
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

    // P05.	Employees from Research and Development

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(x => x.Salary)
            .ThenByDescending(x => x.FirstName)
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.DepartmentName} - ${employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //6.	Adding a New Address and Updating Employee

     public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        var sb =  new StringBuilder();


        var adress = new Addresse()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
     

        var nakov = context.Employees.First(x => x.LastName == "Nakov");

        nakov.Address = adress;

        context.Update(nakov);
        context.SaveChanges();

        var employees = context
            .Employees
            .Select(e => new { 

                e.AddressId,
                AdressText = e.Address.AddressText            
            })
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.AdressText}");
        }

        return sb.ToString().TrimEnd();
    }

    // 7.	Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
          var sb = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                      ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new {

                e.FirstName,
                e.LastName,
                ManagerFirtName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects.Select(ep => new
                {
                    ProjectName = ep.Project.Name,
                    StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = ep.Project.EndDate.HasValue ? ep.Project
                    .EndDate
                    .Value
                    .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                })
            }).ToList();

        foreach ( var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager:" +
                          $"{employee.ManagerFirtName} {employee.ManagerLastName}");

            foreach (var ep in employee.Projects)
            {

                sb.AppendLine($"--{ep.ProjectName} - {ep.StartDate} - {ep.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // 8.	Addresses by Town

    public static string GetAddressesByTown(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var adresses = context
            .Addresses
            .Select(a => new
            {

                a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count

            })
            .OrderByDescending(a => a.EmployeeCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToList();

        foreach (var adresse in adresses)
        {
            sb.AppendLine($"{adresse.AddressText}, {adresse.TownName} - {adresse.EmployeeCount} employees");
        }

        return sb.ToString().TrimEnd();
    }
}