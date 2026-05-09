using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33611.Models;

[Table("Components")]
public class Component
{
    [Key, Column(TypeName =  "char(10)")]
    public string Code { get; set; } =  string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentsManufacturersId { get; set; }
    public int ComponentsTypesId { get; set; }
    
    [ForeignKey(nameof(ComponentsManufacturersId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentsTypesId))]
    public ComponentType ComponentType { get; set; } = null!;
    
    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}