namespace PJATK_APBD_Cw7_s33611.DTOs;

public record ComponentDto
(
    string Code,
    string Name,
    string Description,
    ComponentsManufacturerDto Manufacturer, 
    ComponentsTypeDto Type
);