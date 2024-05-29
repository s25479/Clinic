using Clinic.Models;
using Microsoft.EntityFrameworkCore;

public class PrescriptionsService
{
    public PrescriptionsService(ClinicDb dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<NewPrescriptionDTO> AddPrescription(NewPrescriptionDTO newPrescription)
    {
        var patient = await dbContext.Patients.FindAsync(newPrescription.Patient.Id);
        if (patient == null) {
            patient = new Patient(newPrescription.Patient);
            dbContext.Patients.Add(patient);
        }

        return newPrescription;
    }

    private readonly ClinicDb dbContext;
}
