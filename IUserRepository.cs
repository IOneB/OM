using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task Delete(int id);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetUsers();
        Task Update(User user);

        Task<List<User>> GetJoined();
    }
}