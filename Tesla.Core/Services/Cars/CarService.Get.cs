using Tesla.Data.Dto;

namespace Tesla.Core.Services.Cars
{
    public partial class CarService
    {
        public List<CarGetDto> GetAllCars()
        {
            var cars = _carRepository.GetAllCars();

            var carDtos = cars.Select(car => new CarGetDto
            {
                Id = car.Id,
                Name = car.Name,
                CostPerDay = car.CostPerDay
            }).ToList();

            return carDtos;
        }
    }
}
