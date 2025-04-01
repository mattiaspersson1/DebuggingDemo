using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Class representing an employee
class Employee
{
    public string FirstName { get; }
    public string LastName { get; }
    public decimal Salary { get; }

    public Employee(string firstName, string lastName, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Salary: {Salary}";
    }
}

// Class managing the employee register
class EmployeeRegister
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(string firstName, string lastName, decimal salary)
    {
        employees.Add(new Employee(firstName, lastName, salary));
    }

    public void PrintEmployees()
    {
        Console.WriteLine("\nEmployee Register:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}

// Main program
class Program
{
    static void Main()
    {
        EmployeeRegister register = new EmployeeRegister();
        
        while (true)
        {
            Console.Write("Enter employee first name (or type 'print register' to print the employee register): ");
            string firstName = Console.ReadLine()?.Trim();
            if (firstName?.ToLower() == "print register")
                break;

            if (!IsValidName(firstName))
            {
                Console.WriteLine("Invalid first name. First name must be 2-50 alphabetic characters.");
                continue;
            }

            Console.Write("Enter employee last name: ");
            string lastName = Console.ReadLine()?.Trim();

            if (!IsValidName(lastName))
            {
                Console.WriteLine("Invalid last name. Last name must be 2-50 alphabetic characters.");
                continue;
            }

            decimal salary;
            while (true)
            {
                Console.Write("Enter salary: ");
                if (decimal.TryParse(Console.ReadLine(), out salary) && salary >= 0)
                    break;

                Console.WriteLine("Invalid salary! Please enter a valid positive number.");
            }

            register.AddEmployee(firstName, lastName, salary);
            Console.WriteLine("Employee added successfully.\n");
        }

        register.PrintEmployees();
    }

    // Validate that the name is alphabetic and within 2-50 characters
    static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) &&
               Regex.IsMatch(name, @"^[a-zA-Z]{2,50}$");
    }
}