namespace Rift.CloudProviders.Azure.Storage.ProtectedStorage;

public class KeyVaultOptions
{
    public string Name { get; set; }
    public string TenantId { get; set; }
    public string ApplicationId { get; set; }
    public string CertificateThumbprint { get; set; }
}