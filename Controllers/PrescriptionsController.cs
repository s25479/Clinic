using Clinic.Exceptions;
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
        try
        {
            await prescriptionsService.AddPrescription(newPrescription);
            return Ok();
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

    private readonly PrescriptionsService prescriptionsService;
}
