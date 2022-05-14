namespace Rift.Core.Events;

public class DomainEvent : IDomainEvent
{
    public string Type { get; set; }
}