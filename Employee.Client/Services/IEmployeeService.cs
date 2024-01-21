using Employee.Common.Models;

namespace Employee.Client.Services
{
    public interface IEmployeeService
    {
        Task DeleteEmployee(int id);
        Task<EmployeeDto?> GetEmployee(int id);
        Task<List<EmployeeDto>?> GetEmployees();
        Task PostEmployee(EmployeeDto employee);
    }
}