using System;

namespace AccountingOfOverwork.Domain
{
    //отображает реально выплаченные компенсации за отгулы
    public class Payment : Entity
    {
        private decimal amount;
        private Employee employee;
        private DateTime date;

        public Payment(Employee employee, DateTime date, decimal amount)
        {
            this.employee = employee;
            this.date = date;
            this.amount = amount;
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
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
