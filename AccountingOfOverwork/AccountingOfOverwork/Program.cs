using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManagement.employes.Add(new Employee(1, "Ivan", new Position(1, "Programmer", 200.0), "first",
                "Moscow st., 237-24", "2000 123456"));
            DataManagement.employes.Add(new Employee(2, "Petr", new Position(2, "Junior Programmer", 120.0), "first",
                "Moscow st., 136-18", "2000 654321"));
            DataManagement.projects.Add(new Project(1, "Project X", "Win", new DateTime(2015, 1, 10)));
            DataManagement.overworks.Add(new Overwork(1, DataManagement.employes[0], DataManagement.projects[0],
                new DateTime(2015, 1, 14), 4.0, new CompensatoryRule(1, "first", 2.0, 1.0)));
            DataManagement.overworks.Add(new Overwork(2, DataManagement.employes[0], DataManagement.projects[0],
                new DateTime(2015, 1, 18), 3.0, new CompensatoryRule(2, "second", 2.2, 1.0)));
            DataManagement.payments.Add(new Payment(1, DataManagement.employes[0], new DateTime(2015, 1, 24), 2500.0));
            DataManagement.compensatoryHolidays.Add(new CompensatoryHoliday(1, DataManagement.employes[0], new DateTime(2015, 1, 22), 4.0));

            while (true)
            {
                Console.Write("Enter number of employee you want to calculate bonuses: ");
                int number = Int16.Parse(Console.ReadLine());
                Console.WriteLine("To pay:  {0}", DataManagement.employes[number].GetPayment());
                Console.WriteLine("Compensatory holidays:  {0}", DataManagement.employes[number].GetCompensatoryHolidays());
            }
        }
    }
}
