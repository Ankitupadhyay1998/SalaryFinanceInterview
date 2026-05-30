using SalaryFinanceInterview.Api.Models.SalaryAdvances;

namespace SalaryFinanceInterview.Api.Repositories.SalaryAdvances
{
    public interface ISalaryAdvanceRepository
    {
        List<SalaryAdvance> GetAll();

        SalaryAdvance? GetById(int id);

        SalaryAdvance Create(SalaryAdvance advance);

        bool Delete(int id);
    }
}
