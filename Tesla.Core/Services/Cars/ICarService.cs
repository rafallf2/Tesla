using Tesla.Data.Dto;

namespace Tesla.Core.Services.Cars
{
    public interface ICarService
    {
        public List<CarGetDto> GetAllCars();
    }
}