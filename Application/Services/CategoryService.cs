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
            return _categoryMapper.ToResponse(result);
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryRes>> GetAllAsync()
        {
            return (await _categoryRepository.GetAllAsync()).Select(_categoryMapper.ToResponse).ToList();
        }

        public async Task<CategoryRes> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new CategoryException("Category id is required");
            }
            var result = await _categoryRepository.GetByIdAsync(id);
            return _categoryMapper.ToResponse(result);
        }

        public Task<int> UpdateAsync(int id, CategoryReq category)
        {
            throw new NotImplementedException();
        }
    }
}
