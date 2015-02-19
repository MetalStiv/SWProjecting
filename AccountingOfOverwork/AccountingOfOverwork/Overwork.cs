using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Overwork
    {
        private Employee employee;
        private Project project;
        private DateTime date;
        private CompensatoryRule compensatoryRule;
        private double hours;

        public Overwork()
        {
            employee = new Employee();
            project = new Project();
            compensatoryRule = new CompensatoryRule();
            date = new DateTime(2000,1,1);
            hours = 0;
        }
        public Overwork(Employee _employee, Project _project, DateTime _date, double _hours, CompensatoryRule _compensatoryRule)
        {
            employee = _employee;
            project = _project;
            compensatoryRule = _compensatoryRule;
            date = _date;
            hours = _hours;
        }

        public Employee getEmployee()
        {
            return employee;
        }
        public Project getProject()
        {
            return project;
        }
        public DateTime getDate()
        {
            return date;
        }
        public double getHours()
        {
            return hours;
        }
        public CompensatoryRule getCompensatoryRule()
        {
            return compensatoryRule;
        }

        public void setEmployee(Employee _employee)
        {
            employee = _employee;
        }
        public void setProject(Project _project)
        {
            project = _project;
        }
        public void setDate(DateTime _date)
        {
            date = _date;
        }
        public void setHours(double _hours)
        {
           hours = _hours;
        }
        public void setCompensatoryRule(CompensatoryRule _compensatoryRule)
        {
            compensatoryRule = _compensatoryRule;
        }

        public double GetPayment(Position _position)
        {
            return compensatoryRule.GetExtraPayment(this, _position);
        }

        public double GetCompensatoryHolidays(Position _position)
        {
            return compensatoryRule.GetCompensatoryHolidays(this, _position);
        }
    }
}
