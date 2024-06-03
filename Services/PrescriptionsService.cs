using Clinic.Exceptions;
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
        if (newPrescription.Medicaments.Count > 10)
            throw new ValidationException("Prescription must not have more than 10 medicaments!");
        
        foreach (var medicament in newPrescription.Medicaments)
        {
            if (await dbContext.Medicaments.FindAsync(medicament.MedicamentId) == null)
                throw new ValidationException("Medicament with id=" + medicament.MedicamentId + " does not exist!");
        }

        if (newPrescription.DueDate < newPrescription.Date)
            throw new ValidationException("DueDate must not be before Date");

        var patient = await dbContext.Patients.FindAsync(newPrescription.Patient.PatientId);
        if (patient == null)
        {
            patient = new Patient(newPrescription.Patient);
            dbContext.Patients.Add(patient);
        }

        var prescription = new Prescription()
        {
            Date = newPrescription.Date!.Value,
            DueDate = newPrescription.DueDate!.Value,
            Patient = patient,
            DoctorId = newPrescription.DoctorId!.Value
        };

        foreach (var medicament in newPrescription.Medicaments)
        {
            var medicamentPrescription = new MedicamentPrescription()
            {
                Dose = medicament.Dose,
                Details = medicament.Details,
                MedicamentId = medicament.MedicamentId!.Value,
                Prescription = prescription
            };
            prescription.MedicamentPrescriptions.Add(medicamentPrescription);
        }

        dbContext.Prescriptions.Add(prescription);
        await dbContext.SaveChangesAsync();
        return newPrescription;
    }

    private readonly ClinicDb dbContext;
}
