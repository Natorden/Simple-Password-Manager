namespace Data_Access_Layer.Models;

public sealed record PasswordVault
{
    public Guid OwnerGuid { get; set; }
    public IDictionary<string, HashedCredentials> EncryptedVault { get; set; }
}