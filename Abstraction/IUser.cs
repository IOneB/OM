using System.Collections.Generic;

namespace ConsoleApp12
{
    public interface IUser
    {
        public abstract int Id { get; set; }
        public abstract int Age { get; set; }
        public abstract string Name { get; set; }


        public abstract List<IGroup> Groups { get; set; }
    }
}