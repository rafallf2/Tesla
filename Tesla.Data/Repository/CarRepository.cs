using Tesla.Data.Database;

namespace Tesla.Data.Repository
{
    public partial class CarRepository : ICarRepository
    {
        private readonly TeslaDbContext _database;
        public CarRepository(TeslaDbContext database)
        {
            _database = database;
        }
    }
}
