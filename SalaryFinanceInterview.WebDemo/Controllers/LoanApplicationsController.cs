using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.ApiClient;

namespace SalaryFinanceInterview.WebDemo.Controllers;

public class LoanApplicationsController : Controller
{
    private readonly ISalaryFinanceApiClient _apiClient;

    public LoanApplicationsController(
        ISalaryFinanceApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        var loans = await _apiClient.LoanApplicationsAllAsync();

        return View(loans);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        LoanApplication loan)
    {
        await _apiClient.LoanApplicationsPOSTAsync(loan);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var loan =
            await _apiClient.LoanApplicationsGETAsync(id);

        return View(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(
        int id,
        LoanApplication loan)
    {
        await _apiClient.LoanApplicationsPUTAsync(id, loan);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _apiClient.LoanApplicationsDELETEAsync(id);

        return RedirectToAction(nameof(Index));
    }
}