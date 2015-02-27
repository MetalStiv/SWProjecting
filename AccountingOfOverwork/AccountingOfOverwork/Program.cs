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
            DataLists TestData = new DataLists();
            TestData.AddEmployee(new Employee(1, "Ivan", new Position(1, "Programmer", 200.0), "first",
                "Moscow st., 237-24", "2000 123456"));
            TestData.AddEmployee(new Employee(2, "Petr", new Position(2, "Junior Programmer", 120.0), "first",
                "Moscow st., 136-18", "2000 654321"));
            TestData.AddProject(new Project(1, "Project X", "Win", new DateTime(2015, 1, 10)));
            TestData.AddOverwork(new Overwork(1, TestData.GetEmployee(1), TestData.GetProject(1),
                new DateTime(2015, 1, 14), 4.0, new CompensatoryRule(1, "first", 2.0, 1.0)));
            TestData.AddOverwork(new Overwork(2, TestData.GetEmployee(1), TestData.GetProject(1),
                new DateTime(2015, 1, 18), 3.0, new CompensatoryRule(2, "second", 2.2, 1.0)));
            TestData.AddPayment(new Payment(1, TestData.GetEmployee(1), new DateTime(2015, 1, 24), 2500.0));
            TestData.AddCompensatoryHoliday(new CompensatoryHoliday(1, TestData.GetEmployee(1), new DateTime(2015, 1, 22), 4.0));

            while (true)
            {
                Console.Write("Enter id of employee you want to calculate bonuses: ");
                int id = Int16.Parse(Console.ReadLine());
                Console.WriteLine("To pay:  {0}", TestData.GetEmployee(id).GetPayment(TestData));
                Console.WriteLine("Compensatory holidays:  {0}", TestData.GetEmployee(id).GetCompensatoryHolidays(TestData));
            }
        }
    }
}
