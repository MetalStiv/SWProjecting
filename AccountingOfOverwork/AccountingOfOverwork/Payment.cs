using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    //отображает реально выплаченные компенсации за отгулы
    public class Payment
    {
        private double amount;
        private Employee employee;
        private DateTime date;

        public Payment()
        {
            employee = new Employee();
            date = new DateTime(2000, 1, 1);
            amount = 0;
        }

        public Payment(Employee _employee, DateTime _date, double _amount)
        {
            employee = _employee;
            date = _date;
            amount = _amount;
        }

        public Employee getEmployee()
        {
            return employee;
        }
        public DateTime getDate()
        {
            return date;
        }
        public double getAmount()
        {
            return amount;
        }

        public void setEmployee(Employee _employee)
        {
            employee = _employee;
        }
        public void setDate(DateTime _date)
        {
            date = _date;
        }
        public void setAmount(double _amount)
        {
            amount = _amount;
        }
    }
}
