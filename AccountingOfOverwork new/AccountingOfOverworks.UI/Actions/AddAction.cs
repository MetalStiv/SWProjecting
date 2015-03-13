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
        private readonly OverworkApi overworkApi;
        private readonly PaymentApi paymentApi;
        private readonly CompensatoryHolidayApi holidayApi;

        public AddAction(EmployeeApi employeeApi, PositionApi positionApi, CompensatoryRuleApi ruleApi,
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
                    .Action(ctx => AddEmployee(ctx));
                 submenu.Item()
                        .Title("Position")
                        .Action(ctx => AddPosition(ctx));
                 submenu.Item()
                            .Title("Compensatory Rule")
                            .Action(ctx => AddRule(ctx));
                 submenu.Item()
                            .Title("Owerwork")
                            .Action(ctx => AddOverwork(ctx));
                 submenu.Item()
                            .Title("Payment")
                            .Action(ctx => AddPayment(ctx));
                 submenu.Item()
                            .Title("Holiday")
                            .Action(ctx => AddHoliday(ctx));
                 submenu.Exit("Отмена")
                .GetMenu()
                .Run();
        }

        public void AddEmployee(ActionExecutionContext context)
        {
            var positionsList = positionApi.GetPositions();
            context.Out.Write("Name: ");
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

            context.Out.Write("department: ");
            string department = context.In.ReadLine();
            context.Out.Write("address: ");
            string address = context.In.ReadLine();
            context.Out.Write("passportData: ");
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

        public Guid EmployeeSelect(ActionExecutionContext context, Guid employeeId)
        {
            return employeeId;
        }

        public Guid RuleSelect(ActionExecutionContext context, Guid ruleId)
        {
            return ruleId;
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
            context.Out.Write("Titel: ");
            string title = context.In.ReadLine();
            context.Out.Write("Holiday coefficient: ");
            decimal holidayCoef = Decimal.Parse(context.In.ReadLine());
            context.Out.Write("Payment coefficient: ");
            decimal paymentCoef = Decimal.Parse(context.In.ReadLine());

            var rule = new CompensatoryRuleDto();
            rule.Title = title;
            rule.HolidayCoef = holidayCoef;
            rule.PaymentCoef = paymentCoef;

            ruleApi.AddRule(rule);
        }

        public void AddOverwork(ActionExecutionContext context)
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

            var ruleList = ruleApi.GetRules();
            Guid ruleId = new Guid();

            submenu = new MenuBuilder()
                 .Title("Доступные правила компенсации:")
                 .Prompt("Укажите правило компенсации:")
                 .RunnableOnce();
            foreach (var rule in ruleList)
            {
                var ruleName = rule.Title;
                submenu.Item()
                       .AlwaysAvailable()
                       .Title(rule.Title)
                       .Action(ctx => ruleId = RuleSelect(ctx, rule.Id));
            }
            submenu.GetMenu()
            .Run();

            context.Out.Write("date: ");

            DateTime date = new DateTime();
            while (!DateTime.TryParse(context.In.ReadLine(), out date))
            {
                context.Out.Write("date is not valid, try once more: ");
            }

            context.Out.Write("hourse: ");
            decimal hourse;
            while (!Decimal.TryParse(context.In.ReadLine(), out hourse))
            {
                context.Out.Write("hourse is not valid, try once more: ");
            }

            var overwork = new OverworkDto();
            overwork.Date = date;
            overwork.Hourse = hourse;
            overwork.EmployeeId = employeeId;
            overwork.CompensatoryRuleId = ruleId;

            overworkApi.AddOverwork(overwork);
        }

        public void AddPayment(ActionExecutionContext context)
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

            context.Out.Write("date: ");

            DateTime date = new DateTime();
            while (!DateTime.TryParse(context.In.ReadLine(), out date))
            {
                context.Out.Write("date is not valid, try once more: ");
            }

            context.Out.Write("amount: ");
            decimal amount;
            while (!Decimal.TryParse(context.In.ReadLine(), out amount))
            {
                context.Out.Write("amount is not valid, try once more: ");
            }

            var payment = new PaymentDto();
            payment.EmployeeId = employeeId;
            payment.Date = date;
            payment.Amount = amount;

            paymentApi.AddPayment(payment);
        }

        public void AddHoliday(ActionExecutionContext context)
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

            context.Out.Write("date: ");

            DateTime date = new DateTime();
            while (!DateTime.TryParse(context.In.ReadLine(), out date))
            {
                context.Out.Write("date is not valid, try once more: ");
            }

            context.Out.Write("hours: ");
            decimal hours;
            while (!Decimal.TryParse(context.In.ReadLine(), out hours))
            {
                context.Out.Write("hours is not valid, try once more: ");
            }

            var holiday = new CompensatoryHolidayDto();
            holiday.EmployeeId = employeeId;
            holiday.Date = date;
            holiday.Hours = hours;

            holidayApi.AddHoliday(holiday);
        }
    }
}
