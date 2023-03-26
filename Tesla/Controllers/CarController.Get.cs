using Microsoft.AspNetCore.Mvc;
using Tesla.Data.Dto;

namespace Tesla.Controllers
{
    public partial class CarController
    {
        [HttpGet("cars")]
        public ActionResult<List<CarGetDto>> GetAllCars()
        {
            var cars = _carService.GetAllCars();
            return Ok(cars);
        }
    }
}
