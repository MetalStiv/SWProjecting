using System;

namespace AccountingOfOverwork.Domain
{
    public class Employee : Entity
    {
        private string name;
        private Position position;
        private string department;
        private string address;
        private string passportData;

        public Employee(string name, Position position, string department, string address, string passportData)
        {
            this.name = name;
            this.position = position;
            this.department = department;
            this.address = address;
            this.passportData = passportData;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PassportData
        {
            get { return passportData; }
            set { passportData = value; }
        }

        //public double GetPayment(IDataManager _dataManager)
        //{
        //    return position.GetPayment(this, _dataManager);
        //}

        //public double GetCompensatoryHolidays(IDataManager _dataManager)
        //{
        //    return position.GetCompensatoryHolidays(this, _dataManager);
        //}
    }
}
