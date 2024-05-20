using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrintQueueController : ControllerBase
{
    private readonly IPrintQueueService _printQueueService;

    public PrintQueueController(IPrintQueueService printQueueService)
    {
        _printQueueService = printQueueService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrintQueue>>> GetAll()
    {
        var printQueues = await _printQueueService.GetAllAsync();
        return Ok(printQueues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PrintQueue>> GetById(int id)
    {
        var printQueue = await _printQueueService.GetByIdAsync(id);
        if (printQueue == null)
        {
            return NotFound();
        }
        return Ok(printQueue);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PrintQueue printQueue)
    {
        await _printQueueService.AddAsync(printQueue);
        return CreatedAtAction(nameof(GetById), new { id = printQueue.Id }, printQueue);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, PrintQueue printQueue)
    {
        await _printQueueService.UpdateAsync(id, printQueue);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _printQueueService.DeleteAsync(id);
        return NoContent();
    }
}