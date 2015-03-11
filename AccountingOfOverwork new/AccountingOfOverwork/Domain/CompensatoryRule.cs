using System;

namespace AccountingOfOverwork.Domain
{
    //начисленные бонусы за конкретную переработку
    public class CompensatoryRule : Entity
    {
        private string title;
        private decimal paymentCoef;
        private decimal holidayCoef;

        public CompensatoryRule(string title, decimal paymentCoef, decimal holidayRate)
        {
            this.title = title;
            this.paymentCoef = paymentCoef;
            this.holidayCoef = holidayRate;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public decimal PaymentCoef
        {
            get { return paymentCoef; }
            set { paymentCoef = value; }
        }

        public decimal HolidayCoef
        {
            get { return holidayCoef; }
            set { holidayCoef = value; }
        }
    }
}
