using Clinic.Exceptions;
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
        try
        {
            var patientData = await patientsService.GetPatientData(patientId);
            return Ok(patientData);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    private readonly PatientsService patientsService;
}
