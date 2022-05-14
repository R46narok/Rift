using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rift.CloudProviders.Storage;

namespace Rift.CloudProviders.Azure.Storage.ProtectedStorage;

public static class KeyVaultExtensions
{
    private static IConfiguration? _configuration;
    
    public static void AddAzureKeyVaulttt(this IConfiguration configuration, KeyVaultOptions options)
    {
        using var x509Store = new X509Store(StoreLocation.CurrentUser);

        x509Store.Open(OpenFlags.ReadOnly);

        var x509Certificate = x509Store.Certificates
            .Find(
                X509FindType.FindByThumbprint,
                options.CertificateThumbprint,
                validOnly: false).OfType<X509Certificate2>()
            .SingleOrDefault();

        // configuration.AddAzureKeyVault(
        //     new Uri($"https://{options.Name}.vault.azure.net/"),
        //     new ClientCertificateCredential(
        //         options.TenantId,
        //         options.ApplicationId,
        //         x509Certificate));
        
        _configuration = configuration;
    }
    
    public static void AddAzureKeyVault(this IServiceCollection services, KeyVaultOptions options)
    {
        if (_configuration is null)
            throw new ArgumentNullException(nameof(_configuration), "AddAzureKeyVault must be called on the configuration first");
        services.AddTransient<IProtectedStorage, KeyVault>(storage => new KeyVault(_configuration));
    }
}