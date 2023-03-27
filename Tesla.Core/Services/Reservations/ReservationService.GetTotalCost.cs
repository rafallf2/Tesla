using Tesla.Data.Dto;
using Tesla.Data.Models;

namespace Tesla.Core.Services.Reservations
{
    public partial class ReservationService
    {
        public double GetTotalCost(GetTotalCost model)
        {
            return _reservationsRepository.GetTotalCost(model);
        }
    }
}
