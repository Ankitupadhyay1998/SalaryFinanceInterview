using SalaryFinanceInterview.Api.Models.Employees;
using SalaryFinanceInterview.Api.Models.LoanApplications;
using SalaryFinanceInterview.Api.Models.SalaryAdvances;
using System.Text.Json.Serialization;

namespace SalaryFinanceInterview.Api.Serialization
{
    [JsonSerializable(typeof(Employee))]
    [JsonSerializable(typeof(List<Employee>))]
    [JsonSerializable(typeof(LoanApplication))]
    [JsonSerializable(typeof(List<LoanApplication>))]
    [JsonSerializable(typeof(SalaryAdvance))]
    [JsonSerializable(typeof(List<SalaryAdvance>))]
    public partial class ApiJsonContext : JsonSerializerContext
    {
    }
}
