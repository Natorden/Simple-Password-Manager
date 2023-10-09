namespace WebAPI.DTOs;

public sealed record PasswordVaultDto
{
    public Guid OwnerGuid { get; set; }
    public IEnumerable<HashedCredentialsDto>? EncryptedVault { get; set; }
}