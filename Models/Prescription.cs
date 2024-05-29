namespace Clinic.Models;

public class Prescription
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }

    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public ICollection<MedicamentPrescription> MedicamentPrescriptions { get; } = new List<MedicamentPrescription>();
}
