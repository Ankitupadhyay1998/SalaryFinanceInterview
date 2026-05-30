using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalaryFinanceInterview.ApiClient;
using SalaryFinanceInterview.ApiClient.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSalaryFinanceApi("https://localhost:7147");

var host = builder.Build();

var apiClient = host.Services.GetRequiredService<ISalaryFinanceApiClient>();

try
{
    Console.WriteLine("========================================");
    Console.WriteLine("SALARY FINANCE SDK CONSUMPTION DEMO");
    Console.WriteLine("========================================");

    // =========================================================
    // EMPLOYEES
    // =========================================================

    Console.WriteLine("\nFetching all employees...\n");

    var employees = await apiClient.EmployeesAllAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine($"Employee Id: {employee.Id}");
        Console.WriteLine($"Employee Name: {employee.FullName}");
        Console.WriteLine($"Employee Salary: {employee.MonthlySalary}");
        Console.WriteLine("----------------------------------");
    }

    Console.WriteLine("\nCreating new employee...\n");

    var createdEmployee = await apiClient.EmployeesPOSTAsync(
        new Employee
        {
            Id = 1001,
            FullName = "Ankit Upadhyay",
            MonthlySalary= 85000
        });

    Console.WriteLine($"Created Employee: {createdEmployee.FullName}");

    Console.WriteLine("\nFetching employee by id...\n");

    var employeeById = await apiClient.EmployeesGETAsync(1);

    Console.WriteLine($"Employee Found: {employeeById.FullName}");

    Console.WriteLine("\nUpdating employee...\n");

    var updatedEmployee = await apiClient.EmployeesPUTAsync(
        1,
        new Employee
        {
            Id = 1,
            FullName = "Updated Employee",
            MonthlySalary = 95000
        });

    Console.WriteLine($"Updated Employee: {updatedEmployee.FullName}");

    Console.WriteLine("\nDeleting employee...\n");

    await apiClient.EmployeesDELETEAsync(2);

    Console.WriteLine("Employee deleted successfully.");

    // =========================================================
    // LOAN APPLICATIONS
    // =========================================================

    Console.WriteLine("\nFetching loan applications...\n");

    var loanApplications = await apiClient.LoanApplicationsAllAsync();

    foreach (var loan in loanApplications)
    {
        Console.WriteLine($"Loan Id: {loan.Id}");
        Console.WriteLine($"Loan Amount: {loan.RequestedAmount}");
        Console.WriteLine("----------------------------------");
    }

    Console.WriteLine("\nCreating loan application...\n");

    var createdLoan = await apiClient.LoanApplicationsPOSTAsync(
        new LoanApplication
        {
            Id = 500,
            RequestedAmount = 250000
        });

    Console.WriteLine($"Created Loan Id: {createdLoan.Id}");

    Console.WriteLine("\nFetching loan by id...\n");

    var loanById = await apiClient.LoanApplicationsGETAsync(1);

    Console.WriteLine($"Loan Amount: {loanById.RequestedAmount}");

    Console.WriteLine("\nUpdating loan...\n");

    var updatedLoan = await apiClient.LoanApplicationsPUTAsync(
        1,
        new LoanApplication
        {
            Id = 1,
            RequestedAmount = 450000
        });

    Console.WriteLine($"Updated Loan Amount: {updatedLoan.RequestedAmount}");

    Console.WriteLine("\nDeleting loan...\n");

    await apiClient.LoanApplicationsDELETEAsync(2);

    Console.WriteLine("Loan deleted successfully.");

    // =========================================================
    // SALARY ADVANCES
    // =========================================================

    Console.WriteLine("\nFetching salary advances...\n");

    var advances = await apiClient.SalaryAdvancesAllAsync();

    foreach (var advance in advances)
    {
        Console.WriteLine($"Advance Id: {advance.Id}");
        Console.WriteLine($"Advance Amount: {advance.RequestedDate}");
        Console.WriteLine("----------------------------------");
    }

    Console.WriteLine("\nCreating salary advance...\n");

    var createdAdvance = await apiClient.SalaryAdvancesPOSTAsync(
        new SalaryAdvance
        {
            Id = 200,
            AdvanceAmount = 15000
        });

    Console.WriteLine($"Created Advance Id: {createdAdvance.Id}");

    Console.WriteLine("\nFetching advance by id...\n");

    var advanceById = await apiClient.SalaryAdvancesGETAsync(1);

    Console.WriteLine($"Advance Amount: {advanceById.RequestedDate}");

    Console.WriteLine("\nDeleting salary advance...\n");

    await apiClient.SalaryAdvancesDELETEAsync(2);

    Console.WriteLine("Salary advance deleted successfully.");

    // =========================================================
    // MINIMAL APIs
    // =========================================================

    Console.WriteLine("\nCalling Health endpoint...\n");

    await apiClient.HealthAsync();

    Console.WriteLine("Health endpoint success.");

    Console.WriteLine("\nCalling Eligibility endpoint...\n");

    await apiClient.EligibilityAsync(1);

    Console.WriteLine("Eligibility endpoint success.");

    Console.WriteLine("\nFetching weather forecast...\n");

    var forecasts = await apiClient.GetWeatherForecastAsync();

    foreach (var forecast in forecasts)
    {
        Console.WriteLine($"Date: {forecast.Date}");
        Console.WriteLine($"Temperature: {forecast.TemperatureC}");
        Console.WriteLine($"Summary: {forecast.Summary}");
        Console.WriteLine("----------------------------------");
    }

    Console.WriteLine("\n========================================");
    Console.WriteLine("ALL SDK OPERATIONS COMPLETED");
    Console.WriteLine("========================================");
}
catch (ApiException ex)
{
    Console.WriteLine("\nAPI Exception Occurred");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    Console.WriteLine($"Response: {ex.Response}");
}
catch (Exception ex)
{
    Console.WriteLine("\nUnhandled Exception");
    Console.WriteLine(ex.Message);
}