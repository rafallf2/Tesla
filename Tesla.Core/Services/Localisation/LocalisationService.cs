using Tesla.Data.Repository;

namespace Tesla.Core.Services.Localisation
{
    public partial class LocalisationService : ILocalisationService
    {
        private readonly ILocalisationRepository _localisationRepository;
        public LocalisationService(ILocalisationRepository localisationRepository)
        {
            _localisationRepository = localisationRepository;
        }
    }
}
