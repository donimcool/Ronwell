using Employee.API.DbContexts;
using Employee.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Where(c => !c.IsDeleted).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Entities.Employee?> GetEmployeeAsync(int empId)
        {
            return await _context.Employees
                .Where(c => c.Id == empId && !c.IsDeleted).FirstOrDefaultAsync();
        }
        public async Task AddEmployeeAsync(Entities.Employee employee)
        {
            if (employee == null || employee.IsDeleted)
                throw new ArgumentNullException(nameof(Entities.Employee));

             await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEmployeeAsync(Entities.Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employee.Id);

            if (existingEmployee == null || existingEmployee.IsDeleted)
                throw new ArgumentNullException(nameof(Entities.Employee));

            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int empId)
        {
            var existingEmployee = await _context.Employees.FindAsync(empId);
            if (existingEmployee == null)
                throw new ArgumentNullException(nameof(Entities.Employee));
            existingEmployee.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
