using Web_Client.DTOs;

namespace Web_Client;
public interface IWebClient
{
    Task<int> LoginAsync(UserDto user);
    Task<PasswordVaultDto> GetAsync(Guid ownerGuid);
    Task<bool> UpdateAsync(Guid ownerGuid, PasswordVaultDto vault);

}
