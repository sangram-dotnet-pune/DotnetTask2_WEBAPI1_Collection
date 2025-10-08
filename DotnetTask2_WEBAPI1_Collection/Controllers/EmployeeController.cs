using DotnetTask2_WEBAPI1_Collection.Repository;
using DotnetTask2_WEBAPI1_Collection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotnetTask2_WEBAPI1_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

     
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetById(id);
            if (emp == null)
                return NotFound($"Employee with ID {id} not found.");
            return Ok(emp);
        }

        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var empList = _employeeRepository.GetAll();
            return Ok(empList);
        }

      
        [HttpGet("department/{dept}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDept(string dept)
        {
            var empList = _employeeRepository.GetByDepartment(dept);
            if ( empList == null)
                return NotFound($"No employees found in {dept} department.");
            return Ok(empList);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _employeeRepository.Add(employee);
            return Ok(employee.Name + " Employee Added ");
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("Employee ID mismatch");

            var existing = _employeeRepository.GetById(id);
            if (existing == null)
                return NotFound($"Employee with ID {id} not found.");

            _employeeRepository.Update(employee);
            return Ok(employee);
        }

        // PATCH: api/employee/{id}/email
        [HttpPatch("{id}/email")]
        public ActionResult UpdateEmployeeEmail(int id, [FromBody] string newEmail)
        {
            var existing = _employeeRepository.GetById(id);
            if (existing == null)
                return NotFound($"Employee with ID {id} not found.");

            _employeeRepository.UpdateEmail(id, newEmail);
            return Ok($"Email updated for Employee ID {id}");
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var existing = _employeeRepository.GetById(id);
            if (existing == null)
                return NotFound($"Employee with ID {id} not found.");

            _employeeRepository.Delete(id);
            return Ok($"Employee with ID {id} deleted successfully.");
        }

        [HttpOptions]
        public ActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,PUT,PATCH,DELETE,OPTIONS");
            return Ok();
        }




    }
}
