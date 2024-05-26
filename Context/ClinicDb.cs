using Microsoft.EntityFrameworkCore;
using Clinic.Models;

public class ClinicDb : DbContext
{
    public ClinicDb(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medicament>(medicament =>
        {
            medicament.HasKey(e => e.Id);
        });
    }
}
