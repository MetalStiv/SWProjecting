using System;
using System.Collections.Generic;

namespace AccountingOfOverwork.Domain
{
    public class Position : Entity
    {
        private string title;
        private decimal hourlyRate;

        public Position(string title, decimal hourlyRate)
        {
            this.title = title;
            this.hourlyRate = hourlyRate;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public decimal HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value; }
        }

        //public double GetPayment(Employee _employee, IDataManager _data)
        //{
        //    double moneyToPay = 0.0;
        //    List<Overwork> overworks = _data.GetOwerworksByEmployee(_employee);
        //    foreach (Overwork overwork in overworks)
        //    {
        //        moneyToPay += overwork.GetPayment(_employee.getPosition());
        //    }
        //    List<Payment> payments = _data.GetPaymentsByEmployee(_employee);
        //    foreach (Payment payment in payments)
        //    {
        //        moneyToPay -= payment.getAmount();
        //    }
        //    return moneyToPay;
        //}

        //public double GetCompensatoryHolidays(Employee _employee, IDataManager _data)
        //{
        //    double hours = 0.0;
        //    List<Overwork> overworks = _data.GetOwerworksByEmployee(_employee);
        //    foreach (Overwork overwork in overworks)
        //    {
        //        hours += overwork.GetCompensatoryHolidays(_employee.getPosition());
        //    }
        //    List<CompensatoryHoliday> compensatoryHolidays = _data.GetCompensatoryHolidaysByEmployee(_employee);
        //    foreach (CompensatoryHoliday compensatoryHoliday in compensatoryHolidays)
        //    {
        //        hours -= compensatoryHoliday.getHours();
        //    }
        //    return hours;
        //}
    }
}
