using Employee.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Services
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Entities.Employee employee);
        Task<Entities.Employee?> GetEmployeeAsync(int empId);
        Task<IEnumerable<Entities.Employee>> GetEmployeesAsync();
        Task UpdateEmployeeAsync(Entities.Employee employee);
        Task DeleteEmployeeAsync(int empId);
        Task<bool> SaveChangesAsync();
    }
}