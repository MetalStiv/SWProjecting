using System.Linq;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services;
using Feonufry.CUI.Actions;
using AccountingOfOverwork.DataAccess;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI
{
    public class ShowEmployeesAction : IAction
    {
        private readonly EmployeeApi employeeApi;
        private readonly PositionApi positionApi;
        private readonly CompensatoryRuleApi ruleApi;
        private readonly OverworkApi overworkApi;
        private readonly PaymentApi paymentApi;
        private readonly CompensatoryHolidayApi holidayApi;

        public ShowEmployeesAction(EmployeeApi employeeApi, PositionApi positionApi, CompensatoryRuleApi ruleApi,
            OverworkApi overworkApi, PaymentApi paymentApi, CompensatoryHolidayApi holidayApi)
        {
            this.employeeApi = employeeApi;
            this.positionApi = positionApi;
            this.ruleApi = ruleApi;
            this.overworkApi = overworkApi;
            this.paymentApi = paymentApi;
            this.holidayApi = holidayApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var submenu = new MenuBuilder()
                 .Title("Доступные хранилища:")
                 .Prompt("Укажите хранилище:")
                 .RunnableOnce();
            submenu.Item()
               .Title("Employee")
               .Action(ctx => ShowEmployee(ctx));
            submenu.Item()
                   .Title("Position")
                   .Action(ctx => ShowPosition(ctx));
            submenu.Item()
                       .Title("Compensatory Rule")
                       .Action(ctx => ShowRule(ctx));
            submenu.Item()
                       .Title("Owerwork")
                       .Action(ctx => ShowOverwork(ctx));
            submenu.Item()
                       .Title("Payment")
                       .Action(ctx => ShowPayment(ctx));
            submenu.Item()
                       .Title("Holiday")
                       .Action(ctx => ShowHoliday(ctx));
            submenu.Exit("Отмена")
           .GetMenu()
           .Run();
            
        }

        private void ShowEmployee(ActionExecutionContext context)
        {
            var employees = employeeApi.GetEmployees();
            foreach (var employee in employees)
            {
                context.Out.WriteLine(employee.Name + " - " + employee.PositionTitle);
            }
        }

        private void ShowPosition(ActionExecutionContext context)
        {
            var positions = positionApi.GetPositions();
            foreach (var position in positions)
            {
                context.Out.WriteLine(position.Title + "  " + position.HourlyRate);
            }
        }

        private void ShowRule(ActionExecutionContext context)
        {
            var rules = ruleApi.GetRules();
            foreach (var rule in rules)
            {
                context.Out.WriteLine(rule.Title + ", holiday: " + rule.HolidayCoef + ", payment: " + rule.PaymentCoef);
            }
        }

        private void ShowOverwork(ActionExecutionContext context)
        {
            var overworks = overworkApi.GetOverworks();
            foreach (var overwork in overworks)
            {
                context.Out.WriteLine("employee " + overwork.EmployeeId +" " + overwork.Date.ToString() + " hours " + overwork.Hourse);
            }
        }

        private void ShowPayment(ActionExecutionContext context)
        {
            var payments = paymentApi.GetPayments();
            foreach (var payment in payments)
            {
                context.Out.WriteLine("employee: " + payment.EmployeeId + " " + payment.Date + " " + payment.Amount);
            }
        }

        private void ShowHoliday(ActionExecutionContext context)
        {
            var holidays = holidayApi.GetHolidays();
            foreach (var holiday in holidays)
            {
                context.Out.WriteLine("employee: " + holiday.EmployeeId + " " + holiday.Date + " " + holiday.Hours);
            }
        }
    }
}