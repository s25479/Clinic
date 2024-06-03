using Clinic.Models;

namespace Clinic.Services;

public interface IPatientsService
{
    Task<PatientDTO> GetPatientData(int patientId);
}
