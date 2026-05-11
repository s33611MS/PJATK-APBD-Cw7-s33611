namespace PJATK_APBD_Cw7_s33611.DTOs;

public record UpdatePcDto
(
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);