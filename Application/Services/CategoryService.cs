using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions.Types;
using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryMapper _categoryMapper;

        public CategoryService(ICategoryRepository categoryRepository, CategoryMapper categoryMapper)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;
        }
        public async Task<CategoryRes> CreateAsync(CategoryReq category)
        {
            if (category == null || category.Name.Equals("")) {
                throw new CategoryException("Category name is required");
            }
            var categoryEntity = _categoryMapper.ToCategory(category);
            var result = await _categoryRepository.CreateAsync(categoryEntity);
            return _categoryMapper.ToCategoryRes(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryRes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryRes> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, CategoryReq category)
        {
            throw new NotImplementedException();
        }
    }
}
