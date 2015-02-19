using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Position
    {
        private String title;
        private double hourlyRate;

        public String getTitle()
        {
            return title;
        }

        public void setTitle(String _title)
        {
            title = _title;
        }

        public double getHourlyRate()
        {
            return hourlyRate;
        }

        public void setHourlyRate(double _rate)
        {
            hourlyRate = _rate;
        }

        public Position(String _title, double _hourlyRate)
        {
            title = _title;
            hourlyRate = _hourlyRate;
        }

        public Position()
        {
            title = "";
            hourlyRate = 0.0;
        }

        public double GetPayment(Employee employee)
        {
            double moneyToPay = 0.0;
            foreach (Overwork overwork in DataManagement.overworks)
            {
                if (overwork.getEmployee().Equals(employee))
                {
                    moneyToPay += overwork.GetPayment(employee.getPosition());
                }
            }
            foreach (Payment payment in DataManagement.payments)
            {
                if (payment.getEmployee().Equals(employee))
                {
                    moneyToPay -= payment.getAmount();
                }
            }
            return moneyToPay;
        }

        public double GetCompensatoryHolidays(Employee employee)
        {
            double hours = 0.0;
            foreach (Overwork overwork in DataManagement.overworks)
            {
                if (overwork.getEmployee().Equals(employee))
                {
                    hours += overwork.GetCompensatoryHolidays(employee.getPosition());
                }
            }
            foreach (CompensatoryHoliday compensatoryHoliday in DataManagement.compensatoryHolidays)
            {
                if (compensatoryHoliday.getEmployee().Equals(employee))
                {
                    hours -= compensatoryHoliday.getHours();
                }
            }
            return hours;
        }
    }
}
