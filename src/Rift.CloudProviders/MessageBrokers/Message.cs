using Rift.Core.Events;

namespace Rift.CloudProviders.MessageBrokers;

public class Message<T> where T : IDomainEvent
{
    public T Data { get; set; }
    public MessageMetaData MetaData { get; set; }
}