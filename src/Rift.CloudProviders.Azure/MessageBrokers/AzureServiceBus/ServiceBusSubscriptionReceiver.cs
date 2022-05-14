using Azure.Messaging.ServiceBus;
using Rift.Core.Events;

namespace Rift.CloudProviders.Azure.MessageBrokers.AzureServiceBus;

public class ServiceBusSubscriptionReceiver<T> : ServiceBusReceiver<T>
    where T : IDomainEvent
{
    private readonly string _subscriptionName;

    public ServiceBusSubscriptionReceiver(string connectionString, string topicName, string subscriptionName)
        : base(connectionString, topicName)
    {
        _subscriptionName = subscriptionName;
    }

    protected override ServiceBusReceiver CreateReceiver(ServiceBusClient client)
    {
        return client.CreateReceiver(_queueName, _subscriptionName);
    }
}