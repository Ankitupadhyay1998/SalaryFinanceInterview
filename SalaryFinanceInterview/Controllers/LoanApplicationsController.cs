using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.Api.Models.LoanApplications;
using SalaryFinanceInterview.Api.Repositories.LoanApplications;

namespace SalaryFinanceInterview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly ILoanApplicationRepository _repository;

        public LoanApplicationsController(
            ILoanApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<LoanApplication>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<LoanApplication> GetById(int id)
        {
            var item = _repository.GetById(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<LoanApplication> Create(
            LoanApplication application)
        {
            return Ok(_repository.Create(application));
        }

        [HttpPut("{id}")]
        public ActionResult<LoanApplication> Update(
            int id,
            LoanApplication application)
        {
            var updated = _repository.Update(id, application);

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

            return NoContent();
        }
    }
}
