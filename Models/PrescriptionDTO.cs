namespace Clinic.Models;

public class PrescriptionDTO
{
    public PrescriptionDTO(Prescription prescription)
    {
        IdPrescription = prescription.Id;
        Date = prescription.Date;
        DueDate = prescription.DueDate;
        Medicaments = prescription.MedicamentPrescriptions
            .Select(medicamentPrescription => new MedicamentDTO(medicamentPrescription)).ToList();
        Doctor = new DoctorDTO(prescription.Doctor);
    }

    public int IdPrescription { get; }
    public DateOnly Date { get; }
    public DateOnly DueDate { get; }
    public List<MedicamentDTO> Medicaments { get; }
    public DoctorDTO Doctor { get; }
}
