using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Employee
    {
        private String name;
        private Position position;
        private String department;
        private String address;
        private String passportData;

        public Employee()
        {
            name = "";
            position = new Position();
            department = "";
            address = "";
            passportData = "";
        }

        public Employee(String _name, Position _position, String _department, String _address, String _passportData)
        {
            name = _name;
            position = _position;
            department = _department;
            address = _address;
            passportData = _passportData;
        }

        public String getName()
        {
            return name;
        }

        public Position getPosition()
        {
            return position;
        }
        public String getDepartment()
        {
            return department;
        }
        public String getAddress()
        {
            return address;
        }
        public String getPassportData()
        {
            return passportData;
        }

        public void setName(String _name)
        {
            name = _name;
        }
        public void setPosision(Position _position)
        {
            position = _position;
        }
        public void setAddress(String _address)
        {
            address = _address;
        }
        public void setPassportData(String _data)
        {
            passportData = _data;
        }
        public void setDepartment(String _department)
        {
            department = _department;
        }

        public double GetPayment()
        {
            return position.GetPayment(this);
        }        
            
        public double GetCompensatoryHolidays()
        {
            return position.GetCompensatoryHolidays(this);
        }
    }
}
