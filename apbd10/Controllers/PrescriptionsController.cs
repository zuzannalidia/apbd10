using apbd10.DTO;
using apbd10.Services;
using Microsoft.AspNetCore.Mvc;
using apbd10.DTO;
using apbd10.Services;
using System.Threading.Tasks;

namespace apbd10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _prescriptionService.CreatePrescriptionAsync(dto);

            if (!success)
            {
                return BadRequest("Failed to create prescription.");
            }

            return Ok("Prescription created successfully.");
        }
    }
}
