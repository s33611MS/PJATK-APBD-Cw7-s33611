using Microsoft.AspNetCore.Mvc;
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
}