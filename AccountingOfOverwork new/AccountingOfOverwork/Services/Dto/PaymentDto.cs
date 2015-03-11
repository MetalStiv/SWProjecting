using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    class PaymentDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
