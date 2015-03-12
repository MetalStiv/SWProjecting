using System;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services;
using AccountingOfOverwork.Services.Dto;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;

namespace AccountingOfOverworks.UI
{
    class AddAction : IAction

    {
        private readonly EmployeeApi employeeApi;
        private readonly PositionApi positionApi;
        private readonly CompensatoryRuleApi ruleApi;

        public AddAction(EmployeeApi employeeApi, PositionApi positionApi, CompensatoryRuleApi ruleApi)
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
                    .Action(ctx => AddEmployee(ctx));
                 submenu.Item()
                        .Title("Position")
                        .Action(ctx => AddPosition(ctx));
                 submenu.Item()
                            .Title("Compensatory Rule")
                            .Action(ctx => AddRule(ctx));
                 submenu.Exit("Отмена")
                .GetMenu()
                .Run();
        }

        public void AddEmployee(ActionExecutionContext context)
        {
            var positionsList = positionApi.GetPositions();
            context.Out.WriteLine("Name:");
            string name = context.In.ReadLine();
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

        public void AddPosition(ActionExecutionContext context)
        {
            context.Out.WriteLine("Titel:");
            string title = context.In.ReadLine();
            context.Out.WriteLine("Hourly Rate:");
            decimal hourlyRate = Decimal.Parse(context.In.ReadLine());

            var position = new PositionDto();
            position.Title = title;
            position.HourlyRate = hourlyRate;

            positionApi.AddPosition(position);
        }

        public void AddRule(ActionExecutionContext context)
        {
            context.Out.WriteLine("Titel:");
            string title = context.In.ReadLine();
            context.Out.WriteLine("Holiday coefficient:");
            decimal holidayCoef = Decimal.Parse(context.In.ReadLine());
            context.Out.WriteLine("Payment coefficient:");
            decimal paymentCoef = Decimal.Parse(context.In.ReadLine());

            var rule = new CompensatoryRuleDto();
            rule.Title = title;
            rule.HolidayCoef = holidayCoef;
            rule.PaymentCoef = paymentCoef;

            ruleApi.AddRule(rule);
        }
    }
}
