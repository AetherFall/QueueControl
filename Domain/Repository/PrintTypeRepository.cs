using Domain.Interfaces;
using Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository;

public class PrintTypeRepository : IPrintTypeRepository
{
    private readonly ApplicationContext _context;

    public PrintTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PrintType?>> GetAllAsync()
    {
        return await _context.PrintTypes.ToListAsync();
    }

    public async Task<PrintType?> GetByIdAsync(int id)
    {
        return await _context.PrintTypes.SingleOrDefaultAsync(pt => pt!.Id == id);
    }

    public async Task AddAsync(PrintType? printType)
    {
        _context.PrintTypes.Add(printType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PrintType? printType)
    {
        _context.PrintTypes.Update(printType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var printType = await _context.PrintTypes.FindAsync(id);
        if (printType != null)
        {
            _context.PrintTypes.Remove(printType);
            await _context.SaveChangesAsync();
        }
    }
}