using SalaryFinanceInterview.Api.Models.Employees;

namespace SalaryFinanceInterview.Api.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee? GetById(int id);

        Employee Create(Employee employee);

        Employee? Update(int id, Employee employee);

        bool Delete(int id);
    }
}
