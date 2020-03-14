using ConsoleApp12;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Linq2Db.Models
{
    [Table(Name = "Users")]
    public class Userl2d : IUser
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column, NotNull]
        public int Age { get; set; }
        [Column, NotNull]
        public string Name { get; set; }

        public List<IGroup> Groups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
