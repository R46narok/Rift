using Rift.CloudProviders.Azure.MessageBrokers.AzureServiceBus;
using Rift.CloudProviders.Azure.MessageBrokers.Extensions;
using Rift.CloudProviders.Common;
using Rift.CloudProviders.MessageBrokers;
using Rift.Core.Events;

namespace Rift.CloudProviders.Azure.Common;

public class AzureServiceProvider : ICloudServiceProvider
{
    private readonly ServiceBusSenderResolver _senderResolver;

    public AzureServiceProvider(ServiceBusSenderResolver senderResolver)
    {
        _senderResolver = senderResolver;
    }
    
    public IMessageSender<T> CreateTopicSender<T>(string topic) where T : IDomainEvent
    {
        var sender = _senderResolver(topic);
        return new ServiceBusTopicSender<T>(sender, topic);
    }

    public IMessageSender<T> CreateQueueSender<T>(string queue) where T : IDomainEvent
    {
        var sender = _senderResolver(queue);
        return new ServiceBusTopicSender<T>(sender, queue);
    }
}