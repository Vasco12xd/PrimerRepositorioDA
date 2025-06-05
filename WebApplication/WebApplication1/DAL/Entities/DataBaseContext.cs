using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DAL.Entities
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
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();// Haciendo un indice compuesto 
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        #endregion
    }
}
