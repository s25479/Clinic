using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientsController : ControllerBase
{
    public PatientsController(PatientsService patientsService)
    {
        this.patientsService = patientsService;
    }

    [HttpGet("{patientId:int}")]
    public async Task<IActionResult> GetPatientData(int patientId)
    {
        var patientData = await patientsService.GetPatientData(patientId);
        return Ok(patientData);
    }

    private readonly PatientsService patientsService;
}
