using PJATK_APBD_Cw7_s33611.DTOs;

namespace PJATK_APBD_Cw7_s33611.Services;

public interface IPcService
{
    Task<IEnumerable<PcDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcsComponentsListDto> GetComponentsByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcDto> AddAsync(CreatePcDto request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePcDto request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}