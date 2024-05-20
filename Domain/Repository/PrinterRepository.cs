using Domain.Interfaces;
using Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository;

public class PrinterRepository : IPrinterRepository
{
    private readonly ApplicationContext _context;

    public PrinterRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Printer>> GetAllAsync()
    {
        return await _context.Printers.Include(p => p!.PrintType).ToListAsync();
    }

    public async Task<Printer?> GetByIdAsync(int id)
    {
        return await _context.Printers.Include(p => p.PrintType).SingleOrDefaultAsync(p => p!.Id == id);
    }

    public async Task AddAsync(Printer? printer)
    {
        _context.Printers.Add(printer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Printer? printer)
    {
        _context.Printers.Update(printer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var printer = await _context.Printers.FindAsync(id);
        if (printer != null)
        {
            _context.Printers.Remove(printer);
            await _context.SaveChangesAsync();
        }
    }
}