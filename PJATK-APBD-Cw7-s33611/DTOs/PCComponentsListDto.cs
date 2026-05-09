using PJATK_APBD_Cw7_s33611.Models;

namespace PJATK_APBD_Cw7_s33611.DTOs;

public record PCComponentsListDto(
    string Code,
    string Name,
    string Description,
    ComponentsManufacturerDto ComponentsManufacturerDto,
    ComponentsTypeDto ComponentsTypeDto,
    int Amount
);