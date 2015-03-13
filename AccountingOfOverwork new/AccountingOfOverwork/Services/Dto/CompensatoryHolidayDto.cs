using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    public class CompensatoryHolidayDto
    {
        public decimal Hours { get; set; }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
