using Microsoft.AspNetCore.Mvc;
using Tesla.Data.Models;

namespace Tesla.Controllers
{
    public partial class ReservationController
    {
        [HttpGet("reservations/get-total-cost")]
        public IActionResult GetTotalCost([FromQuery] GetTotalCost model)
        {
            try
            {
                return Ok(_reservationService.GetTotalCost(model));
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
