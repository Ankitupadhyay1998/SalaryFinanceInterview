using SalaryFinanceInterview.Api.Models.SalaryAdvances;

namespace SalaryFinanceInterview.Api.Repositories.SalaryAdvances
{
    public class SalaryAdvanceRepository : ISalaryAdvanceRepository
    {
        private static readonly List<SalaryAdvance> _advances =
        [
            new SalaryAdvance
        {
            Id = 1,
            EmployeeId = 1,
            AdvanceAmount = 25000
        }
        ];

        public List<SalaryAdvance> GetAll()
        {
            return _advances;
        }

        public SalaryAdvance? GetById(int id)
        {
            return _advances.FirstOrDefault(x => x.Id == id);
        }

        public SalaryAdvance Create(SalaryAdvance advance)
        {
            _advances.Add(advance);

            return advance;
        }

        public bool Delete(int id)
        {
            var existing = _advances.FirstOrDefault(x => x.Id == id);

            if (existing is null)
            {
                return false;
            }

            _advances.Remove(existing);

            return true;
        }
    }
}
