using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33611.DTOs;
using PJATK_APBD_Cw7_s33611.Exceptions;
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

    public async Task<IEnumerable<PCComponentsListDto>> GetPCsComponentsByIdAsync(int id, CancellationToken cancellationToken)
    {
        var PC =  await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken) ?? throw new NotFoundException($"There is no PC with id: {id}");
        
        return await ctx.PCComponents
                   .Where(pcc => pcc.PCId == id)
                   .Select(pcc => new PCComponentsListDto(
                       pcc.ComponentCode,
                       pcc.Component.Name,
                       pcc.Component.Description,
                       new ComponentsManufacturerDto(
                           pcc.Component.ComponentManufacturer.Id,
                           pcc.Component.ComponentManufacturer.Abbreviation,
                           pcc.Component.ComponentManufacturer.FullName,
                           pcc.Component.ComponentManufacturer.FoundationDate
                           ),
                       new ComponentsTypeDto(
                           pcc.Component.ComponentType.Id,
                           pcc.Component.ComponentType.Abbreviation,
                           pcc.Component.ComponentType.Name
                           ),
                       pcc.Amount
                   )).ToListAsync(cancellationToken);
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