using Data_Access_Layer.Models;

namespace WebAPI.DTOs;

public sealed record PasswordVaultDto
{
    public Guid OwnerGuid { get; set; }
    public IDictionary<string, HashedCredentials>? EncryptedVault { get; set; }
}