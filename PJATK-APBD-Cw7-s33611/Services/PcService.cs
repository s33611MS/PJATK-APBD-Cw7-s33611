using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33611.DTOs;
using PJATK_APBD_Cw7_s33611.Exceptions;
using PJATK_APBD_Cw7_s33611.Infrastructure;
using PJATK_APBD_Cw7_s33611.Models;

namespace PJATK_APBD_Cw7_s33611.Services;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.Pcs.Select(pc => new PcDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PcDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
            .Where(pc => pc.Id ==  id)
            .Select(pc => new PcDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"There is no PC with id: {id}");
    }

    public async Task<PcsComponentsListDto> GetComponentsByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.Pcs
                   .Where(pc => pc.Id == id)
                   .Select(pc => new PcsComponentsListDto(
                       pc.Id,
                       pc.Name,
                       pc.Weight,
                       pc.Warranty,
                       pc.CreatedAt,
                       pc.Stock,
                       pc.PcComponents.Select(pcc => new PcsComponentDto(
                           pcc.Amount,
                           new ComponentDto(
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
                               )
                           )
                           ))
                   )).FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"There is no PC with id: {id}");
    }

    public async Task<PcDto> AddAsync(CreatePcDto request, CancellationToken cancellationToken)
    {
        var pc = new Pc
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PcDto(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePcDto request, CancellationToken cancellationToken)
    {
        var affectedRows = await ctx.Pcs.Where(pc => pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(pc => pc.Name, request.Name)
                    .SetProperty(pc => pc.Weight, request.Weight)
                    .SetProperty(pc => pc.Warranty, request.Warranty)
                    .SetProperty(pc => pc.CreatedAt, request.CreatedAt)
                    .SetProperty(pc => pc.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"There is no PC with id: {id}");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var affectedRows = await ctx.Pcs
            .Where(pc => pc.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        
        if (affectedRows == 0)
        {
            throw new NotFoundException($"There is no PC with id: {id}");
        }
    }
}