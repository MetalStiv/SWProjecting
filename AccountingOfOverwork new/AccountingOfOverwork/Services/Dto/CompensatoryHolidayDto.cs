using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    class CompensatoryHolidayDto
    {
        public decimal Hourse { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime Date { get; set; }
    }
}
