using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.ApiClient;

namespace SalaryFinanceInterview.WebDemo.Controllers;

public class SalaryAdvancesController : Controller
{
    private readonly ISalaryFinanceApiClient _apiClient;

    public SalaryAdvancesController(
        ISalaryFinanceApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        var advances =
            await _apiClient.SalaryAdvancesAllAsync();

        return View(advances);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        SalaryAdvance advance)
    {
        await _apiClient.SalaryAdvancesPOSTAsync(advance);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _apiClient.SalaryAdvancesDELETEAsync(id);

        return RedirectToAction(nameof(Index));
    }
}