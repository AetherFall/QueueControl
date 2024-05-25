using Domain.Interfaces;
using Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository;

public class PrintQueueRepository : IPrintQueueRepository
{
    private readonly ApplicationContext _context;

    public PrintQueueRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<PrintQueue?>> GetAllAsync()
    {
        return await _context.PrintQueues
            .Include(pq => pq!.Document)
            .Include(pq => pq!.Printer)
            .ToListAsync();
    }

    public async Task<PrintQueue?> GetByIdAsync(int id)
    {
        return await _context.PrintQueues
            .Include(pq => pq!.Document)
            .Include(pq => pq!.Printer)
            .SingleOrDefaultAsync(pq => pq.Id == id);
    }

    public async Task AddAsync(PrintQueue? printQueue)
    {
        _context.PrintQueues.Add(printQueue);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PrintQueue? printQueue)
    {
        _context.PrintQueues.Update(printQueue);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var printQueue = await _context.PrintQueues.FindAsync(id);
        if (printQueue != null)
        {
            _context.PrintQueues.Remove(printQueue);
            await _context.SaveChangesAsync();
        }
    }
}