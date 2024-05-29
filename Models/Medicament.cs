namespace Clinic.Models;

public class Medicament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public ICollection<MedicamentPrescription> Prescriptions { get; } = new List<MedicamentPrescription>();
}
