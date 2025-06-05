namespace WebApplication1.Domain.Interfaces
{
    public class Country
    {
        internal object Name;

        public static Guid Id { get; internal set; }
        public static DateTime CreatedDate { get; internal set; }
        public DateTime ModifiedDate { get; internal set; }
    }
}