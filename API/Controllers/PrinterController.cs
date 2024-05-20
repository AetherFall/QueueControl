using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;

    public PrinterController(IPrinterService printerService)
    {
        _printerService = printerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Printer>>> GetAll()
    {
        var printers = await _printerService.GetAllAsync();
        return Ok(printers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Printer>> GetById(int id)
    {
        var printer = await _printerService.GetByIdAsync(id);
        if (printer == null)
        {
            return NotFound();
        }
        return Ok(printer);
    }

    [HttpPost]
    public async Task<ActionResult> Add(Printer printer)
    {
        await _printerService.AddAsync(printer);
        return CreatedAtAction(nameof(GetById), new { id = printer.Id }, printer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Printer printer)
    {
        await _printerService.UpdateAsync(id, printer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _printerService.DeleteAsync(id);
        return NoContent();
    }
}