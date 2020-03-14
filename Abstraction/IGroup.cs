namespace ConsoleApp12
{
    public interface IGroup
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract int UserId { get; set; }
    }
}