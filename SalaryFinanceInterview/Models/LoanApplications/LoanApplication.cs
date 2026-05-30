namespace SalaryFinanceInterview.Api.Models.LoanApplications
{
    public class LoanApplication
    {
        public int Id { get; set; } = 5000;

        public int EmployeeId { get; set; }

        public decimal RequestedAmount { get; set; } = 100000;

        public int TenureInMonths { get; set; } = 12;

        public string Status { get; set; } = "Pending";
    }
}
