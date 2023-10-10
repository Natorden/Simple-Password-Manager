namespace Web_Client.DTOs;

public sealed record PasswordVaultDto
{
    public Guid OwnerGuid { get; set; }
    public IEnumerable<HashedCredentialsDto>? EncryptedVault { get; set; }
    public IEnumerable<DecryptedCredentialsDto>? DecryptedVault { get; set; }
}