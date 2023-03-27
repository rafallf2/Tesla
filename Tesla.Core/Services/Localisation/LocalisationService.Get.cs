using Tesla.Data.Dto;

namespace Tesla.Core.Services.Localisation
{
    public partial class LocalisationService
    {
        public List<LocalisationGetDto> GetAllLocalisations()
        {
            var localisations = _localisationRepository.GetAllLocalisations();

            var localisationDtos = localisations.Select(localisations => new LocalisationGetDto
            {
                Id = localisations.Id,
                Name = localisations.Name,
            }).ToList();

            return localisationDtos;
        }
    }
}
