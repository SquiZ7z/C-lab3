using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість співробітників: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некоректне введення кількості співробітників.");
            return;
        }

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            Employee employee = new Employee();

            Console.WriteLine($"Введіть інформацію про співробітника #{i + 1}:");

            Console.Write("Ім'я: ");
            employee.Name = Console.ReadLine();

            Console.Write("Зарплата: ");
            if (!decimal.TryParse(Console.ReadLine(), out employee.Salary) || employee.Salary < 0)
            {
                Console.WriteLine("Некоректне введення зарплати.");
                return;
            }

            Console.Write("Посада: ");
            employee.Position = Console.ReadLine();

            Console.Write("Відділ: ");
            employee.Department = Console.ReadLine();

            Console.Write("Електронна адреса (натисніть Enter, якщо немає): ");
            employee.Email = Console.ReadLine();

            Console.Write("Вік (-1, якщо немає): ");
            if (!int.TryParse(Console.ReadLine(), out employee.Age) || employee.Age < -1)
            {
                Console.WriteLine("Некоректне введення віку.");
                return;
            }

            employees.Add(employee);
        }

        var departmentWithHighestAverageSalary = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(g => g.Average(e => e.Salary))
            .FirstOrDefault();

        if (departmentWithHighestAverageSalary != null)
        {
            Console.WriteLine($"Відділ з найвищою середньою зарплатою: {departmentWithHighestAverageSalary.Key}");

            var employeesInDepartment = departmentWithHighestAverageSalary
                .OrderByDescending(e => e.Salary);

            foreach (var employee in employeesInDepartment)
            {
                Console.WriteLine($"{employee.Name}, {employee.Salary:F2}, {employee.Email ?? "н/д"}, {employee.Age}");
            }
        }
        else
        {
            Console.WriteLine("Немає даних про співробітників.");
        }
    }
}
