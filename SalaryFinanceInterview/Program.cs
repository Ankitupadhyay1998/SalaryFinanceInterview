// ===============================
// FILE: Program.cs
// ===============================

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using SalaryFinanceInterview.Api.Repositories.Employees;
using SalaryFinanceInterview.Api.Repositories.LoanApplications;
using SalaryFinanceInterview.Api.Repositories.SalaryAdvances;
using SalaryFinanceInterview.Api.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolverChain.Insert(
            0,
            ApiJsonContext.Default);
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile =
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath =
        Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddProblemDetails();

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddSingleton<
    ILoanApplicationRepository,
    LoanApplicationRepository>();

builder.Services.AddSingleton<
    ISalaryAdvanceRepository,
    SalaryAdvanceRepository>();

var app = builder.Build();

app.UseExceptionHandler();

app.UseSwagger();

app.UseSwaggerUI();

try
{
    app.MapControllers();
}
catch (ReflectionTypeLoadException ex)
{
    foreach (var loaderException in ex.LoaderExceptions)
    {
        Console.WriteLine(loaderException.Message);
    }

    throw;
}

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Time = DateTime.UtcNow
    });
});

app.MapGet("/eligibility/{employeeId}", (
    int employeeId) =>
{
    return Results.Ok(new
    {
        EmployeeId = employeeId,
        Eligible = true,
        MaxAmount = 50000
    });
});

app.MapGet("/internal", () =>
{
    return Results.Ok();
})
.ExcludeFromDescription();
app.Run();













//using Scalar.AspNetCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwaggerUI(options =>
//    {
//        // Point Swagger UI to the native .NET 9 JSON endpoint
//        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
//    });
//    app.MapScalarApiReference();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
