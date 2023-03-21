using Tesla.Data.Repository;

namespace Tesla.Core.Services.Reservations
{
    public partial class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _reservationsRepository;
        public ReservationService(IReservationsRepository reservationRepository) {
            _reservationsRepository = reservationRepository;
        }

    }
}
