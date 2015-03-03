using AccountingOfOverwork.Domain;

namespace AccountingOfOverwork
{
    public class DemoDataGenerator
    {
        private readonly IRepository<Position> positionsRepository;
        private readonly IRepository<Employee> employeesRepository;

        public DemoDataGenerator(IRepository<Position> positionsRepository, IRepository<Employee> employeesRepository)
        {
            this.positionsRepository = positionsRepository;
            this.employeesRepository = employeesRepository;
        }

        public void Generate()
        {
            employeesRepository.Add(new Employee("Ivan", new Position("Programmer", 200), "first",
                "Moscow st., 237-24", "2000 123456"));
            employeesRepository.Add(new Employee("Petr", new Position("Junior Programmer", 120), "first",
                "Moscow st., 136-18", "2000 654321"));
            //TestData.AddProject(new Project(1, "Project X", "Win", new DateTime(2015, 1, 10)));
            //TestData.AddOverwork(new Overwork(1, TestData.GetEmployee(1), TestData.GetProject(1),
            //    new DateTime(2015, 1, 14), 4.0, new CompensatoryRule(1, "first", 2.0, 1.0)));
            //TestData.AddOverwork(new Overwork(2, TestData.GetEmployee(1), TestData.GetProject(1),
            //    new DateTime(2015, 1, 18), 3.0, new CompensatoryRule(2, "second", 2.2, 1.0)));
            //TestData.AddPayment(new Payment(1, TestData.GetEmployee(1), new DateTime(2015, 1, 24), 2500.0));
            //TestData.AddCompensatoryHoliday(new CompensatoryHoliday(1, TestData.GetEmployee(1), new DateTime(2015, 1, 22), 4.0));
        }
    }
}