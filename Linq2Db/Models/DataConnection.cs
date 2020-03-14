using LinqToDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OM.Linq2Db.Models
{
    public class DataConnection : LinqToDB.Data.DataConnection
    {
        public DataConnection() : base("Dapper")
        {}

        public ITable<Userl2d> Users => GetTable<Userl2d>();
        public ITable<Groupl2d> Groups => GetTable<Groupl2d>();
        
    }
}
