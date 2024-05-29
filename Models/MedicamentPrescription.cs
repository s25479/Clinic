namespace Clinic.Models;

public class MedicamentPrescription
{
    public int MedicamentId { get; set; }
    public int PrescriptionId { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; } = string.Empty;

    public Medicament Medicament { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;
}
