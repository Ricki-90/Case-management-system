using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_estate_Abboren.Models.Entities;

internal class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string StreetName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = string.Empty;

    public ICollection<RenterEntity> Renters = new HashSet<RenterEntity>();
}
