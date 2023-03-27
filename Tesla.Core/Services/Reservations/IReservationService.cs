using Tesla.Data.Dto;

namespace Tesla.Core.Services.Reservations
{
    public interface IReservationService
    {
        void Create(ReservationCreateDto reservationCreateDto);
        void ReturnCar(int reservationId);
    }
}