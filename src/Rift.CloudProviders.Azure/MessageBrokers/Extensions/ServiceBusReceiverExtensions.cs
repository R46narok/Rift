using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rift.CloudProviders.Azure.MessageBrokers.AzureServiceBus;
using Rift.CloudProviders.MessageBrokers;
using Rift.Core.Events;
using Rift.Core.Extensions;

namespace Rift.CloudProviders.Azure.MessageBrokers.Extensions;

public static class ServiceBusReceiverExtensions
{
    private static IServiceProvider Provider { get; set; }
    
    public static void AddAzureServiceBusReceivers(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        var method = typeof(ServiceBusReceiverExtensions).GetMethod(nameof(CreateInstance), BindingFlags.Static | BindingFlags.NonPublic);

        foreach (var type in DomainEventExtensions.Handlers)
        {
            var genericInterface = type
                .GetInterfaces()
                .SingleOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));

            if (genericInterface is not null)
            {
                var attribute = type.GetCustomAttribute<DomainEventHandlerConfigurationAttribute>();
                if (attribute is null) break;
                
                var eventType = genericInterface.GetGenericArguments().First();

                var genericMethod = method!.MakeGenericMethod(eventType);
                var receiver = genericMethod.Invoke(null, new object?[]
                {
                    configuration["AzureServiceBus:ConnectionString"],
                    attribute.Topic,
                    attribute.Subscription
                });

                services.AddSingleton(receiver!);
            }
        }
    }

    public static void UseAzureServiceBusReceivers(this WebApplication app)
    {
        Provider = app.Services;
    }

    private static IMessageReceiver CreateInstance<T>(
        string connectionString, string topicName, string subscriptionName)
        where T : IDomainEvent
    {
        var receiver = new ServiceBusSubscriptionReceiver<T>(connectionString, topicName, subscriptionName);
        receiver.Receive((data, metaData) =>
        {
            var handler = Provider.GetService<IDomainEventHandler<T>>();
            handler?.HandleAsync(data);
        });

        return receiver;
    }
}