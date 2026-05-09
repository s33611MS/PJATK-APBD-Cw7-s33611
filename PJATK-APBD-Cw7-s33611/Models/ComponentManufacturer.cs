using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33611.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
}