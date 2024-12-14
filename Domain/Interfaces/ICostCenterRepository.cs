using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICostCenterRepository
    {
        Task<List<Costcenter>> GetAllAsync();
        Task<Costcenter> GetByIdAsync(int id);
        Task<Costcenter> CreateAsync(Costcenter costcenter);
        Task<int> UpdateAsync(int id, Costcenter costcenter);
        Task<int> DeleteAsync(int id);
    }
}
