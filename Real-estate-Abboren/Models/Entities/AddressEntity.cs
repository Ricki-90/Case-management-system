using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_estate_Abboren.Models.Entities;


internal class Case
{
    [Key]
    public int CaseId { get; set; }


}




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


internal class RenterEntity
{
    [Key]
    public int RenterId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Column(TypeName = "char(13)")]
    public string? PhoneNumber { get; set; }
    
    public int AddressId {get; set; }
    public AddressEntity Address { get; set; } = null!;
}
