namespace Clinic.Models;

public class Patient
{
    public Patient(NewPrescriptionDTO.PatientDTO patientDTO)
    {
        Id = patientDTO.Id!.Value;
        FirstName = patientDTO.FirstName;
        LastName = patientDTO.LastName;
        BirthDate = patientDTO.BirthDate!.Value;
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
