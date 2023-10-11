using System.Data;
using System.Data.SqlClient;
using Dapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class UserRepo : IUserRepo
{
    private readonly IDbConnection _connection;

    public UserRepo(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<Guid?> LoginAsync(User user)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();   
        
        parameters.Add("Username", user.Username);  
        parameters.Add("Password", user.Password);  
            
        //Execute stored procedure and map the returned result to a Customer object  
        return await _connection.QuerySingleOrDefaultAsync<Guid?>("USER_MASTER_LOGIN", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Guid?> CreateAsync(User user)
    {
        Guid generatedGuid = Guid.NewGuid();
        
        try
        {
            var parameters = new DynamicParameters(); 
            parameters.Add("Userguid", generatedGuid);
            parameters.Add("Username", user.Username);  
            parameters.Add("Password", user.Password); 
                
            await _connection.QueryAsync("USER_MASTER_CREATE", parameters, commandType: CommandType.StoredProcedure);

            return generatedGuid;
        }
        catch
        {
            return null;
        }
    }

    public async Task<byte[]?> GetSaltAsync(string username)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();

        parameters.Add("Username", username);

        //Execute stored procedure and map the returned result to a Customer object  
        var returnedPasswordKey = await _connection.QuerySingleOrDefaultAsync<byte[]?>("GET_SALT", parameters, commandType: CommandType.StoredProcedure);
        if(returnedPasswordKey != null)
        {
            var salt = returnedPasswordKey.Take(16).ToArray();
            return salt;
        }
        return null;
    }
}