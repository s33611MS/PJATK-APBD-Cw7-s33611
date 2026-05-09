using PJATK_APBD_Cw7_s33611.DTOs;

namespace PJATK_APBD_Cw7_s33611.Services;

public interface IPCService
{
    Task<IEnumerable<PCListDto>> GetPCsAsync(CancellationToken cancellationToken);
    Task<PCComponentsListDto> GetPCComponentsByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCListDto> AddPCAsync(CreatePCDto request, CancellationToken cancellationToken);
    Task UpdatePCAsync(int id, UpdatePCDto request, CancellationToken cancellationToken);
    Task DeletePCAsync(int id, CancellationToken cancellationToken);
}