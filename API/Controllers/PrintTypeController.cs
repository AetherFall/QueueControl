using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintTypeController : ControllerBase
{
    private readonly IPrintTypeService _printTypeService;

    public PrintTypeController(IPrintTypeService printTypeService)
    {
        _printTypeService = printTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrintType>>> GetAll()
    {
        var printTypes = await _printTypeService.GetAllAsync();
        return Ok(printTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrintType>> GetById(int id)
    {
        var printType = await _printTypeService.GetByIdAsync(id);
        if (printType == null)
        {
            return NotFound();
        }
        return Ok(printType);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PrintType printType)
    {
        await _printTypeService.AddAsync(printType);
        return CreatedAtAction(nameof(GetById), new { id = printType.Id }, printType);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, PrintType printType)
    {
        await _printTypeService.UpdateAsync(id, printType);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _printTypeService.DeleteAsync(id);
        return NoContent();
    }
}