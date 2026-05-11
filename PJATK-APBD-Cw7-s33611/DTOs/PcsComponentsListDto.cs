namespace PJATK_APBD_Cw7_s33611.DTOs;

public record PcsComponentsListDto(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcsComponentDto> Components
);