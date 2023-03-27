using Tesla.Data.Models;

namespace Tesla.Data.Repository
{
    public interface ILocalisationRepository
    {
        List<Localisation> GetAllLocalisations();
    }
}