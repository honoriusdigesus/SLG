using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly SlgDbContext _context;

        public EmployeeRepository(SlgDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public Task<int> UpdateAsync(int id, Employee employee)
        {
            var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employeeToUpdate != null) {
                employeeToUpdate.Document = employee.Document;
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Lastname = employee.Lastname;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.Password = employee.Password;
                employeeToUpdate.Role = employee.Role;
                employeeToUpdate.Phone = employee.Phone;
                employeeToUpdate.ZoneId = employee.ZoneId;
                _context.Employees.Update(employeeToUpdate);
            }
            return _context.SaveChangesAsync();
        }
    }
}
