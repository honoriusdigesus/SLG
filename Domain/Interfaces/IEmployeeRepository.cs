using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<int> UpdateAsync(int id, Employee employee);
        Task<int> DeleteAsync(int id);
        Task<Employee> GetEmployeeByDocumentAndPassword(string document, string password);
    }
}
