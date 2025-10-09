using DotnetTask2_WEBAPI1_Collection.Models;

namespace DotnetTask2_WEBAPI1_Collection.Repository
{
    public class EmployeeDbRepository : IEmployeeRepository
    {


        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeDbRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public void Add(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _employeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _employeeDbContext.Remove(employee);
                _employeeDbContext.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public IEnumerable<Employee> GetByDepartment(string department)
        {
            if (string.IsNullOrEmpty(department))
            {
                throw new ArgumentNullException(nameof(department));
            }
            return _employeeDbContext.Employees
                .Where(e => e.Department == department)
                .ToList();
        }

        public Employee GetById(int id)
        {
            return _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _employeeDbContext.Employees.Update(employee);
            _employeeDbContext.SaveChanges();
        }

        public void UpdateEmail(int id, string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail))
            {
                throw new ArgumentNullException(nameof(newEmail));
            }

            var employee = _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Email = newEmail;
                _employeeDbContext.SaveChanges();
            }
        }
    }
}
