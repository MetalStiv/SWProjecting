using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
