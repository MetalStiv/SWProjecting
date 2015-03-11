using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;

namespace AccountingOfOverwork.Services
{
    public class Calculator
    {
        public static decimal GetPayment(Guid employeeID, IRepository<Payment> paymentRepository, IRepository<Overwork> overworkRepository)
        {
            var moneyToPay = overworkRepository.AsQueryable()
                .Where(x => x.Employee.Id == employeeID)
                .ToList()
                .Sum(x => x.GetPayment());

            var payments = paymentRepository.AsQueryable().ToList().FindAll(x => x.Employee.Id == employeeID);
            foreach (var payment in payments)
            {
                moneyToPay -= payment.Amount;
            }
            return moneyToPay;
        }

        public static decimal GetCompensatoryHolidays(Guid employeeID, IRepository<CompensatoryHoliday>
                compensatoryHolidayRepository, IRepository<Overwork> overworkRepository)
        {
            decimal freeHours = 0;
            var overworks = overworkRepository.AsQueryable().ToList().FindAll(x => x.Employee.Id == employeeID);
            foreach (Overwork overwork in overworks)
            {
                freeHours += overwork.GetCompensatoryHolidays();
            }
            var compensatoryHolidays = compensatoryHolidayRepository.AsQueryable().ToList().FindAll(x => x.Employee.Id == employeeID);
            foreach (CompensatoryHoliday compensatoryHoliday in compensatoryHolidays)
            {
                freeHours -= compensatoryHoliday.Hours;
            }
            return freeHours;
        }
    }
}

//https://bitbucket.org/feonufry/cui/