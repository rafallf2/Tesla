﻿using Microsoft.AspNetCore.Mvc;

namespace Tesla.Controllers
{
    public partial class CarController
    {
        [HttpGet("cars")]
        public IActionResult GetAllCars()
        {
            try
            {
                return Ok(_carService.GetAllCars());
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
