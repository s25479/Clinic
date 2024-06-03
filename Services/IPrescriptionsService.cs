using Clinic.Models;

namespace Clinic.Services;

public interface IPrescriptionsService
{
    Task<NewPrescriptionDTO> AddPrescription(NewPrescriptionDTO newPrescription);
}
