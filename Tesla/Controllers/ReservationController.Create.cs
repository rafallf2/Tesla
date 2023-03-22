using Microsoft.AspNetCore.Mvc;
using Tesla.Core.Services.Reservations;
using Tesla.Data.Dto;

namespace Tesla.Controllers
{
    public partial class ReservationController
    {
        [HttpPost("reservations")]
        public IActionResult Create(ReservationCreateDto reservationCreateDto)
        {
            try
            {
                _reservationService.Create(reservationCreateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
