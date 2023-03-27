using Tesla.Data.Dto;
using Tesla.Data.Models;

namespace Tesla.Core.Services.Reservations
{
    public interface IReservationService
    {
        void Create(ReservationCreateDto reservationCreateDto);
        double GetTotalCost(GetTotalCost model);
        void ReturnCar(int reservationId);
    }
}