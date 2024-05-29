namespace Clinic.Models;

public class DoctorDTO
{
    public DoctorDTO(Doctor doctor)
    {
        IdDoctor = doctor.Id;
        FirstName = doctor.FirstName;
        LastName = doctor.LastName;
        Email = doctor.Email;
    }

    public int IdDoctor { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
}
