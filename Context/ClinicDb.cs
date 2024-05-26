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
        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdMedicament");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
        });
    }
}
