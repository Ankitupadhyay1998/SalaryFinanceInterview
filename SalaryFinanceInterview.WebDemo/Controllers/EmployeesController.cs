using Microsoft.AspNetCore.Mvc;
using SalaryFinanceInterview.ApiClient;

namespace SalaryFinanceInterview.WebDemo.Controllers;

public class EmployeesController : Controller
{
    private readonly ISalaryFinanceApiClient _apiClient;

    public EmployeesController(ISalaryFinanceApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _apiClient.EmployeesAllAsync();

        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        try
        {
            await _apiClient.EmployeesPOSTAsync(employee);

            TempData["Success"] = "Employee created successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (ApiException ex)
        {
            ViewBag.Error = ex.Response;

            return View(employee);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _apiClient.EmployeesGETAsync(id);

        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        try
        {
            await _apiClient.EmployeesPUTAsync(id, employee);

            TempData["Success"] = "Employee updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (ApiException ex)
        {
            ViewBag.Error = ex.Response;

            return View(employee);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _apiClient.EmployeesDELETEAsync(id);

        return RedirectToAction(nameof(Index));
    }
}