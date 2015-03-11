using System.Linq;
using AccountingOfOverwork.Domain;
using AccountingOfOverwork.Services;
using Feonufry.CUI.Actions;
using AccountingOfOverwork.DataAccess;

namespace AccountingOfOverworks.UI
{
    public class ShowEmployeesAction : IAction
    {
        private readonly EmployeeApi employeeApi;

        public ShowEmployeesAction(EmployeeApi employeeApi)
        {
            this.employeeApi = employeeApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var employees = employeeApi.GetEmployees();
            foreach (var employee in employees)
            {
                context.Out.WriteLine(employee.Id + "  " + employee.Name);
            }
        }
    }
}