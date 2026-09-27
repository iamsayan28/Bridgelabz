using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await _context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id)
            => await _context.Employees.FindAsync(id);

        public async Task<bool> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}