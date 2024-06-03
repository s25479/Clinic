using Microsoft.EntityFrameworkCore;
using Clinic.Models;

public class ClinicDb : DbContext
{
    public ClinicDb(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

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
        
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdDoctor");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdPatient");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdPrescription");

            entity.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.PatientId)
                .IsRequired();
            entity.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.DoctorId)
                .IsRequired();
        });

        modelBuilder.Entity<MedicamentPrescription>(entity =>
        {
            entity.ToTable("Prescription_Medicament");

            entity.Property(e => e.Details).HasMaxLength(100);
            entity.HasOne(e => e.Medicament)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.MedicamentId)
                .IsRequired();
            entity.HasOne(e => e.Prescription)
                .WithMany(e => e.MedicamentPrescriptions)
                .HasForeignKey(e => e.PrescriptionId)
                .IsRequired();
        });
    }
}
