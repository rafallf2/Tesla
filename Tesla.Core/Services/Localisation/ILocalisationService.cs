using Tesla.Data.Dto;

namespace Tesla.Core.Services.Localisation
{
    public interface ILocalisationService
    {
        public List<LocalisationGetDto> GetAllLocalisations();
    }
}