using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenAILib.Dto.Employees;

namespace OpenAILib.Dto
{
    public class Employees
    {
        public class Employee
        {
            public string EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Nationality { get; set; }
            public string Position { get; set; }
            public string Department { get; set; }
            public string Manager { get; set; } 
        }

    }
    public class EmployeeList
    {
        public List<Employee> Employees { get; set; }
    }

    public class EmployeeResult
    {
        public static string GetEmployeeTemplateString()
        {
            string employeeTemplate = @"
    {Employees:[{
        ""EmployeeId"": ""STRING"", // Unique identifier for the employee
        ""EmployeeName"": ""STRING"", // Full name of the employee
        ""DateOfBirth"": ""YYYY-MM-DD"", // Date of birth in ISO format
        ""Nationality"": ""STRING"", // Nationality of the employee
        ""Position"": ""STRING"", // Job title of the employee
        ""Department"": ""STRING"", // Department where the employee works
        ""Manager"": ""STRING"" OR NULL, // Name of the manager or null if none
       
    }]}";

            return employeeTemplate;
        }

    }

}
