using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    //реально "отгуленные" отгулы)
    public class CompensatoryHoliday :Entity
    {
        private double hours;
        private Employee employee;
        private DateTime date;

        public CompensatoryHoliday()
        {
            employee = new Employee();
            date = new DateTime(2000, 1, 1);
            hours = 0;
        }

        public CompensatoryHoliday(int _id, Employee _employee, DateTime _date, double _hours)
        {
            id = _id;
            employee = _employee;
            date = _date;
            hours = _hours;
        }

        public Employee getEmployee()
        {
            return employee;
        }
        public DateTime getDate()
        {
            return date;
        }
        public double getHours()
        {
            return hours;
        }

        public void setEmployee(Employee _employee)
        {
            employee = _employee;
        }
        public void setDate(DateTime _date)
        {
            date = _date;
        }
        public void setAmount(double _hours)
        {
            hours = _hours;
        }
    }
}
