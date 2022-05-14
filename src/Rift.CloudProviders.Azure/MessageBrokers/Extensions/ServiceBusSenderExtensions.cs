using System.Reflection;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rift.CloudProviders.Azure.MessageBrokers.Extensions;

public delegate ServiceBusSender ServiceBusSenderResolver(string key);

public static class ServiceBusSenderExtensions
{
    public static void AddAzureServiceBusSenders(this WebApplicationBuilder builder, Assembly assembly)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddSingleton(
            _ => new ServiceBusClient(configuration["AzureServiceBus:ConnectionString"]));

        var topics = configuration
            .GetSection("AzureServiceBus:Topics")
            .Get<string[]>();

        var dictionary = new Dictionary<string, ServiceBusSender>();
        
        foreach (var topic in topics)
        {
            services.AddSingleton(
                provider => provider.GetService<ServiceBusClient>()!.CreateSender(topic));
        }

        services.AddSingleton<ServiceBusSenderResolver>(provider => key =>
        {
            var senders = provider.GetServices<ServiceBusSender>();
            return senders.FirstOrDefault(sender => sender.EntityPath == key)!;
        });
    }
}