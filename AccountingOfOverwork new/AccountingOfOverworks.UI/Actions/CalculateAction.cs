using System;
using System.Collections.Generic;
using System.Linq;
using Feonufry.CUI.Actions;
using AccountingOfOverwork.Domain;

namespace AccountingOfOverworks.UI.Actions
{
    class CalculateAction : IAction
    {
        private readonly IRepository<Employee> employeesReposiotry;
        private readonly IRepository<Overwork> overworksReposiotry;
        private readonly IRepository<Payment> paymentsReposiotry;
        private readonly IRepository<CompensatoryHoliday> compensatoryHolidaysReposiotry;

        public CalculateAction(IRepository<Employee> employeesReposiotry, IRepository<Overwork> overworksReposiotry,
            IRepository<Payment> paymentsReposiotry, IRepository<CompensatoryHoliday> compensatoryHolidaysReposiotry)
        {
            this.employeesReposiotry = employeesReposiotry;
            this.overworksReposiotry = overworksReposiotry;
            this.paymentsReposiotry = paymentsReposiotry;
            this.compensatoryHolidaysReposiotry = compensatoryHolidaysReposiotry;
        }

        public void Perform(ActionExecutionContext context)
        {
            var employees = employeesReposiotry.AsQueryable().ToList();
            int index = 1;
            foreach (var employee in employees)
            {
                context.Out.WriteLine(index + "  " + employee.Name);
                index++;
            }
            context.Out.WriteLine("Enter id of employee you want to calculate:  ");
            index = Int32.Parse(Console.ReadLine()) - 1;
            //context.Out.WriteLine("To pay:  {0}", );
        }
    }
}
