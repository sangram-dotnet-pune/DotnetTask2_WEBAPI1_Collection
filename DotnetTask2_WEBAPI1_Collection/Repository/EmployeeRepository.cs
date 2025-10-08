using DotnetTask2_WEBAPI1_Collection.Models;

namespace DotnetTask2_WEBAPI1_Collection.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private static  List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sangram", Department = "IT", MobileNo = "9876543210", Email = "sangram@example.com" },
            new Employee { Id = 2, Name = "Rohan", Department = "HR", MobileNo = "9998887776", Email = "rohan@example.com" }
        };
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(x => x.Id == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
           return _employees.ToList();
        }

        public IEnumerable<Employee> GetByDepartment(string department)
        {
           var Employees=_employees.Where(x=>x.Department == department).ToList();

            return Employees;
        }

        public Employee GetById(int id)
        {
            var emp = _employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }

            return null;

        }

        public void Update(Employee employee)
        {
            var emp = _employees.FirstOrDefault(x => x.Id == employee.Id);

            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
                emp.MobileNo = employee.MobileNo;
               

            }
        }

        public void UpdateEmail(int id, string newEmail)
        {
            var emp = _employees.FirstOrDefault(x => x.Id == id);
            if (emp != null) {
                 emp.Email = newEmail;
            }
        }
    }
}
