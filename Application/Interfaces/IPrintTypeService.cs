using Shared.Models;

namespace Application.Interfaces;

public interface IPrintTypeService
{
    Task<IEnumerable<PrintType?>> GetAllAsync();
    Task<PrintType?> GetByIdAsync(int id);
    Task AddAsync(PrintType printType);
    Task UpdateAsync(int id, PrintType printType);
    Task DeleteAsync(int id);
}