using System.Collections.Generic;
using System.Linq;
using AccountingOfOverwork.Domain;

namespace AccountingOfOverwork.Services
{
    public class EmployeeApi
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Position> positionRepository;

        public EmployeeApi(IRepository<Employee> employeeRepository, IRepository<Position> positionRepository)
        {
            this.employeeRepository = employeeRepository;
            this.positionRepository = positionRepository;
        }

        public List<EmployeeDto> GetEmployees()
        {
            return employeeRepository.AsQueryable()
                .Select(e => new EmployeeDto
                                 {
                                     Id = e.Id,
                                     Name = e.Name,
                                     PositionTitle = e.Position.Title
                                 })
                .ToList();
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {                
            employeeRepository.Add(new Employee(employeeDto.Name, 
                positionRepository.AsQueryable()
                    .Single(p => p.Title == employeeDto.PositionTitle),
                employeeDto.Department, employeeDto.Adress, employeeDto.PassportData));
        }

        public void RemoveEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto != null)
            {
                var employee = employeeRepository.Get(employeeDto.Id);
                employeeRepository.Remove(employee);
            }
        }
    }
}