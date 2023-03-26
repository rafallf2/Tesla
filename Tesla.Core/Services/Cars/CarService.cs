using Tesla.Data.Repository;

namespace Tesla.Core.Services.Cars
{
    public partial class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
    }
}
