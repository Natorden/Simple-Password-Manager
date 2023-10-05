using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IUserRepo
{
    Task<int> LoginAsync(User user);
}
