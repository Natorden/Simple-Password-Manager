using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class UserRepo : IUserRepo
{
    public async Task<int> LoginAsync(User user)
    {
        throw new NotImplementedException();
    }
}