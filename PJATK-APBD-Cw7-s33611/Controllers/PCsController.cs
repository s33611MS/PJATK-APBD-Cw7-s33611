using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33611.DTOs;
using PJATK_APBD_Cw7_s33611.Exceptions;
using PJATK_APBD_Cw7_s33611.Services;

namespace PJATK_APBD_Cw7_s33611.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController(IPCService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPCs(CancellationToken cancellationToken)
    {
        return Ok(await service.GetPCsAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPCById([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetPCByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCsComponents([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetPCsComponentsByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPC([FromBody] CreatePCDto request, CancellationToken cancellationToken)
    {
        var pc = await service.AddPCAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetPCById), new { id = pc.Id }, pc);
    }
}