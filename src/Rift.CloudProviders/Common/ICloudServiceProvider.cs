using Rift.CloudProviders.MessageBrokers;
using Rift.Core.Events;

namespace Rift.CloudProviders.Common;

public interface ICloudServiceProvider
{
    public IMessageSender<T> CreateTopicSender<T>(string topic) where T : IDomainEvent;
    public IMessageSender<T> CreateQueueSender<T>(string topic) where T : IDomainEvent;
}