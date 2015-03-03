using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingOfOverwork;
using AccountingOfOverwork.DataAccess;
using AccountingOfOverwork.Domain;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesRepository = new MemoryRepository<Employee>();
            var positionsRepository = new MemoryRepository<Position>();
            var emloyeesListAction = new ShowEmployeesAction(employeesRepository);
            var demo = new DemoDataGenerator(positionsRepository, employeesRepository);
            demo.Generate();

            new MenuBuilder()
                .Title("Main menu")
                .Repeatable()
                .Item("Show Employees List", emloyeesListAction)
                .Exit("Exit")
                .GetMenu()
                .Run();
        }
    }
}
