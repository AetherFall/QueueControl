using Shared.Models;

namespace Domain.Interfaces;

public interface IPrintTypeRepository
{
    Task<IEnumerable<PrintType?>> GetAllAsync();
    Task<PrintType?> GetByIdAsync(int id);
    Task AddAsync(PrintType? printType);
    Task UpdateAsync(PrintType? printType);
    Task DeleteAsync(int id);
}