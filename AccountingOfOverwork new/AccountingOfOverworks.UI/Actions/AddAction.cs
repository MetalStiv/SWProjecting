using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingOfOverwork.Services;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI
{
    class AddAction : IAction

    {
        private readonly EmployeeApi employeeApi;
        private readonly PositionApi positionApi;

        public AddAction(EmployeeApi employeeApi, PositionApi positionApi)
        {
            this.employeeApi = employeeApi;
            this.positionApi = positionApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var submenu = new MenuBuilder()
                 .Title("Доступные хранилища:")
                 .Prompt("Укажите хранилище:")
                 .RunnableOnce();
                 submenu.Item()
                    .Title("Employee")
                    .Action(ctx => AddEmployee(ctx));
                 submenu.Exit("Отмена")
                .GetMenu()
                .Run();
        }

        public void AddEmployee(ActionExecutionContext context)
        {
            var positionsList = positionApi.GetPositions();
            context.Out.WriteLine("Name:");
            string name = context.In.ReadLine();
            // position
            //context.Out.WriteLine("position:");
            string positionName = "";

            var submenu = new MenuBuilder()
                 .Title("Доступные должности:")
                 .Prompt("Укажите должность:")
                 .RunnableOnce();
            foreach (var position in positionsList)
            {
                var positionTitle = position.Title;
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(position.Title)
                       .Action(ctx => positionName = PosisionSelect(ctx, positionTitle));
            }
           // submenu.Exit("Отмена")
           submenu.GetMenu()
           .Run();

            
            context.Out.WriteLine("department:");
            string department = context.In.ReadLine();
            context.Out.WriteLine("address:");
            string address = context.In.ReadLine();
            context.Out.WriteLine("passportData:");
            string passportData = context.In.ReadLine();

            var employee = new EmployeeDto();
            employee.Name = name;
            employee.Department = department;
            employee.Adress = address;
            employee.PassportData = passportData;
            employee.PositionTitle = positionName;    

            employeeApi.AddEmployee(employee);
        }

        public string PosisionSelect(ActionExecutionContext context, string positionTitle)
        {
            return positionTitle;
        }
    }
}
