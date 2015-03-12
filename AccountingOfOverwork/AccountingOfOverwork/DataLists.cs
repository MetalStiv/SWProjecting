using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class DataLists : IDataManager
    {
        private List<Employee> employes;
        private List<Project> projects;
        private List<Overwork> overworks;
        private List<Payment> payments;
        private List<CompensatoryHoliday> compensatoryHolidays;

        public DataLists()
        {
            employes = new List<Employee>();
            projects = new List<Project>();
            overworks = new List<Overwork>();
            payments = new List<Payment>();
            compensatoryHolidays = new List<CompensatoryHoliday>();
        }
        public Employee GetEmployee(int _id)
        {
            return employes.Find(x => x.getId() == _id);
        }

        public Project GetProject(int _id)
        {
            return projects.Find(x => x.getId() == _id);
        }

        public Overwork GetOverwork(int _id)
        {
            return overworks.Find(x => x.getId() == _id);
        }

        public Payment GetPayment(int _id)
        {
            return payments.Find(x => x.getId() == _id);
        }

        public CompensatoryHoliday GetCompensatoryHoliday(int _id)
        {
            return compensatoryHolidays.Find(x => x.getId() == _id);
        }

        public void AddEmployee(Employee _employee)
        {
            employes.Add(_employee);
        }

        public void AddProject(Project _project)
        {
            projects.Add(_project);
        }

        public void AddOverwork(Overwork _overwork)
        {
            overworks.Add(_overwork);
        }

        public void AddPayment(Payment _payment)
        {
            payments.Add(_payment);
        }

        public void AddCompensatoryHoliday(CompensatoryHoliday _compensatoryHoliday)
        {
            compensatoryHolidays.Add(_compensatoryHoliday);
        }

        public List<Overwork> GetOwerworksByEmployee(Employee _employee)
        {
            return overworks.FindAll(x => x.getEmployee() == _employee);
        }

        public List<Payment> GetPaymentsByEmployee(Employee _employee)
        {
            return payments.FindAll(x => x.getEmployee() == _employee);
        }

        public List<CompensatoryHoliday> GetCompensatoryHolidaysByEmployee(Employee _employee)
        {
            return compensatoryHolidays.FindAll(x => x.getEmployee() == _employee);
        }
    }
}
