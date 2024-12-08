using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeRes>> GetAllAsync();
        Task<EmployeeRes> GetByIdAsync(int id);
        Task<EmployeeRes> CreateAsync(EmployeeReq employee);
        Task<int> UpdateAsync(int id, EmployeeReq employee);
        Task<int> DeleteAsync(int id);
    }
}
