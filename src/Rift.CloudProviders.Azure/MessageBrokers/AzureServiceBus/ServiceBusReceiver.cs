using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Rift.CloudProviders.MessageBrokers;
using Rift.Core.Events;

namespace Rift.CloudProviders.Azure.MessageBrokers.AzureServiceBus;

public class ServiceBusMessageReceivedArgs<T> : EventArgs
{
    public T Data { get; set; }
    public MessageMetaData MetaData { get; set; }
}

public class ServiceBusReceiver<T> : IMessageReceiver
    where T : IDomainEvent
{
    private readonly string _connectionString;
    protected readonly string _queueName;

    private const int Timeout = 1000;

    public event EventHandler<ServiceBusMessageReceivedArgs<T>> MessageReceived;

    public ServiceBusReceiver(string connectionString, string queueName)
    {
        _connectionString = connectionString;
        _queueName = queueName;
    }

    public void Receive(Action<T, MessageMetaData> action)
    {
        Task.Factory.StartNew(() => ReceiveAsync(action));
    }

    private Task ReceiveAsync(Action<T, MessageMetaData> action)
    {
        return ReceiveStringAsync(retrievedMessage =>
        {
            var message = JsonSerializer.Deserialize<Message<T>>(retrievedMessage);
            if (message is not null && message.Data.Type == typeof(T).Name)
                action.Invoke(message!.Data, message.MetaData);
        });
    }

    public void ReceiveString(Action<string> action)
    {
        Task.Factory.StartNew(() => ReceiveStringAsync(action));
    }

    private async Task ReceiveStringAsync(Action<string> action)
    {
        await using var client = new ServiceBusClient(_connectionString);
        var receiver = CreateReceiver(client);

        while (true)
        {
            var retrievedMessage = await receiver.ReceiveMessageAsync();

            if (retrievedMessage is not null)
            {
                action(Encoding.UTF8.GetString(retrievedMessage.Body));
                await receiver.CompleteMessageAsync(retrievedMessage);
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }
    
    protected virtual ServiceBusReceiver CreateReceiver(ServiceBusClient client)
    {
        return client.CreateReceiver(_queueName);
    }
}