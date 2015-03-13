using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    public class OverworkDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public Guid CompensatoryRuleId { get; set; }
        public decimal Hourse { get; set; }
    }
}
