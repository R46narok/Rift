namespace Rift.CloudProviders.Storage;

public interface IProtectedStorage
{
    public string Read(string key);
}