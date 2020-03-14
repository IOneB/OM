using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public interface IUserRepository
    {
        Task<IUser> Create(IUser user);
        Task Delete(int id);
        Task<IUser> Get(int id);
        Task<IEnumerable<IUser>> GetUsers();
        Task Update(IUser user);

        Task<List<IUser>> GetJoined();
    }
}