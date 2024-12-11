using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryRes>> GetAllAsync();
        Task<CategoryRes> GetByIdAsync(int id);
        Task<CategoryRes> CreateAsync(CategoryReq category);
        Task<int> UpdateAsync(int id, CategoryReq category);
        Task<int> DeleteAsync(int id);
    }
}
