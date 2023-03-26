using Microsoft.AspNetCore.Mvc;
using Tesla.Core.Services.Cars;

namespace Tesla.Controllers
{
    public partial class CarController : ControllerBase
    {
        private const string CreateError = "Cars data error!";
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
    }
}
