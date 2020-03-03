using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp12
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }


        [Write(false)]
        [Computed]
        public List<Group> Groups { get; set; } = new List<Group>(10); 
    }
}
