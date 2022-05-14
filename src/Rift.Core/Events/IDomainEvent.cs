namespace Rift.Core.Events;

public interface IDomainEvent
{
    public string Type { get; set; }
}