namespace Rift.Core.Entities;

public class ConfigurationEntry : EntityBase<Guid>
{
    public string Key { get; set; }

    public string Value { get; set; }
}