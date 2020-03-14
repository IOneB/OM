using OM.Linq2Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using System.Linq;
using LinqToDB.Common;

namespace ConsoleApp12.Linq2Db
{
    //https://github.com/linq2db/linq2db
    class Linq2DbUserRepository : IUserRepository
    {
        public Linq2DbUserRepository()
        {

        }

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

        public async Task<IEnumerable<IUser>> GetUsers()
        {
            using var db = new DataConnection();
            var query = from u in db.Users
                        select u;
            return query.ToList();
        }

        public Task Update(IUser user)
        {



            return default;
        }
    }
}
