using PJATK_APBD_Cw7_s33611.DTOs;

namespace PJATK_APBD_Cw7_s33611.Services;

public interface IPCService
{
    Task<IEnumerable<PCResponseDto>> GetPCsAsync(CancellationToken cancellationToken);
    Task<PCResponseDto> GetPCByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<PCComponentsListDto>> GetPCsComponentsByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCResponseDto> AddPCAsync(CreatePCDto request, CancellationToken cancellationToken);
    Task UpdatePCAsync(int id, UpdatePCDto request, CancellationToken cancellationToken);
    Task DeletePCAsync(int id, CancellationToken cancellationToken);
}