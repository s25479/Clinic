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
        if (patient == null) {
            // throw exception
        }

        return new PatientDTO(patient);
    }

    private readonly ClinicDb dbContext;
}
