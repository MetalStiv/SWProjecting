﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.DataAccess;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class RepositoryManagerApi
    {
        private IRepository<Employee> employeeRepository;
        private IRepository<Position> positionRepository;
        private IRepository<Overwork> overworkRepository;
        private IRepository<Payment> paymentRepository;
        private IRepository<CompensatoryHoliday> compensatoryHolidayRepository;
        private IRepository<CompensatoryRule> compensatoryRuleRepository;

        public RepositoryManagerApi()
        {
            employeeRepository = new MemoryRepository<Employee>();
            positionRepository = new MemoryRepository<Position>();
            overworkRepository = new MemoryRepository<Overwork>();
            paymentRepository = new MemoryRepository<Payment>();
            compensatoryHolidayRepository = new MemoryRepository<CompensatoryHoliday>();
            compensatoryRuleRepository = new MemoryRepository<CompensatoryRule>();
        }

        public EmployeeApi GetEmployeeApi()
        {
            return new EmployeeApi(employeeRepository, positionRepository);
        }

        public PositionApi GetPositionApi()
        {
            return new PositionApi(positionRepository);
        }

        public CompensatoryRuleApi GetRuleApi()
        {
            return new CompensatoryRuleApi(compensatoryRuleRepository);
        }

        public OverworkApi GetOwerworkApi()
        {
            return new OverworkApi(overworkRepository, employeeRepository, compensatoryRuleRepository);
        }

        public PaymentApi GetPaymentApi()
        {
            return new PaymentApi(paymentRepository, employeeRepository);
        }

        public CompensatoryHolidayApi GetHolidayApi()
        {
            return new CompensatoryHolidayApi(compensatoryHolidayRepository, employeeRepository);
        }

        public CalculatorApi GetCalculatorApi()
        {
            return new CalculatorApi(employeeRepository, overworkRepository, paymentRepository,compensatoryHolidayRepository);
        }
    }
}
