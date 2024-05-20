using Application.Interfaces;
using Domain.Interfaces;
using Shared.Models;

namespace Application.Services;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;

    public PrinterService(IPrinterRepository printerRepository)
    {
        _printerRepository = printerRepository;
    }

    public async Task<IEnumerable<Printer>> GetAllAsync()
    {
        return await _printerRepository.GetAllAsync();
    }

    public async Task<Printer?> GetByIdAsync(int id)
    {
        return await _printerRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Printer printer)
    {
        await _printerRepository.AddAsync(printer);
    }

    public async Task UpdateAsync(int id, Printer printerDto)
    {
        var printer = await _printerRepository.GetByIdAsync(id);
        if (printer != null)
        {
            printer.PrinterName = printerDto.PrinterName;
            printer.IsPrinterTCP = printerDto.IsPrinterTCP;
            printer.IPv4 = printerDto.IPv4;
            printer.Port = printerDto.Port;
            printer.PortSerial = printerDto.PortSerial;
            printer.Driver = printerDto.Driver;
            printer.PrintTypeId = printerDto.PrintTypeId;

            await _printerRepository.UpdateAsync(printer);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _printerRepository.DeleteAsync(id);
    }
}