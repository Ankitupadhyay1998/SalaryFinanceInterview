using SalaryFinanceInterview.Api.Models.Employees;

namespace SalaryFinanceInterview.Api.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly List<Employee> _employees =
        [
            new Employee
        {
            Id = 1,
            EmployeeCode = "EMP-100",
            FullName = "Ankit Upadhyay",
            MonthlySalary = 70000
        }
        ];

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee Create(Employee employee)
        {
            _employees.Add(employee);

            return employee;
        }

        public Employee? Update(int id, Employee employee)
        {
            var existing = _employees.FirstOrDefault(x => x.Id == id);

            if (existing is null)
            {
                return null;
            }

            existing.FullName = employee.FullName;
            existing.MonthlySalary = employee.MonthlySalary;
            existing.EmployeeCode = employee.EmployeeCode;
            existing.Address = employee.Address;

            return existing;
        }

        public bool Delete(int id)
        {
            var existing = _employees.FirstOrDefault(x => x.Id == id);

            if (existing is null)
            {
                return false;
            }

            _employees.Remove(existing);

            return true;
        }
    }
}