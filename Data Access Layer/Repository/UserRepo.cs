using System.Data;
using System.Data.SqlClient;
using Dapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class UserRepo : IUserRepo
{
    private readonly string _connectionString;

    public UserRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Guid?> LoginAsync(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        //Set up DynamicParameters object to pass parameters  
        DynamicParameters parameters = new DynamicParameters();   
        parameters.Add("Username", user.Username);  
        parameters.Add("Password", user.Password);  
            
        //Execute stored procedure and map the returned result to a Customer object  
        return await connection.QuerySingleOrDefaultAsync<Guid?>("USER_MASTER_LOGIN", parameters, commandType: CommandType.StoredProcedure);
    }
}