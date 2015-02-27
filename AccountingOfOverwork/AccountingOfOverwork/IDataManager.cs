using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public interface IDataManager
    {
        Employee GetEmployee(int _id);
        Project GetProject(int _id);
        Overwork GetOverwork(int _id);
        Payment GetPayment(int _id);
        CompensatoryHoliday GetCompensatoryHoliday(int _id);

        void AddEmployee(Employee _employee);
        void AddProject(Project _project);
        void AddOverwork(Overwork _overwork);
        void AddPayment(Payment _payment);
        void AddCompensatoryHoliday(CompensatoryHoliday _compensatoryHoliday);

        List<Overwork> GetOwerworksByEmployee(Employee _employee);
        List<Payment> GetPaymentsByEmployee(Employee _employee);
        List<CompensatoryHoliday> GetCompensatoryHolidaysByEmployee(Employee _employee);
    }
}
