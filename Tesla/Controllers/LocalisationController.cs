using Microsoft.AspNetCore.Mvc;
using Tesla.Core.Services.Localisation;

namespace Tesla.Controllers
{
    public partial class LocalisationController : ControllerBase
    {
        private const string CreateError = "Localisation data error!";
        private readonly ILocalisationService _localisationService;
        public LocalisationController(ILocalisationService localisationService)
        {
            _localisationService = localisationService;
        }
    }
}
