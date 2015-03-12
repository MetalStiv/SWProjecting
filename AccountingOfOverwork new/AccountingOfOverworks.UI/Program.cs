using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingOfOverwork;
using AccountingOfOverwork.Services;
using AccountingOfOverworks.UI.Actions;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoryManagerApi = new RepositoryManagerApi();
            var emloyeesListAction = new ShowEmployeesAction(repositoryManagerApi.GetEmployeeApi());
            var addAction = new AddAction(repositoryManagerApi.GetEmployeeApi(), repositoryManagerApi.GetPositionApi(), repositoryManagerApi.GetRuleApi());
            var removeAction = new RemoveAction(repositoryManagerApi.GetEmployeeApi(), repositoryManagerApi.GetPositionApi(), repositoryManagerApi.GetRuleApi());
            var demo = new DemoDataGenerator(repositoryManagerApi);
            demo.Generate();

            new MenuBuilder()
                .Title("Main menu")
                .Repeatable()
                .Item("Show Employees List", emloyeesListAction)
                .Item("Add", addAction)
                .Item("Remove", removeAction) 
                .Exit("Exit")
                .GetMenu()
                .Run();
        }
    }
}
