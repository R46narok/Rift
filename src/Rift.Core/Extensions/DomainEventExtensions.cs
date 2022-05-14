using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Rift.Core.Events;

namespace Rift.Core.Extensions;

public static class DomainEventExtensions
{
    public static List<Type> Handlers { get; private set; }

    public static void AddDomainEventHandlers(this IServiceCollection services, Assembly assembly)
    {
        Handlers = assembly
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
            .ToList();

        foreach (var handler in Handlers)
        {
            var type = handler
                .GetInterfaces()
                .Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));

            services.AddTransient(type, handler);
        }
    }
}