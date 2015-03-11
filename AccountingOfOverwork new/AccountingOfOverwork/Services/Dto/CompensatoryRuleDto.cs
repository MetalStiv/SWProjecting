using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork.Services.Dto
{
    class CompensatoryRuleDto
    {
        public string Title { get; set; }
        public decimal PaymentCoef { get; set; }
        public decimal HolidayCoef { get; set; }
    }
}
