using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.Api.Models.SalaryAdvances;
using SalaryFinanceInterview.Api.Repositories.SalaryAdvances;

namespace SalaryFinanceInterview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryAdvancesController : ControllerBase
    {
        private readonly ISalaryAdvanceRepository _repository;

        public SalaryAdvancesController(
            ISalaryAdvanceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<SalaryAdvance>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<SalaryAdvance> GetById(int id)
        {
            var item = _repository.GetById(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<SalaryAdvance> Create(
            SalaryAdvance advance)
        {
            return Ok(_repository.Create(advance));
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
