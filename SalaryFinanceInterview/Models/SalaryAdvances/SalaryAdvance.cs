namespace SalaryFinanceInterview.Api.Models.SalaryAdvances
{
    public class SalaryAdvance
    {
        public int Id { get; set; } = 9000;

        public int EmployeeId { get; set; }

        public decimal AdvanceAmount { get; set; } = 25000;

        public DateTime RequestedDate { get; set; }
            = DateTime.UtcNow;
    }
}
