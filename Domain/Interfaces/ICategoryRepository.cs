using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<int> UpdateAsync(int id, Category category);
        Task<int> DeleteAsync(int id);
    }
}
