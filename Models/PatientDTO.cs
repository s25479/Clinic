namespace Clinic.Models;

public class PatientDTO
{
    public PatientDTO(Patient patient)
    {
        IdPatient = patient.Id;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        BirthDate = patient.BirthDate;
        Prescriptions = patient.Prescriptions
            .OrderBy(prescriptionDTO => prescriptionDTO.DueDate)
            .Select(prescription => new PrescriptionDTO(prescription)).ToList();
    }

    public int IdPatient { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly BirthDate { get; }
    public List<PrescriptionDTO> Prescriptions { get; }
}
