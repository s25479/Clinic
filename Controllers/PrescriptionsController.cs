using Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers;

[Route("api/prescriptions")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    public PrescriptionsController(PrescriptionsService prescriptionsService)
    {
        this.prescriptionsService = prescriptionsService;
    }

    [HttpPut]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDTO newPrescription)
    {
        return Ok(newPrescription);
    }

    private readonly PrescriptionsService prescriptionsService;
}
