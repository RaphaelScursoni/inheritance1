using Polimorf.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Polimorf
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.WriteLine("Enter the number of employees: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data:");
                Console.WriteLine("Outsourced (y/n)? ");
                string outsourced = Console.ReadLine();
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (outsourced == "n")
                {
                    list.Add(new Employee(name, hours, valuePerHour));
                }
                else
                {
                    Console.WriteLine("Additional Charge: ");
                    double ac = double.Parse(Console.ReadLine());
                    list.Add(new OutsourcedEmployee(name, hours, valuePerHour, ac));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");
            foreach (Employee employee in list)
            {
                Console.WriteLine(employee.Name + " - $ " + employee.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
