using System;

namespace AccountingOfOverwork.Domain
{
    public class Overwork : Entity
    {
        private Employee employee;
        private Project project;
        private DateTime date;
        private CompensatoryRule compensatoryRule;
        private decimal hours;

        public Overwork(Employee employee, Project project, DateTime date, decimal hours, CompensatoryRule compensatoryRule)
        {
            this.employee = employee;
            this.project = project;
            this.compensatoryRule = compensatoryRule;
            this.date = date;
            this.hours = hours;
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public CompensatoryRule CompensatoryRule
        {
            get { return compensatoryRule; }
            set { compensatoryRule = value; }
        }

        public decimal Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        //public double GetPayment(Position _position)
        //{
        //    return compensatoryRule.GetExtraPayment(this, _position);
        //}

        //public double GetCompensatoryHolidays(Position _position)
        //{
        //    return compensatoryRule.GetCompensatoryHolidays(this, _position);
        //}
    }
}
