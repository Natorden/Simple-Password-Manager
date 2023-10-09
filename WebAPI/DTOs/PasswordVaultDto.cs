﻿namespace WebAPI.DTOs;

public sealed record PasswordVaultDto
{
    public Guid OwnerGuid { get; set; }
    public IDictionary<string, HashedCredentialsDto>? EncryptedVault { get; set; }
}