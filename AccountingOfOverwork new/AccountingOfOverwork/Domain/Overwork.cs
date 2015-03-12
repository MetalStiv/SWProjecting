using System;

namespace AccountingOfOverwork.Domain
{
    public class Overwork : Entity
    {
        private Employee employee;
        private DateTime date;
        private CompensatoryRule compensatoryRule;
        private decimal hours;

        public Overwork(Employee employee, DateTime date, decimal hours, CompensatoryRule compensatoryRule)
        {
            this.employee = employee;
            this.compensatoryRule = compensatoryRule;
            this.date = date;
            this.hours = hours;
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

        public decimal GetPayment()
        {
            return this.Employee.Position.HourlyRate * this.Hours * this.CompensatoryRule.PaymentCoef;
        }

        public decimal GetCompensatoryHolidays()
        {
            return this.Hours * this.CompensatoryRule.HolidayCoef;
        }
    }
}
