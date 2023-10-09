using System.Data;
using System.Data.SqlClient;
using Dapper;
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

    
    
    public async Task<PasswordVault?> GetAsync(Guid ownerGuid)
    {
        using var connection = new SqlConnection(_connectionString);
        
        DynamicParameters parameters = new DynamicParameters();   
        parameters.Add("UserGuID", ownerGuid); 
        
        var vaults = await connection.QueryAsync<PasswordVault, IEnumerable<HashedCredentials>, PasswordVault>(
            "GET_VAULT",
            (vault, credentials) =>
            {
                if (vault.EncryptedVault == null)
                    vault.EncryptedVault = new List<HashedCredentials>();

                _ = vault.EncryptedVault.Concat(credentials);
                return vault;
            },
            new { ownerGuid },
            splitOn: "Sitename" // Specify the column to split the results on
            , commandType: CommandType.StoredProcedure);
        
        // var hashedCreds = await connection.QuerySingleOrDefaultAsync<IEnumerable<HashedCredentials>>("GET_VAULT", parameters, commandType: CommandType.StoredProcedure);

        return vaults.Distinct().FirstOrDefault();
    }

    public async Task<bool> UpdateAsync(Guid ownerGuid, PasswordVault vault)
    {
        using var connection = new SqlConnection(_connectionString);

        if (vault.EncryptedVault == null)
            return false;
        
        try{
            foreach(var credential in vault.EncryptedVault) 
            {
                DynamicParameters parameters = new DynamicParameters(); 
                parameters.Add("Guid", vault.OwnerGuid);
                parameters.Add("Sitename", credential.Sitename);
                parameters.Add("Username", credential.Username);  
                parameters.Add("Password", credential.Password); 
                
                await connection.QueryAsync("CREATE_VAULT", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}