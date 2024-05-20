using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintDocumentController : ControllerBase
{
    private readonly IPrintDocumentService _printDocumentService;

    public PrintDocumentController(IPrintDocumentService printDocumentService)
    {
        _printDocumentService = printDocumentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrintDocument>>> GetAll()
    {
        var printDocuments = await _printDocumentService.GetAllAsync();
        return Ok(printDocuments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrintDocument>> GetById(int id)
    {
        var printDocument = await _printDocumentService.GetByIdAsync(id);
        if (printDocument == null)
        {
            return NotFound();
        }
        return Ok(printDocument);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PrintDocument printDocument)
    {
        await _printDocumentService.AddAsync(printDocument);
        return CreatedAtAction(nameof(GetById), new { id = printDocument.Id }, printDocument);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, PrintDocument printDocument)
    {
        await _printDocumentService.UpdateAsync(id, printDocument);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _printDocumentService.DeleteAsync(id);
        return NoContent();
    }
}