using Shared.Models;

namespace Domain.Interfaces;

public interface IPrintQueueRepository
{
    Task<List<PrintQueue?>> GetAllAsync();
    Task<PrintQueue?> GetByIdAsync(int id);
    Task AddAsync(PrintQueue? printQueue);
    Task UpdateAsync(PrintQueue? printQueue);
    Task DeleteAsync(int id);
}