using Microsoft.AspNetCore.Mvc;

namespace Tesla.Controllers
{
    public partial class LocalisationController
    {
        [HttpGet("localisations")]
        public IActionResult GetAllLocalisations()
        {
            try
            {
                return Ok(_localisationService.GetAllLocalisations());
            }
            catch (Exception ex)
            {
                return BadRequest(CreateError);
            }
        }
    }
}
