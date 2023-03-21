using Tesla.Data.Database;

namespace Tesla.Data.Repository
{
    public partial class ReservationsRepository :IReservationsRepository
    {
        private readonly TeslaDbContext _database;
        public ReservationsRepository(TeslaDbContext database) { 
            _database = database;
        }
    }
}
