using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingOfOverwork.Services;
using AccountingOfOverwork.Services.Dto;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI.Actions
{
    class RemoveAction : IAction
    {
         private readonly EmployeeApi employeeApi;
        private readonly PositionApi positionApi;
        private readonly CompensatoryRuleApi ruleApi;

        public RemoveAction(EmployeeApi employeeApi, PositionApi positionApi, CompensatoryRuleApi ruleApi)
        {
            this.employeeApi = employeeApi;
            this.positionApi = positionApi;
            this.ruleApi = ruleApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var submenu = new MenuBuilder()
                 .Title("Доступные хранилища:")
                 .Prompt("Укажите хранилище:")
                 .RunnableOnce();
                 submenu.Item()
                    .Title("Employee")
                    .Action(ctx => RemoveEmployee(ctx));
                 submenu.Item()
                        .Title("Position")
                        .Action(ctx => RemovePosition(ctx));
                 submenu.Item()
                            .Title("Compensatory Rule")
                            .Action(ctx => RemoveRule(ctx));
                 submenu.Exit("Отмена")
                .GetMenu()
                .Run();
        }

        public void RemovePosition(ActionExecutionContext context)
        {
            PositionDto selectedPosition = null;
            var positions = positionApi.GetPositions();
            var submenu = new MenuBuilder()
                 .Title("Имеющиеся должности:")
                 .Prompt("Укажите должность для удаления:")
                 .RunnableOnce();
            foreach (var position in positions)
            {
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(position.Title)
                       .Action(ctx => selectedPosition = position);
            }
            submenu.Exit("Отмена");
            submenu.GetMenu()
            .Run();

            positionApi.RemovePosition(selectedPosition);
        }

        public void RemoveEmployee(ActionExecutionContext context)
        {
            EmployeeDto selectedEmployee = null;
            var employees = employeeApi.GetEmployees();
            var submenu = new MenuBuilder()
                 .Title("Имеющиеся работники:")
                 .Prompt("Укажите работника для удаления:")
                 .RunnableOnce();
            foreach (var employee in employees)
            {

                submenu.Item()
                       .AlwaysAvailable()
                       .Title(employee.Name)
                       .Action(ctx => selectedEmployee = employee);
            }
            submenu.Exit("Отмена");
            submenu.GetMenu()
            .Run();

            employeeApi.RemoveEmployee(selectedEmployee);
        }

        public void RemoveRule(ActionExecutionContext context)
        {
            CompensatoryRuleDto selectedRule = null;
            var rules = ruleApi.GetRules();
            var submenu = new MenuBuilder()
                 .Title("Имеющиеся правила:")
                 .Prompt("Укажите правило для удаления:")
                 .RunnableOnce();
            foreach (var rule in rules)
            {
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(rule.Title)
                       .Action(ctx => selectedRule = rule);
            }
            submenu.Exit("Отмена");
            submenu.GetMenu()
            .Run();

           ruleApi.RemoveRule(selectedRule);
        }

    }
}
