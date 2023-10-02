namespace Data_Access_Layer.Models;

public sealed record PasswordVault
{
    public IDictionary<string, HashedCredentials> EncryptedVault { get; set; }
}