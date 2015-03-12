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


            //var compensatoryRule1 = new CompensatoryRule("first", 2, 1);
            //var compensatoryRule2 = new CompensatoryRule("second", 2, 1);
            //overworksRepository.Add(overwork1);
            //overworksRepository.Add(overwork2);
            //var payment1 = new Payment(employee1, new DateTime(2015, 1, 24), 2500);
            //paymentsRepository.Add(payment1);
            //var compansatoryHoliday1 = new CompensatoryHoliday(employee1, new DateTime(2015, 1, 22), 4);
            //holidaysRepository.Add(compansatoryHoliday1);
        }
    }
}