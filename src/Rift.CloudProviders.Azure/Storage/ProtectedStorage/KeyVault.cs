using Microsoft.Extensions.Configuration;
using Rift.CloudProviders.Storage;

namespace Rift.CloudProviders.Azure.Storage.ProtectedStorage;

public class KeyVault : IProtectedStorage
{
    private readonly IConfiguration _configuration;

    public KeyVault(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string Read(string key)
    {
        return _configuration[key];
    }
}