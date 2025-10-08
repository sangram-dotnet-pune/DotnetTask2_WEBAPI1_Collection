using DotnetTask2_WEBAPI1_Collection.Models;

namespace DotnetTask2_WEBAPI1_Collection.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetByDepartment(string department);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void UpdateEmail(int id, string newEmail);
    }
}
