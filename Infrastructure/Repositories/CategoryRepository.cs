using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Models;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SlgDbContext _context;

        public CategoryRepository(SlgDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            //Save the Category to the database or throw an exception if the Category not saved
            var createdCategory = await _context.Categories.AddAsync(category);
            if (createdCategory == null)
            {
                throw new CategoryException("Category not saved");
            }
            await _context.SaveChangesAsync();
            return createdCategory.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new CategoryException("Category not found");
            }
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await Task.FromResult(_context.Categories.ToList());
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var categoryFound = await _context.Categories.FindAsync(id);
            if (categoryFound == null)
            {
                throw new CategoryException($"Category not found by ID: {id}");
            }
            return categoryFound;
        }

        public async Task<int> UpdateAsync(int id, Category category)
        {
            var categoryFound = await _context.Categories.FindAsync(id);
            if (categoryFound == null)
            {
                throw new CategoryException($"Category not found by ID: {id}");
            }
            categoryFound.Name = category.Name;
            categoryFound.Description = category.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
