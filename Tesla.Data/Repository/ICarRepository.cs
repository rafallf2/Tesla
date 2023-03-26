using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public interface ICarRepository
    {
        List<Car> GetAllCars();
    }
}