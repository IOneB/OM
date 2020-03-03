using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12.Linq2Db
{
    //https://github.com/linq2db/linq2db
    class Linq2DbUserRepository : IUserRepository
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
