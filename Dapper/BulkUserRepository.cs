using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class BulkUserRepository : IUserRepository
    {
        public Task<IUser> Create(IUser user)
        {
            return default;

        }

        public Task Delete(int id)
        {
            return default;

        }

        public Task<IUser> Get(int id)
        {
            return default;

        }

        public Task<List<IUser>> GetJoined()
        {
            return default;
        }

        public Task<IEnumerable<IUser>> GetUsers()
        {
            return default;

        }

        public Task Update(IUser user)
        {
            return default;

        }
    }
}
