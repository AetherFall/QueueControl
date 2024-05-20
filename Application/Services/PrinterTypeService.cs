using Application.Interfaces;
using Domain.Interfaces;
using Shared.Models;

namespace Application.Services;

public class PrintTypeService : IPrintTypeService
{
    private readonly IPrintTypeRepository _printTypeRepository;

    public PrintTypeService(IPrintTypeRepository printTypeRepository)
    {
        _printTypeRepository = printTypeRepository;
    }

    public async Task<IEnumerable<PrintType?>> GetAllAsync()
    {
        return await _printTypeRepository.GetAllAsync();
    }

    public async Task<PrintType?> GetByIdAsync(int id)
    {
        return await _printTypeRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(PrintType printTypeDto)
    {
        var printType = new PrintType
        {
            Name = printTypeDto.Name
        };

        await _printTypeRepository.AddAsync(printType);
    }

    public async Task UpdateAsync(int id, PrintType printTypeDto)
    {
        var printType = await _printTypeRepository.GetByIdAsync(id);
        if (printType != null)
        {
            printType.Name = printTypeDto.Name;

            await _printTypeRepository.UpdateAsync(printType);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _printTypeRepository.DeleteAsync(id);
    }
}