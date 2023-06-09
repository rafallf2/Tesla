﻿using Microsoft.AspNetCore.Mvc;
using Tesla.Data.Dto;

namespace Tesla.Controllers
{
    public partial class ReservationController
    {
        [HttpPost("reservations")]
        public IActionResult Create([FromBody] ReservationCreateDto reservationCreateDto)
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
