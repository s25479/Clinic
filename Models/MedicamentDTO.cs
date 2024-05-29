namespace Clinic.Models;

public class MedicamentDTO
{
    public MedicamentDTO(MedicamentPrescription prescription)
    {
        IdMedicament = prescription.Medicament.Id;
        Name = prescription.Medicament.Name;
        Description = prescription.Medicament.Description;
        Type = prescription.Medicament.Type;
        Dose = prescription.Dose;
        PrescriptionDetails = prescription.Details;
    }

    public int IdMedicament { get; }
    public string Name { get; }
    public string Description { get; }
    public string Type { get; }
    public int? Dose { get; }
    public string PrescriptionDetails { get; }
}
