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
            DataManagement.employes.Add(new Employee("Ivan", new Position("Programmer", 200.0), "first",
                "Moscow st., 237-24", "2000 123456"));
            DataManagement.employes.Add(new Employee("Petr", new Position("Junior Programmer", 120.0), "first",
                "Moscow st., 136-18", "2000 654321"));
            DataManagement.projects.Add(new Project("Project X", "Win", new DateTime(2015, 1, 10)));
            DataManagement.overworks.Add(new Overwork(DataManagement.employes[0], DataManagement.projects[0],
                new DateTime(2015, 1, 14), 4.0, new CompensatoryRule("first", 2.0, 1.0)));
            DataManagement.overworks.Add(new Overwork(DataManagement.employes[0], DataManagement.projects[0],
                new DateTime(2015, 1, 18), 3.0, new CompensatoryRule("second", 2.2, 1.0)));
            DataManagement.payments.Add(new Payment(DataManagement.employes[0], new DateTime(2015, 1, 24), 2500.0));
            DataManagement.compensatoryHolidays.Add(new CompensatoryHoliday(DataManagement.employes[0], new DateTime(2015, 1, 22), 4.0));

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
