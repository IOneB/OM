using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            using var context = new SqlConnection(Config._connectionString);
            return await context.QueryAsync<User>("Select * from Users");
        }

        public async Task<User> Get(int id)
        {
            using var context = new SqlConnection(Config._connectionString);
            var query = @"Select * from Users where Id = @Id";
            return await context.QueryFirstAsync<User>(query, new { Id = id });
        }

        public async Task<User> Create(User user)
        {
            using var context = new SqlConnection(Config._connectionString);
            var query = @"Insert into Users(Name, Age) values(@Name, @Age); Select Cast(SCOPE_IDENTITY() as int)";
            var userId = await context.QueryFirstAsync<int>(query, user);
            user.Id = userId;
            return user;
        }

        public async Task Update(User user)
        {
            using var context = new SqlConnection(Config._connectionString);
            var query = @"Update users set Name = @Name, Age = @Age where Id = @Id";
            await context.ExecuteAsync(query, user);
        }

        public async Task Delete(int id)
        {
            using var context = new SqlConnection(Config._connectionString);
            var query = @"Delete From Users where Id = @id";

            await context.ExecuteAsync(query, new { id });
        }

        public async Task<List<User>> GetJoined()
        {
            using var context = new SqlConnection(Config._connectionString);
            var users = await context.QueryAsync<User, Group, User>(
                "Select * from Users u Left Join groups g on u.Id = g.UserId",
                (u, g) => { u.Groups.Add(g); return u; }, splitOn: "Id");
            return users.GroupBy(x => x.Id).Select(x => {
                var @params = x.FirstOrDefault();
                @params.Groups = x.SelectMany(x => x.Groups).ToList();
                return @params;
                }).ToList();
        }
    }
}
