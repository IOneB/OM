using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class BulkUserRepository : IUserRepository
    {
        public Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetJoined()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
