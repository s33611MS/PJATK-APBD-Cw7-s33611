using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33611.DTOs;
using PJATK_APBD_Cw7_s33611.Infrastructure;

namespace PJATK_APBD_Cw7_s33611.Services;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCListDto>> GetPCsAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCListDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCComponentsListDto> GetPCComponentsByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PCListDto> AddPCAsync(CreatePCDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePCAsync(int id, UpdatePCDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePCAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}