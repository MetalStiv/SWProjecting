using System;

namespace AccountingOfOverwork.Domain
{
    //реально "отгуленные" отгулы)
    public class CompensatoryHoliday : Entity
    {
        private decimal hours;
        private Employee employee;
        private DateTime date;

        public CompensatoryHoliday(Employee employee, DateTime date, decimal hours)
        {
            this.employee = employee;
            this.date = date;
            this.hours = hours;
        }

        public decimal Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
