using SalaryFinanceInterview.Api.Models.LoanApplications;

namespace SalaryFinanceInterview.Api.Repositories.LoanApplications
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private static readonly List<LoanApplication> _applications =
        [
            new LoanApplication
        {
            Id = 1,
            EmployeeId = 1,
            RequestedAmount = 100000,
            Status = "Pending"
        }
        ];

        public List<LoanApplication> GetAll()
        {
            return _applications;
        }

        public LoanApplication? GetById(int id)
        {
            return _applications.FirstOrDefault(x => x.Id == id);
        }

        public LoanApplication Create(LoanApplication application)
        {
            _applications.Add(application);

            return application;
        }

        public LoanApplication? Update(int id, LoanApplication application)
        {
            var existing = _applications.FirstOrDefault(x => x.Id == id);

            if (existing is null)
            {
                return null;
            }

            existing.RequestedAmount = application.RequestedAmount;
            existing.TenureInMonths = application.TenureInMonths;
            existing.Status = application.Status;

            return existing;
        }

        public bool Delete(int id)
        {
            var existing = _applications.FirstOrDefault(x => x.Id == id);

            if (existing is null)
            {
                return false;
            }

            _applications.Remove(existing);

            return true;
        }
    }
}
