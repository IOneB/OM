using ConsoleApp12.Linq2Db;
using LinqToDB.Data;
using OM.Linq2Db.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            OM.Linq2Db.Models.DataConnection.DefaultSettings = new MySettings();

            var classes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetInterface(nameof(IUserRepository)) != null && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x))
                .OfType<IUserRepository>();
            Console.WriteLine(string.Join(" ", (await new Linq2DbUserRepository().GetUsers()).Select(x => x.Name)));

            //foreach (var @class in classes)
            //{
            //    Console.WriteLine(@class.GetType().Name);
            //    await Debug(@class);
            //    Console.WriteLine("\n\n\n\n");
            //}
        }

        private static async Task WriteAboutAll(IUserRepository repos)
        {
            var users = await repos.GetUsers();
            Console.WriteLine(string.Join(", ", users.Select(x => $"{x.Name}:{x.Age}")));
        }

        private static async Task Debug(IUserRepository repos)
        {
            await WriteAboutAll(repos);

            var user = await repos.Create(new UserDapper
            {
                Age = new Random().Next(),
                Name = Guid.NewGuid().ToString()
            });

            Console.WriteLine($"Current - {user.Name}: {user.Age}");
            user.Name += "Updated";
            await repos.Update(user);

            await repos.Get(user.Id);
            Console.WriteLine($"Current - {user.Name}: {user.Age}");

            await repos.Delete(user.Id);

            await WriteAboutAll(repos);

            var joined = await repos.GetJoined();
            foreach (var item in joined)
            {
                Console.WriteLine($"{item.Name} - {item.Groups.Count} joined groups");
            }
        }
    }
}
