using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33611.DTOs;
using PJATK_APBD_Cw7_s33611.Exceptions;
using PJATK_APBD_Cw7_s33611.Infrastructure;
using PJATK_APBD_Cw7_s33611.Models;

namespace PJATK_APBD_Cw7_s33611.Services;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponseDto>> GetPCsAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCResponseDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCResponseDto> GetPCByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(pc => pc.Id ==  id)
            .Select(pc => new PCResponseDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"There is no PC with id: {id}");
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

    public async Task<PCResponseDto> AddPCAsync(CreatePCDto request, CancellationToken cancellationToken)
    {
        var PC = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(PC);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new (PC.Id, PC.Name, PC.Weight, PC.Warranty, request.CreatedAt, request.Stock);
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