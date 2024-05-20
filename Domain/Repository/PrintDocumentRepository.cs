using Domain.Interfaces;
using Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository;

public class PrintDocumentRepository : IPrintDocumentRepository
{
    private readonly ApplicationContext _context;

    public PrintDocumentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PrintDocument>> GetAllAsync()
    {
        return await _context.PrintDocuments.Include(pd => pd.PrintType).ToListAsync();
    }

    public async Task<PrintDocument?> GetByIdAsync(int id)
    {
        return await _context.PrintDocuments.Include(pd => pd.PrintType).SingleOrDefaultAsync(pd => pd!.Id == id);
    }

    public async Task AddAsync(PrintDocument? printDocument)
    {
        _context.PrintDocuments.Add(printDocument);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PrintDocument? printDocument)
    {
        _context.PrintDocuments.Update(printDocument);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var printDocument = await _context.PrintDocuments.FindAsync(id);
        if (printDocument != null)
        {
            _context.PrintDocuments.Remove(printDocument);
            await _context.SaveChangesAsync();
        }
    }
}