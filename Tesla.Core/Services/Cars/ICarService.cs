using Tesla.Data.Dto;
using Tesla.Data.Repository;

namespace Tesla.Core.Services.Cars
{
    public interface ICarService
    {
        public List<CarGetDto> GetAllCars();
    }
}