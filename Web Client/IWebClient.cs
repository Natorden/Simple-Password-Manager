using Web_Client.DTOs;

namespace Web_Client;
public interface IWebClient
{
    Task<Guid?> LoginAsync(UserDto user);
    Task<PasswordVaultDto?> GetAsync(Guid? ownerGuid);
    Task<bool> UpdateAsync(Guid? ownerGuid, PasswordVaultDto vault);
    Task<Guid?> CreateUserAsync(UserDto user);
    Task<byte[]> GetSaltAsync(string username);
}
