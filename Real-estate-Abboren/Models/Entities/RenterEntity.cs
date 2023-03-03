using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_estate_Abboren.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class RenterEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Column(TypeName = "char(13)")]
    public string? PhoneNumber { get; set; }

    [Required]
    public int AddressId {get; set; }
    public AddressEntity Address { get; set; } = null!;
}
