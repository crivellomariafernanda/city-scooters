using city_scooters.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Scooter> Scooters{ get; set; }
    public DbSet<Station> Stations{ get; set; }
    public DbSet<RentalHistoryEntry> RentalHistoryEntries { get; set; }
}
