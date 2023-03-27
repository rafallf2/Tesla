using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public partial class LocalisationRepository
    {
        public List<Localisation> GetAllLocalisations()
        {
            return _database.Localisations.ToList();
        }
    }
}
