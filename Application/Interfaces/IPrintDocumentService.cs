using Shared.Models;

namespace Application.Interfaces;

public interface IPrintDocumentService
{
    Task<IEnumerable<PrintDocument>> GetAllAsync();
    Task<PrintDocument?> GetByIdAsync(int id);
    Task AddAsync(PrintDocument printDocument);
    Task UpdateAsync(int id, PrintDocument printDocument);
    Task DeleteAsync(int id);
}