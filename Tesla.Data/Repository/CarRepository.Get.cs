using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public partial class CarRepository
    {
        public List<Car> GetAllCars()
        {
            return _database.Cars.ToList();
        }
    }
}
