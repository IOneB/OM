using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace ConsoleApp12
{
    public class ContribUserRepository : IUserRepository
    {
        public async Task<User> Create(User user)
        {
            using var context = new SqlConnection(Config._connectionString);
            await context.OpenAsync();

            var identity = await context.InsertAsync(user);
            user.Id = Convert.ToInt32(identity);

            return user;
        }

        public async Task Delete(int id)
        {
            using var context = new SqlConnection(Config._connectionString);
            await context.OpenAsync();

            await context.DeleteAsync(new User { Id = id });
        }

        public async Task<User> Get(int id)
        {
            using var context = new SqlConnection(Config._connectionString);
            await context.OpenAsync();

            return await context.GetAsync<User>(id);
        }

        public async Task<List<User>> GetJoined()
        {
            using var context = new SqlConnection(Config._connectionString);

            var users = await context.GetAllAsync<User>();

            var ids = users.Select(x => x.Id);
            var groups = await context.QueryAsync<Group>("Select * from groups where UserId in @Ids", new { Ids = ids.ToArray() });

            return users.Select(x =>
            {
                x.Groups = groups.Where(g => g.UserId == x.Id).ToList();
                return x;
            }).ToList();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using var context = new SqlConnection(Config._connectionString);
            await context.OpenAsync();

            return await context.GetAllAsync<User>();
        }

        public async Task Update(User user)
        {
            using var context = new SqlConnection(Config._connectionString);
            await context.OpenAsync();

            await context.UpdateAsync(user);
        }
    }
}
