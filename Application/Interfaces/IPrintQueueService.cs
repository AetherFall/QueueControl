using Shared.Models;

namespace Application.Interfaces;

public interface IPrintQueueService
{
    Task<List<PrintQueue?>> GetAllAsync();
    Task<PrintQueue?> GetByIdAsync(int id);
    Task AddAsync(PrintQueue printQueue);
    Task UpdateAsync(int id, PrintQueue printQueue);
    Task DeleteAsync(int id);
}