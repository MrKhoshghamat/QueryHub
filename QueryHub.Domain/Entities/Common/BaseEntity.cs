using System.ComponentModel.DataAnnotations;

namespace QueryHub.Domain.Entities.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; }
    public DateTime? ModificationDateTime { get; set; } 
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}