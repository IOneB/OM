using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
