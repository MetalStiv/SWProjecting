using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Position : Entity
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

        public Position(int _id, String _title, double _hourlyRate)
        {
            id = _id;
            title = _title;
            hourlyRate = _hourlyRate;
        }

        public Position()
        {
            title = "";
            hourlyRate = 0.0;
        }

        public double GetPayment(Employee _employee, IDataManager _data)
        {
            double moneyToPay = 0.0;
            List<Overwork> overworks = _data.GetOwerworksByEmployee(_employee);
            foreach (Overwork overwork in overworks)
            {
                if (overwork.getEmployee().Equals(_employee))
                {
                    moneyToPay += overwork.GetPayment(_employee.getPosition());
                }
            }
            List<Payment> payments = _data.GetPaymentsByEmployee(_employee);
            foreach (Payment payment in payments)
            {
                if (payment.getEmployee().Equals(_employee))
                {
                    moneyToPay -= payment.getAmount();
                }
            }
            return moneyToPay;
        }

        public double GetCompensatoryHolidays(Employee _employee, IDataManager _data)
        {
            double hours = 0.0;
            List<Overwork> overworks = _data.GetOwerworksByEmployee(_employee);
            foreach (Overwork overwork in overworks)
            {
                if (overwork.getEmployee().Equals(_employee))
                {
                    hours += overwork.GetCompensatoryHolidays(_employee.getPosition());
                }
            }
            List<CompensatoryHoliday> compensatoryHolidays = _data.GetCompensatoryHolidaysByEmployee(_employee);
            foreach (CompensatoryHoliday compensatoryHoliday in compensatoryHolidays)
            {
                if (compensatoryHoliday.getEmployee().Equals(_employee))
                {
                    hours -= compensatoryHoliday.getHours();
                }
            }
            return hours;
        }
    }
}
