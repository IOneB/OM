using ConsoleApp12;
using LinqToDB.Mapping;

namespace OM.Linq2Db.Models
{
    [Table(Name = "Groups")]
    public class Groupl2d : IGroup
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column, NotNull]
        public string Name { get; set; }
        [Column, NotNull]
        public int UserId { get; set; }
    }
}
