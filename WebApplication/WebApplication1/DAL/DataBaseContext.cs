using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL
{
    public class DataBaseContext : DbContext
    {
        //Contructor para conectarse a la bd
        public DataBaseContext(DbContextOptions<DataBaseContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

        #region DbSet
        public DbSet<Country> Countries { get; set; }
        #endregion
    }
}
