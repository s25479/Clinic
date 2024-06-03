using Clinic.Exceptions;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;

public class PatientsService
{
    public PatientsService(ClinicDb dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PatientDTO> GetPatientData(int patientId)
    {
        var patient = await dbContext.Patients.FindAsync(patientId);
        if (patient == null)
            throw new ValidationException("Patient does not exist");
        return new PatientDTO(patient);
    }

    private readonly ClinicDb dbContext;
}
