﻿using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
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
            //Save the Employee to the database or throw an exception if the Employee not saved
            var createdEmployee = await _context.Employees.AddAsync(employee);
            if (createdEmployee == null)
            {
                throw new EmployeeException("Employee not saved");
            }
            await _context.SaveChangesAsync();
            return createdEmployee.Entity;

        }

        public async Task<int> DeleteAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                throw new EmployeeException("Employee not found");
            }
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByDocumentAndPassword(string document, string password)
        {
            if (document.Equals("") || password.Equals(""))
            {
                throw new EmployeeException("Incorrect employee document or password, please verify.");
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Document == document && x.Password == password);
            if (employee == null)
            {
                throw new EmployeeException("Employee not found, please verify your information.");
            }
            return employee;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                throw new EmployeeException("Employee not found");
            }
            return employee;
        }

        public Task<int> UpdateAsync(int id, Employee employee)
        {
            var employeeToUpdate = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (employeeToUpdate == null) {
                throw new EmployeeException("Employee not found");
            }
            employeeToUpdate.Document = employee.Document;
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Lastname = employee.Lastname;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Password = employee.Password;
            employeeToUpdate.Role = employee.Role;
            employeeToUpdate.Phone = employee.Phone;
            employeeToUpdate.ZoneId = employee.ZoneId;
            _context.Employees.Update(employeeToUpdate);
            return _context.SaveChangesAsync();
        }
    }
}
