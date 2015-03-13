using System;
using System.Collections.Generic;
using System.Linq;
using Feonufry.CUI.Actions;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services;
using AccountingOfOverwork.Services.Dto;
//using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI.Actions
{
    class CalculateAction : IAction
    {
        private readonly CalculatorApi calculatorApi;
        private readonly EmployeeApi employeeApi;

        public CalculateAction(CalculatorApi calculatorApi, EmployeeApi employeeApi)
        {
            this.calculatorApi = calculatorApi;
            this.employeeApi = employeeApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var submenu = new MenuBuilder()
                 .Title("Доступные действия:")
                 .Prompt("Выбирете действие:")
                 .RunnableOnce();
            submenu.Item()
               .Title("Calculate money")
               .Action(ctx => CalculateMoney(ctx));
            submenu.Item()
                   .Title("Calculate holidays")
                   .Action(ctx => CalculateHolidays(ctx));
            submenu.Exit("Отмена")
           .GetMenu()
           .Run();
        }

        public Guid EmployeeSelect(ActionExecutionContext context, Guid employeeId)
        {
            return employeeId;
        }

        public void CalculateMoney(ActionExecutionContext context)
        {
            var employeeList = employeeApi.GetEmployees();
            Guid employeeId = new Guid();

            var submenu = new MenuBuilder()
                 .Title("Доступные сотрудники:")
                 .Prompt("Укажите сотрудника:")
                 .RunnableOnce();
            foreach (var employee in employeeList)
            {
                var employeeName = employee.Name;
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(employee.Name)
                       .Action(ctx => employeeId = EmployeeSelect(ctx, employee.Id));
            }
            submenu.GetMenu()
            .Run();

            Console.WriteLine("To pay: {0}", calculatorApi.GetPayment(employeeId));
        }

        public void CalculateHolidays(ActionExecutionContext context)
        {
            var employeeList = employeeApi.GetEmployees();
            Guid employeeId = new Guid();

            var submenu = new MenuBuilder()
                 .Title("Доступные сотрудники:")
                 .Prompt("Укажите сотрудника:")
                 .RunnableOnce();
            foreach (var employee in employeeList)
            {
                var employeeName = employee.Name;
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(employee.Name)
                       .Action(ctx => employeeId = EmployeeSelect(ctx, employee.Id));
            }
            submenu.GetMenu()
            .Run();

            Console.WriteLine("To pay: {0}", calculatorApi.GetCompensatoryHolidays(employeeId));
        }
    }
}
