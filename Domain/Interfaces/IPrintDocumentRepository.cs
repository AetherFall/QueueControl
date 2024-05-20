using Shared.Models;

namespace Domain.Interfaces;

public interface IPrintDocumentRepository
{
    Task<IEnumerable<PrintDocument>> GetAllAsync();
    Task<PrintDocument?> GetByIdAsync(int id);
    Task AddAsync(PrintDocument? printDocument);
    Task UpdateAsync(PrintDocument? printDocument);
    Task DeleteAsync(int id);
}