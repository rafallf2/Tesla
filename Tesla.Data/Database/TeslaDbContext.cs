using Microsoft.EntityFrameworkCore;
using Tesla.Data.Models;

namespace Tesla.Data.Database
{
    public class TeslaDbContext : DbContext
    {
        public TeslaDbContext(DbContextOptions dbOptions) : base(dbOptions) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarLocalisation> CarLocalisations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Localisation> Localisations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasMany(c => c.CarLocalisation).WithOne(c => c.Car);
            modelBuilder.Entity<Car>().HasMany(c => c.Reservation).WithOne(c => c.Car);

            modelBuilder.Entity<Localisation>().HasMany(l => l.CarLocalisation).WithOne(l => l.Localisation);
            modelBuilder.Entity<Localisation>().HasMany(l => l.Reservation).WithOne(l => l.Localisation);

            modelBuilder.Entity<Client>().HasMany(c => c.Reservation).WithOne(c => c.Client);
        }
    }
}
