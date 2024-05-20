using Application.Interfaces;
using Domain.Interfaces;
using Shared.Models;

namespace Application.Services;

public class PrintQueueService : IPrintQueueService
{
    private readonly IPrintQueueRepository _printQueueRepository;

    public PrintQueueService(IPrintQueueRepository printQueueRepository)
    {
        _printQueueRepository = printQueueRepository;
    }

    public async Task<List<PrintQueue?>> GetAllAsync()
    {
        return await _printQueueRepository.GetAllAsync();
    }

    public async Task<PrintQueue?> GetByIdAsync(int id)
    {
        return await _printQueueRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(PrintQueue printQueue)
    {
        await _printQueueRepository.AddAsync(printQueue);
    }

    public async Task UpdateAsync(int id, PrintQueue printQueueDto)
    {
        var printQueue = await _printQueueRepository.GetByIdAsync(id);
        if (printQueue != null)
        {
            printQueue.DocumentId = printQueueDto.DocumentId;
            printQueue.DocumentParameters = printQueueDto.DocumentParameters;
            printQueue.PrinterId = printQueueDto.PrinterId;
            printQueue.NumberOfCopy = printQueueDto.NumberOfCopy;

            await _printQueueRepository.UpdateAsync(printQueue);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _printQueueRepository.DeleteAsync(id);
    }
}