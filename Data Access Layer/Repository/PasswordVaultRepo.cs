using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class PasswordVaultRepo : IPasswordVaultRepo
{
    private readonly string _connectionString;

    public PasswordVaultRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<PasswordVault> GetAsync(Guid ownerGuid)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Guid ownerGuid, PasswordVault vault)
    {
        throw new NotImplementedException();
    }
}