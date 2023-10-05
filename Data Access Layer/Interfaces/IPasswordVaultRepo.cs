using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IPasswordVaultRepo
{
    Task<PasswordVault> GetAsync(Guid ownerGuid);
    Task<bool> UpdateAsync(Guid ownerGuid, PasswordVault vault);
}
