using Tesla.Data.Database;

namespace Tesla.Data.Repository
{
    public partial class LocalisationRepository : ILocalisationRepository
    {
        private readonly TeslaDbContext _database;
        public LocalisationRepository(TeslaDbContext database)
        {
            _database = database;
        }
    }
}
