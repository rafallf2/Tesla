using Microsoft.AspNetCore.Mvc;
using Tesla.Core.Services.Reservations;

namespace Tesla.Controllers
{
    public partial class ReservationController
    {
        [HttpPost("reservations")]
        public IActionResult Create()
        {
            try
            {
                _reservationService.Create();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
