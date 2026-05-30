using SalaryFinanceInterview.Api.Models.LoanApplications;

namespace SalaryFinanceInterview.Api.Repositories.LoanApplications
{
    public interface ILoanApplicationRepository
    {
        List<LoanApplication> GetAll();

        LoanApplication? GetById(int id);

        LoanApplication Create(LoanApplication application);

        LoanApplication? Update(int id, LoanApplication application);

        bool Delete(int id);
    }
}
