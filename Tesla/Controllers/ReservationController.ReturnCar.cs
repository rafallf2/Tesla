using Microsoft.AspNetCore.Mvc;

namespace Tesla.Controllers
{
    public partial class ReservationController
    {
        [HttpPost("reservations/{id}/return")]
        public IActionResult ReturnCar([FromRoute] int id)
        {
            try
            {
                _reservationService.ReturnCar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
