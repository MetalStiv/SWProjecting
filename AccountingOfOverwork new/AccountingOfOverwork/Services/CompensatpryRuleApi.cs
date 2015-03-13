using System.Collections.Generic;
using System.Linq;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services.Dto;

namespace AccountingOfOverwork.Services
{
    public class CompensatoryRuleApi
    {
        private readonly IRepository<CompensatoryRule> ruleRepository;

        public CompensatoryRuleApi(IRepository<CompensatoryRule> ruleRepository)
        {
            this.ruleRepository = ruleRepository;
        }

        public List<CompensatoryRuleDto> GetRules()
        {
            return ruleRepository.AsQueryable()
                .Select(p => new CompensatoryRuleDto()
                                 {
                                     Title = p.Title,
                                     PaymentCoef = p.PaymentCoef,
                                     HolidayCoef = p.HolidayCoef,
                                 })
                .ToList();
        }

        public void AddRule(CompensatoryRuleDto ruleDto)
        {
            ruleRepository.Add(new CompensatoryRule(ruleDto.Title, ruleDto.PaymentCoef, ruleDto.HolidayCoef));
        }

        public void RemoveRule(CompensatoryRuleDto ruleDto)
        {
            if (ruleDto != null)
            {
                var rule = ruleRepository.AsQueryable()
                    .Single(p => p.Title == ruleDto.Title);
                ruleRepository.Remove(rule);
            }
        }
    }
}
