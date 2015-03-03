using System.Linq;
using AccountingOfOverwork.Domain;
using Feonufry.CUI.Actions;

namespace AccountingOfOverworks.UI
{
    public class ShowEmployeesAction : IAction
    {
        private readonly IRepository<Employee> employeesReposiotry;

        public ShowEmployeesAction(IRepository<Employee> employeesReposiotry)
        {
            this.employeesReposiotry = employeesReposiotry;
        }

        public void Perform(ActionExecutionContext context)
        {
            var employees = employeesReposiotry.AsQueryable().ToList();
            foreach (var employee in employees)
            {
                context.Out.WriteLine(employee.Name);
            }
        }
    }
}