using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.DataAccess;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class PaymentApi
    {
        private readonly IRepository<Payment> paymentRepository;
        private readonly IRepository<Employee> employeeRepository;

        public PaymentApi(IRepository<Payment> paymentRepository, IRepository<Employee> employeeRepository)
        {
            this.paymentRepository = paymentRepository;
            this.employeeRepository = employeeRepository;
        }

        public List<PaymentDto> GetPayments()
        {
            return paymentRepository.AsQueryable()
                .Select(p => new PaymentDto
                                 {
                                     Id = p.Id,
                                     Amount = p.Amount,
                                     Date = p.Date,
                                     EmployeeId = p.Employee.Id
                                 })
                .ToList();
        }

        public void AddPayment(PaymentDto paymentDto)
        {
            paymentRepository.Add(new Payment(employeeRepository.Get(paymentDto.EmployeeId), paymentDto.Date, paymentDto.Amount));
        }
    }
}
