using Microsoft.EntityFrameworkCore;

namespace Farmer.Entities
{
    public class FarmerContext : DbContext
    {
        public FarmerContext(DbContextOptions<FarmerContext>options) :base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Field> Fields { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>(f =>
            {
                f.Property(w => w.FieldNumber).HasMaxLength(11);
            });
            modelBuilder.Entity<Animal>(a =>
            {
                a.Property(b => b.EatLevel).HasDefaultValue(3);
                a.Property(b => b.LiveTime).HasDefaultValue(1);
            });
            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(g => g.Animals).WithOne(x => x.User).HasForeignKey(x=> x.UserId);
                u.HasMany(g => g.Fields).WithOne(x => x.User).HasForeignKey(x=>x.UserId);
            });
                       
        }

    }
}
