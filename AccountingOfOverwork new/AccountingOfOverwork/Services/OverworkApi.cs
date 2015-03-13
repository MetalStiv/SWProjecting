using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.DataAccess;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class OverworkApi
    {
        private readonly IRepository<Overwork> overworkRepository;
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<CompensatoryRule> compensatoryRuleRepository;

        public OverworkApi(IRepository<Overwork> overworkRepository, IRepository<Employee> employeeRepository,
            IRepository<CompensatoryRule> compensatoryRuleRepository)
        {
            this.overworkRepository = overworkRepository;
            this.employeeRepository = employeeRepository;
            this.compensatoryRuleRepository = compensatoryRuleRepository;
        }

        public List<OverworkDto> GetOverworks()
        {
            return overworkRepository.AsQueryable()
                .Select(o => new OverworkDto
                {
                    Date = o.Date,
                    Hourse = o.Hours,
                    EmployeeId = o.Employee.Id,
                    CompensatoryRuleId = o.CompensatoryRule.Id,
                    Id = o.Id
                })
                .ToList();
        }

        public void AddOverwork(OverworkDto overworkDto)
        {
            overworkRepository.Add(new Overwork(employeeRepository.Get(overworkDto.EmployeeId),
                overworkDto.Date, overworkDto.Hourse, compensatoryRuleRepository.Get(overworkDto.CompensatoryRuleId)));
        }

        public void RemoveOverwork(OverworkDto overworkDto)
        {
            if (overworkDto != null)
            {
                var overwork = overworkRepository.Get(overworkDto.Id);
                overworkRepository.Remove(overwork);
            }
        }
    }
}
