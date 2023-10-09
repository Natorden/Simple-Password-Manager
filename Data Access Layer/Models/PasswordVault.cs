namespace Data_Access_Layer.Models;

public sealed record PasswordVault
{
    public Guid OwnerGuid { get; set; }
    public IEnumerable<HashedCredentials>? EncryptedVault { get; set; }
}