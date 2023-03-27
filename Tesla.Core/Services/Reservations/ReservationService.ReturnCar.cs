namespace Tesla.Core.Services.Reservations
{
    public partial class ReservationService
    {
        public void ReturnCar(int reservationId)
        {
            _reservationsRepository.ReturnCar(reservationId);
        }
    }
}
