using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    class OverworkDto
    {
        public EmployeeApi Employee { get; set; }
        public DateTime Date { get; set; }
        public CompensatoryRuleDto CompensatoryRule { get; set; }
        public decimal Hourse { get; set; }
    }
}
