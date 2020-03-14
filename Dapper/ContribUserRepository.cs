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
        public async Task<IUser> Create(IUser user)
        {
            using var context = new SqlConnection(Config.connectionString);
            await context.OpenAsync();

            var identity = await context.InsertAsync(user);
            user.Id = Convert.ToInt32(identity);

            return user;
        }

        public async Task Delete(int id)
        {
            using var context = new SqlConnection(Config.connectionString);
            await context.OpenAsync();

            await context.DeleteAsync(new UserDapper { Id = id });
        }

        public async Task<IUser> Get(int id)
        {
            using var context = new SqlConnection(Config.connectionString);
            await context.OpenAsync();

            return await context.GetAsync<UserDapper>(id);
        }

        public async Task<List<IUser>> GetJoined()
        {
            using var context = new SqlConnection(Config.connectionString);

            var users = await context.GetAllAsync<UserDapper>();

            var ids = users.Select(x => x.Id);
            var groups = await context.QueryAsync<GroupDapper>("Select * from groups where UserId in @Ids", new { Ids = ids.ToArray() });

            return users.Select(x =>
            {
                x.Groups = groups.Where(g => g.UserId == x.Id).Cast<IGroup>().ToList();
                return (IUser)x;
            }).ToList();
        }

        public async Task<IEnumerable<IUser>> GetUsers()
        {
            using var context = new SqlConnection(Config.connectionString);
            await context.OpenAsync();

            return await context.GetAllAsync<UserDapper>();
        }

        public async Task Update(IUser user)
        {
            using var context = new SqlConnection(Config.connectionString);
            await context.OpenAsync();

            await context.UpdateAsync(user);
        }
    }
}
