using Rift.Core.Events;

namespace Rift.CloudProviders.MessageBrokers;

public interface IMessageSender<in T> where T : IDomainEvent
{
    public Task SendAsync(T message, MessageMetaData metaData, CancellationToken cancellationToken);
}