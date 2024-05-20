using Shared.Models;

namespace Application.Interfaces;

public interface IPrinterService
{
    Task<IEnumerable<Printer>> GetAllAsync();
    Task<Printer?> GetByIdAsync(int id);
    Task AddAsync(Printer printer);
    Task UpdateAsync(int id, Printer printer);
    Task DeleteAsync(int id);
}