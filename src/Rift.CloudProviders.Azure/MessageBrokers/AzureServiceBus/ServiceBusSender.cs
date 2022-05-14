using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Rift.CloudProviders.MessageBrokers;
using Rift.Core.Events;

namespace Rift.CloudProviders.Azure.MessageBrokers.AzureServiceBus;

public class ServiceBusSender<T> : IMessageSender<T> 
    where T : IDomainEvent
{
    private readonly string _connectionString;
    private readonly string _queueName;

    public ServiceBusSender(string connectionString, string queueName)
    {
        _connectionString = connectionString;
        _queueName = queueName;
    }

    public async Task SendAsync(T message, MessageMetaData metaData, CancellationToken cancellationToken)
    {
        var client = new ServiceBusClient(_connectionString);
        var sender = client.CreateSender(_queueName);

        message.Type = typeof(T).Name;
        var json = JsonSerializer.Serialize(new Message<T>
        {
            Data = message,
            MetaData = metaData
        });
        var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(json));

        await sender.SendMessageAsync(serviceBusMessage, cancellationToken);
    }
}