using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services;
using AccountingOfOverwork.Services.Dto;
using System;

namespace AccountingOfOverwork
{
    public class DemoDataGenerator
    {
        private RepositoryManagerApi repositoryManager;

        public DemoDataGenerator(RepositoryManagerApi repositoryManager)
        {
            this.repositoryManager = repositoryManager;

        }

        public void Generate()
        {
            var positionApi = repositoryManager.GetPositionApi();
            var employeeApi = repositoryManager.GetEmployeeApi();
            var ruleApi = repositoryManager.GetRuleApi();
            var holidayApi = repositoryManager.GetHolidayApi();
            var paymentApi = repositoryManager.GetPaymentApi();
            var overworkApi = repositoryManager.GetOwerworkApi();

            var position1 = new PositionDto();
            position1.Title = "Programmer";
            position1.HourlyRate = 200;
            positionApi.AddPosition(position1);

            var position2 = new PositionDto();
            position2.Title = "Junior Programmer";
            position2.HourlyRate = 120;
            positionApi.AddPosition(position2);

            var employee1 = new EmployeeDto();
            employee1.Name = "Ivan";
            employee1.PositionTitle = position1.Title;
            employee1.Department = "Main";
            employee1.Adress = "Moscow st., 237-24";
            employee1.PassportData = "2000 123456";
            employeeApi.AddEmployee(employee1);

            var employee2 = new EmployeeDto();
            employee2.Name = "Petr";
            employee2.PositionTitle = position2.Title;
            employee2.Department = "Main";
            employee2.Adress = "Moscow st., 136-18";
            employee2.PassportData = "2000 654321";
            employeeApi.AddEmployee(employee2);

            var compensatoryRule1 = new CompensatoryRuleDto();
            compensatoryRule1.Title = "first";
            compensatoryRule1.HolidayCoef = 2;
            compensatoryRule1.PaymentCoef = 1;
            ruleApi.AddRule(compensatoryRule1);

            var compensatoryRule2 = new CompensatoryRuleDto();
            compensatoryRule2.Title = "second";
            compensatoryRule2.HolidayCoef = 1;
            compensatoryRule2.PaymentCoef = 2;
            ruleApi.AddRule(compensatoryRule2);

            var overwork1 = new OverworkDto();
            overwork1.CompensatoryRuleId = compensatoryRule1.Id;
            overwork1.Date = new DateTime(2015, 1, 24);
            overwork1.EmployeeId = employee1.Id;
            overwork1.Hourse = 3;
            overworkApi.AddOverwork(overwork1);

            var payment1 = new PaymentDto();
            payment1.EmployeeId = employee1.Id;
            payment1.Date = new DateTime(2015, 4, 2);
            payment1.Amount = 200;
            paymentApi.AddPayment(payment1);

            var holiday1 = new CompensatoryHolidayDto();
            holiday1.EmployeeId = employee1.Id;
            holiday1.Date = new DateTime(2015, 2, 2);
            holiday1.Hours = 8;
            holidayApi.AddHoliday(holiday1);
        }
    }
}