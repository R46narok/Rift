using System.ComponentModel.DataAnnotations;

namespace Rift.Core.Entities;

public abstract class EntityBase<T> : IEntity<T>
{
    [Key]
    public T Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}