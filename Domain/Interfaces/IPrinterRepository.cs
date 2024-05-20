using Shared.Models;

namespace Domain.Interfaces;

public interface IPrinterRepository
{
    Task<IEnumerable<Printer>> GetAllAsync();
    Task<Printer?> GetByIdAsync(int id);
    Task AddAsync(Printer? printer);
    Task UpdateAsync(Printer? printer);
    Task DeleteAsync(int id);
}