using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.Api.Models.Employees;
using SalaryFinanceInterview.Api.Repositories.Employees;

namespace SalaryFinanceInterview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(
            IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var employee = _repository.GetById(id);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            var created = _repository.Create(employee);

            return Ok(created);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Update(
            int id,
            Employee employee)
        {
            var updated = _repository.Update(id, employee);

            if (updated is null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _repository.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
