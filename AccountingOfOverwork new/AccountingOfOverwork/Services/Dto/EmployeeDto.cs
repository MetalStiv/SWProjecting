using System;

namespace AccountingOfOverwork.Services
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string Adress { get; set; }
        public string PassportData { get; set; }
    }
}