using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class CalculatorApi
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Overwork> overworkRepository;
        private readonly IRepository<Payment> paymentRepository;
        private readonly IRepository<CompensatoryHoliday> holidayRepository;

        public CalculatorApi(IRepository<Employee> employeeRepository, IRepository<Overwork> overworkRepository,
            IRepository<Payment> paymentRepository, IRepository<CompensatoryHoliday> holidayRepository)
        {
            this.employeeRepository = employeeRepository;
            this.overworkRepository = overworkRepository;
            this.paymentRepository = paymentRepository;
            this.holidayRepository = holidayRepository;
        }

        public decimal GetCompensatoryHolidays(Guid employeeId)
        {
            return Calculator.GetCompensatoryHolidays(employeeId, holidayRepository, overworkRepository);
        }

        public decimal GetPayment(Guid employeeId)
        {
            return Calculator.GetPayment(employeeId, paymentRepository, overworkRepository);
        }
    }
}
