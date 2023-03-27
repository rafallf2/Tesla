using Microsoft.AspNetCore.Mvc;
using Tesla.Core.Services.Reservations;

namespace Tesla.Controllers
{
    public partial class ReservationController : ControllerBase
    {
        private const string CreateError = "Reservation creating error!";
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

    }
}
