using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalaryFinanceInterview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        // =========================================================
        // NORMAL PUBLIC ENDPOINT
        // =========================================================

        /// <summary>
        /// Public endpoint visible in Swagger/OpenAPI
        /// </summary>
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(new
            {
                Message = "Visible in Swagger and SDK generation"
            });
        }

        // =========================================================
        // HIDDEN FROM SWAGGER BUT STILL CALLABLE
        // =========================================================

        /// <summary>
        /// Internal endpoint hidden from Swagger
        /// but still accessible via HTTP
        /// </summary>
        [HttpGet("internal")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult InternalEndpoint()
        {
            return Ok(new
            {
                Message = "Hidden from Swagger but endpoint still works"
            });
        }

        // =========================================================
        // NOT AN API ENDPOINT AT ALL
        // =========================================================

        [NonAction]
        public string InternalCalculation()
        {
            return "This is helper method";
        }
    }
}
