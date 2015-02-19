using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public static class DataManagement
    {
        public static List<Employee> employes = new List<Employee>();
        public static List<Project> projects = new List<Project>();
        public static List<Overwork> overworks = new List<Overwork>();
        public static List<Payment> payments = new List<Payment>();
        public static List<CompensatoryHoliday> compensatoryHolidays = new List<CompensatoryHoliday>();
    }
}
