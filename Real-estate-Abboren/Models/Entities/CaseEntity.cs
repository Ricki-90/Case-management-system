using System.ComponentModel.DataAnnotations;

namespace Real_estate_Abboren.Models.Entities;

internal class CaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string IncomingDate { get; set; } = string.Empty;

}
