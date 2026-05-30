using SalaryFinanceInterview.Api.Models.Common;

namespace SalaryFinanceInterview.Api.Models.Employees
{
    public class Employee
    {
        public int Id { get; set; } = 1000;

        public string EmployeeCode { get; set; } = "EMP-001";

        public string FullName { get; set; } = "Ankit Upadhyay";

        public decimal MonthlySalary { get; set; } = 70000;

        public Address Address { get; set; } = new();

        public GenericModel<string> Metadata { get; set; } = new();
    }
}
