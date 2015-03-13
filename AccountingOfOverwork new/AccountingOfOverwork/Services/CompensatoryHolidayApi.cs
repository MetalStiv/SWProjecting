using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class CompensatoryHolidayApi
    {
        private readonly IRepository<CompensatoryHoliday> holidayRepository;
        private readonly IRepository<Employee> employeeRepository;

        public CompensatoryHolidayApi(IRepository<CompensatoryHoliday> holidayRepository, IRepository<Employee> employeeRepository)
        {
            this.holidayRepository = holidayRepository;
            this.employeeRepository = employeeRepository;
        }

        public List<CompensatoryHolidayDto> GetHolidays()
        {
            return holidayRepository.AsQueryable()
                .Select(h => new CompensatoryHolidayDto
                {
                    Id = h.Id,
                    Hours = h.Hours,
                    Date = h.Date,
                    EmployeeId = h.Employee.Id
                })
                .ToList();
        }

        public void AddHoliday(CompensatoryHolidayDto holidayDto)
        {
            holidayRepository.Add(new CompensatoryHoliday(employeeRepository.Get(holidayDto.EmployeeId), holidayDto.Date, holidayDto.Hours));
        }
    }
}
