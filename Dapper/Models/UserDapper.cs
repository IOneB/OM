using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp12
{
    [Table("Users")]
    public class UserDapper : IUser
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }


        [Write(false)]
        [Computed]
        public List<IGroup> Groups { get; set; } = new List<IGroup>(10); 
    }
}
