using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    //начисленные бонусы за конкретную переработку
    public class CompensatoryRule : Entity
    {
        private String title;
        private double paymentCoef;
        private double holidayCoef;

        public CompensatoryRule()
        {
            title = "";
            paymentCoef = 1;
            holidayCoef = 0;
        }

        public CompensatoryRule(int _id, String _title, double _paymentCoef, double _holidayRate)
        {
            id = _id;
            title = _title;
            paymentCoef = _paymentCoef;
            holidayCoef = _holidayRate;
        }

        public String getTitle()
        {
            return title;
        }
        public double getPaymentCoef()
        {
            return paymentCoef;
        }
        public double getHolidayCoef()
        {
            return holidayCoef;
        }

        public void setTitle(String _title)
        {
            title = _title;
        }
        public void setPaymentCoef(double _payment)
        {
            paymentCoef = _payment;
        }
        public void setHolidayCoef(double _holiday)
        {
            holidayCoef = _holiday;
        }

        public double GetExtraPayment(Overwork _overwork, Position position)
        {
            return _overwork.getHours() * paymentCoef * position.getHourlyRate();
        }

        public double GetCompensatoryHolidays(Overwork _overwork, Position position)
        {
            return _overwork.getHours() * holidayCoef;
        }
    }
}
